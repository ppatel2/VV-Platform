using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;
using System.Threading;
using System.Collections.Concurrent;
using VV.Web.Server.HelperClasses;
using VV.Web.Models;
using VV.Proxy;
using VV.Web.Server.DataModels;
using VV.Web.PostbackClient;


namespace VV.Web.Server
{
    public class EnrollmentServer
    {
        protected IBioConnectAPIProxy bioConnectAPIProxy;

        private const int TEMPLATES_PER_FINGER = 3;

        public EnrollmentServer(IBioConnectAPIProxy proxy)
        {
            bioConnectAPIProxy = proxy;
            NewEnrollmentEvent += HandleEnrollment;
        }

        private ConcurrentQueue<EnrollDataModel> enrollQueue = new ConcurrentQueue<EnrollDataModel>();

        private event EventHandler NewEnrollmentEvent;

        private void HandleEnrollment(Object sender, EventArgs args)
        {
            EnrollDataModel dataModel = null;
            bool result = enrollQueue.TryDequeue(out dataModel);
            if (!result) return;
            try
            {
                int[] templateIDs = null;
                if (dataModel.userDO.Fingers != null
                    && dataModel.userDO.Fingers.Where(x => (int)VV.DataObjects.FingerDataObject.FindFinger(x.FingerIndex) == dataModel.fingerIndex).FirstOrDefault() != null)
                {
                    templateIDs = dataModel.userDO.Fingers.Where(x => (int)VV.DataObjects.FingerDataObject.FindFinger(x.FingerIndex) == dataModel.fingerIndex).First().Templates.Select(x => x.Id).ToArray();
                }

                UsersEnrollPostbackModel postbackModel;
                for (int i = 0; i < TEMPLATES_PER_FINGER; i++)
                {
                    Proxy.BioConnectAPI.TemplateObject templateDO = bioConnectAPIProxy.GetTemplateObject(dataModel.readerID, dataModel.authorizedToken, dataModel.enrollQuality);
                    if (templateIDs != null && templateIDs.Length > i)
                    {
                        templateDO.Id = templateIDs[i];
                    }
                    templateDO.UserID = dataModel.userDO.Id;
                    templateDO.FingerIndex = dataModel.fingerIndex;
                    bioConnectAPIProxy.SaveScannedTemplate(templateDO, dataModel.authorizedToken);

                    postbackModel = new UsersEnrollPostbackModel
                    {
                        ReturnCode = 200,
                        Base64PNGImage = BitmapImageConverter.GetBase64Representation(BitmapImageConverter.GetTemplateImage(templateDO.Data))
                    };
                    PostbackClient.PostbackClient.EnrollPostback(dataModel.callbackUrl, postbackModel);
                }

                postbackModel = new UsersEnrollPostbackModel
                {
                    ReturnCode = 201
                };
                PostbackClient.PostbackClient.EnrollPostback(dataModel.callbackUrl, postbackModel);
            }
            catch(Exception ex)
            {
                UsersEnrollPostbackModel postbackModel = new UsersEnrollPostbackModel
                {
                    ReturnCode = 500,
                    ReturnMessage = ex.Message
                };
                var response = PostbackClient.PostbackClient.EnrollPostback(dataModel.callbackUrl, postbackModel);
            }
        }

        public void Enqueue(EnrollDataModel dataModel)
        {
            enrollQueue.Enqueue(dataModel);
            if (NewEnrollmentEvent != null) Task.Factory.StartNew(() => NewEnrollmentEvent(this, EventArgs.Empty));
        }
    }
}
