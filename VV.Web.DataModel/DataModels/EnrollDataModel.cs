using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VV.Proxy.BioConnectAPI;
using VV.DataObjects;


namespace VV.Web.Server.DataModels
{
    public class EnrollDataModel
    {
        public int readerID;

        public VV.DataObjects.UsersDataObject userDO;

        public int fingerIndex;

        public int enrollQuality;

        public string callbackUrl;

        public SecurityTokenDto authorizedToken;
    }
}
