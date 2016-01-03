using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace VV.Proxy
{
    public class BioConnectAPIProxy : IBioConnectAPIProxy
    {
        private BioConnectAPI.BioConnectAPIClient client = new BioConnectAPI.BioConnectAPIClient();

        public BioConnectAPI.TemplateObject GetTemplateObject(int deviceID, BioConnectAPI.SecurityTokenDto token, int quality)
        {
            return client.GetTemplateObject(deviceID, token, quality);
        }

        public bool AuthenticateUser(string username, string password)
        {
            return client.AuthenticateUser(username, password);
        }

        public BioConnectAPI.SecurityTokenDto RetrieveSecurityToken(string username, string password)
        {
            return client.RetrieveSecurityToken(username, password);
        }

        public void SaveSecurityToken(BioConnectAPI.SecurityTokenDto tokenToSave, BioConnectAPI.SecurityTokenDto requestedBy)
        {
            client.SaveSecurityToken(tokenToSave, requestedBy);
        }

        public BioConnectAPI.SecurityTokenDto RetrieveSecurityTokenByUsername(string username)
        {
            return client.RetrieveSecurityTokenByUsername(username);
        }

        public int SaveScannedTemplate(BioConnectAPI.TemplateObject templateToSave, BioConnectAPI.SecurityTokenDto requestedBy)
        {
            return client.SaveScannedTemplate(templateToSave, requestedBy);
        }

        public void SyncReaders(string username, string lastUsedIP, string location = null)
        {
            client.SynchronizeAllReaders(username, lastUsedIP, location);
        }

        public void SyncUsers(DateTime changesSince, string username, string lastUsedIP)
        {
            client.Synchronize(changesSince, username, lastUsedIP);
        }

        public bool GetDigitusStatus()
        {
            return client.DigitusStatus();
        }

        public List<BioConnectAPI.DigitusConnectionInfoDataObject> GetDigitusConnections()
        {
            return client.GetDigitusConnectionsList().ToList();
        }

        public List<BioConnectAPI.DigitusDeviceGroupDataObject> GetDigitusDeviceGroups()
        {
            return client.GetDigitusDeviceGroupList().ToList();
        }

        public List<BioConnectAPI.DigitusControllerDataObject> GetDigitusBusControllers(string deviceGroupGuid)
        {
            return client.GetDigitusBusControllers(deviceGroupGuid).ToList();
        }

        public List<BioConnectAPI.DigitusControllerDataObject> GetDigitusSentryControllers(string deviceGroupGuid)
        {
            return client.GetDigitusSentryControllers(deviceGroupGuid).ToList();
        }

        public List<BioConnectAPI.DigitusControllerNodeDataObject> GetDigitusBusControllerNodes(string controllerGuid)
        {
            return client.GetDigitusBusControllerNodes(controllerGuid, null).ToList();
        }

        public List<BioConnectAPI.DigitusDeviceDataObject> GetDigitusDevices(string controllerGuid, int nodeSerialNumber, string deviceGroupGuid)
        {
            return client.GetAllDigitusDevices(controllerGuid, nodeSerialNumber, deviceGroupGuid).ToList();
        }

        public List<BioConnectAPI.DigitusEnlineDataObject> GetDigitusBusEnlines(string controllerGuid)
        {
            return client.GetDigitusBusControllerEnlines(controllerGuid, null).ToList();
        }

        public List<BioConnectAPI.DigitusDeviceScheduleDataObject> GetDigitusDeviceSchedules()
        {
            return client.GetDigitusAccessScheduleList().ToList();
        }

        public List<BioConnectAPI.DigitusTimebandDataObject> GetDigitusTimebands()
        {
            return client.GetDigitusTimeBands().ToList();
        }

        public List<BioConnectAPI.DigitusEventDataObject> GetDigitusEvents()
        {
            //return client.GetDigitusEvents().ToList();
            return new List<BioConnectAPI.DigitusEventDataObject>();
        }

        public List<BioConnectAPI.DigitusAlarmDataObject> GetDigitusAlarms()
        {
            return client.GetLatestDigitusAlarms().ToList();
        }
    }
}
