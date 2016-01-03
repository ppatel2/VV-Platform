using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web.Http.Routing;
using VV.DataObjects;

namespace VV.Web.Models
{
    public class ModelFactory
    {
        UrlHelper urlHelper;

        public ModelFactory(HttpRequestMessage Request)
        {
            urlHelper = new UrlHelper(Request);
        }

        public UsersModel Create(UsersDataObject usersDO)
        {
            UsersModel model = new UsersModel
            {
                Url = urlHelper.Link("User", new { externalId = usersDO.ExternalID }),
                ExternalID = usersDO.ExternalID,
                Name = usersDO.Name,
                IsActive = usersDO.IsActive,
                UpdatedAt = usersDO.UpdatedAt,
                CardsCount = usersDO.CardsCount,
                FingersCount = usersDO.FingersCount
            };
            return model;
        }

        public ReadersModel Create(ReadersStubDataObject readersStubDO)
        {
            ReadersModel model = new ReadersModel
            {
                Url = urlHelper.Link("SupremaReader", new { deviceId = readersStubDO.DeviceID }),
                Name = readersStubDO.Name,
                Location = readersStubDO.Location,
                DefaultReader = readersStubDO.DefaultReader,
                Profile = readersStubDO.Profile,
                Online = readersStubDO.Online,
                DeviceID = readersStubDO.DeviceID,
                IPAddress = readersStubDO.IPAddress
            };
            return model;
        }

        public ReadersModel Create(ReadersDataObject readersDO)
        {
            ReadersModel model = new ReadersModel
            {
                Url = urlHelper.Link("SupremaReader", new { deviceId = readersDO.DeviceID }),
                Name = readersDO.Name,
                Location = readersDO.Location,
                DefaultReader = readersDO.DefaultReader,
                Profile = readersDO.Profile,
                Online = readersDO.Online,
                DeviceID = readersDO.DeviceID,
                IPAddress = readersDO.IPAddress
            };
            return model;
        }

        public CardsModel Create(string externalId, CardDataObject cardDO)
        {
            CardsModel model = new CardsModel
            {
                Url = urlHelper.Link("Card", new { externalId = externalId, cardExternalId = cardDO.ExternalId }),
                ExternalId = cardDO.ExternalId,
                BadgeNumber = cardDO.BadgeNumber,
                IsActive = cardDO.IsActive,
                FacilityCode = cardDO.FacilityCode,
                IsBypass = cardDO.IsBypass,
                Priority = cardDO.Priority
            };
            return model;
        }

        public UsersDataObject Parse(UsersModel userModel)
        {
            UsersDataObject obj = new UsersDataObject
            {
                ExternalID = userModel.ExternalID,
                Name = userModel.Name
            };
            return obj;
        }


        public CardDataObject Parse(CardsModel cardModel)
        {
            CardDataObject obj = new CardDataObject
            {
                ExternalId = cardModel.ExternalId,
                BadgeNumber = cardModel.BadgeNumber,
                IsActive = cardModel.IsActive,
                PIN = cardModel.PIN,
                FacilityCode = cardModel.FacilityCode,
                Priority = cardModel.Priority,
                IsBypass = cardModel.IsBypass
            };
            return obj;
        }

        public DigitusConnectionModel Create(VV.Proxy.BioConnectAPI.DigitusConnectionInfoDataObject obj)
        {
            DigitusConnectionModel model = new DigitusConnectionModel
            {
                Name = obj.Name,
                ServerIP = obj.ServerIP,
                Pin = obj.Pin,
                Password = obj.Password,
                Port = obj.Port
            };
            return model;
        }

        public DigitusDeviceGroupModel Create(VV.Proxy.BioConnectAPI.DigitusDeviceGroupDataObject obj)
        {
            DigitusDeviceGroupModel model = new DigitusDeviceGroupModel
            {
                DeviceGroupGuid = Guid.Parse(obj.Id),
                Name = obj.Name,
                Description = obj.Description
            };
            return model;
        }

        public DigitusControllerModel Create(VV.Proxy.BioConnectAPI.DigitusControllerDataObject obj)
        {
            DigitusControllerModel model = new DigitusControllerModel
            {
                ControllerGuid = Guid.Parse(obj.Guid),
                UnitModel = obj.UnitModel,
                IPAssignment = obj.IpAssignment,
                IPAddress = obj.IpAddress,
                Subnet = obj.Subnet,
                Gateway = obj.Gateway,
                RemotePort = obj.RemotePort,
                Name = obj.Name,
                Online = Boolean.Parse(obj.Online),
                RemoteNodeFirmwareVersion = obj.RemoteNodeFirmwareVersion,
                RemoteNodeFpgaVersion = obj.RemoteNodeFpgaVersion,
                ControllerFirmwareVersion = obj.ControllerFirmwareVersion,
                ControllerFpgaVersion = obj.ControllerFpgaVersion,
                EnlineFirmwareVersion = obj.EnlineFirmwareVersion,
                EnlineFpgaVersion = obj.EnlineFpgaVersion,
                DownloadLogs = Boolean.Parse(obj.DownloadLogs)
            };
            return model;
        }

        public DigitusControllerNodeModel Create(VV.Proxy.BioConnectAPI.DigitusControllerNodeDataObject obj)
        {
            DigitusControllerNodeModel model = new DigitusControllerNodeModel
            {
                ControllerGuid = Guid.Parse(obj.ControllerId),
                Name = obj.Name,
                NodeSerialNumber = obj.NodeSerialNumber
            };
            return model;
        }

        public DigitusDeviceModel Create(VV.Proxy.BioConnectAPI.DigitusDeviceDataObject obj)
        {
            DigitusDeviceModel model = new DigitusDeviceModel
            {
                DeviceGuid = obj.DeviceGuid,
                ControllerGuid = obj.ControllerGuid,
                NodeDeviceNumber = obj.NodeDeviceNumber,
                NodeSerialNumber = obj.NodeSerialNumber,
                Type = obj.Type,
                Name = obj.Name,
                DeviceGroupGuid = obj.GroupGuid,
                Approved = obj.Approved == "T" ? true : false,
                DoorForced = obj.DoorForced == "T" ? true : false,
                TamperAlarm = obj.TamperAlarm == "T" ? true : false,
                ForcedLatchAlarm = obj.ForcedLatchAlarm == "T" ? true : false,
                EntryDelay = obj.EntryDelay,
                ExitDelay = obj.ExitDelay,
                ProppedDelay = obj.ProppedDelay,
                ProppedSeconds = obj.ProppedSeconds == "T" ? true : false,
                SecurityLevel = obj.SecurityLevel,
                Auth1Unlocks2 = obj.Auth1Unlocks2 == "T" ? true : false,
                Auth2Unlocks1 = obj.Auth2Unlocks1 == "T" ? true : false
            };
            return model;
        }

        public DigitusEnlineModel Create(VV.Proxy.BioConnectAPI.DigitusEnlineDataObject obj)
        {
            DigitusEnlineModel model = new DigitusEnlineModel
            {
                EnlineGuid = obj.EnlineGuid,
                Approved = obj.Approved == "T" ? true : false,
                ControllerGuid = obj.ControllerGuid,
                Has125IdReader = obj.Has125IdReader == "T" ? true : false,
                HasFingerReader = obj.HasFingerReader == "T" ? true : false,
                HasRfidReader = obj.HasRfidReader == "T" ? true : false,
                Name = obj.Name,
                NodeSerialNumber = obj.NodeSerialNumber,
                SecurityLevel = obj.SecurityLevel,
                ShowClock = obj.ShowClock == "T" ? true : false,
                TwelveHourClock = obj.TwelveHourClock == "T" ? true : false,
                UkDateFormat = obj.UkDateFormat == "T" ? true : false,
                UpdateEnline = obj.UpdateEnline == "T" ? true : false,
                UseFinger = obj.UseFinger == "T" ? true : false,
                UsePin = obj.UsePin == "T" ? true : false,
                UseRfid = obj.UseRfid == "T" ? true : false
            };
            return model;
        }

        public DigitusEventModel Create(VV.Proxy.BioConnectAPI.DigitusEventDataObject obj)
        {
            DigitusEventModel model = new DigitusEventModel
            {
                DeviceGuid = obj.DeviceGuid,
                EventDescription = obj.EventDescription,
                EventGuid = obj.EventGuid,
                EventId = obj.EventID,
                EventType = obj.EventType,
                UserGuid = obj.UserGuid,
                SystemDateTime = obj.SystemDateTime,
                ActivityRecordId = obj.ActivityRecordId
            };
            return model;
        }

        public DigitusAlarmModel Create(VV.Proxy.BioConnectAPI.DigitusAlarmDataObject obj)
        {
            DigitusAlarmModel model = new DigitusAlarmModel
            {
                AckedTime = obj.AckedTime,
                ActiveTime = obj.ActiveTime,
                AlarmGuid = obj.AlarmGuid,
                AlarmType = obj.AlarmType,
                ClearedTime = obj.ClearedTime,
                ControllerGuid = obj.ControllerGuid,
                DeviceGuid = obj.DeviceGuid,
                DeviceName = obj.DeviceName,
                DeviceNumber = obj.DeviceNumber,
                DeviceType = obj.DeviceType,
                EventDescription = obj.EventDescription,
                EventGuid = obj.EventGuid,
                EventID = obj.EventID,
                EventType = obj.EventType,
                NodeSN = obj.NodeSN,
                State = obj.State,
                UserGuid = obj.UserGuid,
                UserID = obj.UserID,
                UserName = obj.UserName,
                AlarmStatus = obj.AlarmStatus,
                LastAction = obj.LastAction
            };
            return model;
        }

        public DigitusTimebandModel Create(VV.Proxy.BioConnectAPI.DigitusTimebandDataObject obj)
        {
            DigitusTimebandModel model = new DigitusTimebandModel
            {
                Id = obj.Id,
                Name = obj.Name,
                Data = obj.Data
            };
            return model;
        }

        public DigitusDeviceScheduleModel Create(VV.Proxy.BioConnectAPI.DigitusDeviceScheduleDataObject obj)
        {
            DigitusDeviceScheduleModel model = new DigitusDeviceScheduleModel
            {
                GroupGuid = obj.GroupGuid,
                Name = obj.Name,
                DeviceTimebandPairs = obj.DeviceTimebandPairs
            };
            return model;
        }
    }
}
