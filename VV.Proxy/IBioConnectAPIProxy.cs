using System;
using System.Collections.Generic;


namespace VV.Proxy
{
    public interface IBioConnectAPIProxy
    {
        BioConnectAPI.TemplateObject GetTemplateObject(int deviceID, BioConnectAPI.SecurityTokenDto token, int qualityID);

        bool AuthenticateUser(string username, string password);

        BioConnectAPI.SecurityTokenDto RetrieveSecurityToken(string username, string password);

        void SaveSecurityToken(BioConnectAPI.SecurityTokenDto tokenToSave, BioConnectAPI.SecurityTokenDto requestedBy);

        BioConnectAPI.SecurityTokenDto RetrieveSecurityTokenByUsername(string username);

        int SaveScannedTemplate(BioConnectAPI.TemplateObject templateToSave, BioConnectAPI.SecurityTokenDto requestedBy);

        void SyncReaders(string username, string lastUsedIP, string location = null);

        void SyncUsers(DateTime changesSince, string username, string lastUsedIP);

        bool GetDigitusStatus();

        List<BioConnectAPI.DigitusConnectionInfoDataObject> GetDigitusConnections();

        List<BioConnectAPI.DigitusDeviceGroupDataObject> GetDigitusDeviceGroups();

        List<BioConnectAPI.DigitusControllerDataObject> GetDigitusBusControllers(string deviceGroupGuid);

        List<BioConnectAPI.DigitusControllerDataObject> GetDigitusSentryControllers(string deviceGroupGuid);

        List<BioConnectAPI.DigitusControllerNodeDataObject> GetDigitusBusControllerNodes(string controllerGuid);

        List<BioConnectAPI.DigitusDeviceDataObject> GetDigitusDevices(string controllerGuid, int nodeSerialNumber, string deviceGroupGuid);

        List<BioConnectAPI.DigitusEnlineDataObject> GetDigitusBusEnlines(string controllerGuid);

        List<BioConnectAPI.DigitusDeviceScheduleDataObject> GetDigitusDeviceSchedules();

        List<BioConnectAPI.DigitusTimebandDataObject> GetDigitusTimebands();

        List<BioConnectAPI.DigitusEventDataObject> GetDigitusEvents();

        List<BioConnectAPI.DigitusAlarmDataObject> GetDigitusAlarms();
    }
}