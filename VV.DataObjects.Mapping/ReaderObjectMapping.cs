using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Entertech.BiometricService.Entities;
using BioConnect.DataObjects;

namespace BioConnect.DataObjects.Mapping
{
     public class ReaderObjectMapping
     {
          public static ReadersDataObject FromEntityReaderToDataObject(BiometricReader reader)
          {
               BioConnect.DataObjects.ReadersDataObject readerDataObject = new BioConnect.DataObjects.ReadersDataObject();
               readerDataObject.ID = reader.Id;
               readerDataObject.TypeCode = reader.DeviceTypeCode;
               readerDataObject.IPAddress = reader.IpAddress;
               readerDataObject.Name = reader.ReaderName;
               readerDataObject.ServerIPAddress = reader.ServerIpAddress;
               readerDataObject.ServerPort = reader.Port;
               readerDataObject.Location = reader.Location;
               readerDataObject.DefaultReader = reader.DefaultReader;
               readerDataObject.CardOffset = (int)reader.CardOffset;
               readerDataObject.FacilityCode = (int)reader.FacilityCode;
               readerDataObject.WiegandPassthrough = reader.WiegandPassthrough;
               readerDataObject.Online = reader.Online;
               readerDataObject.DeviceHandle = reader.DeviceHandle;
               readerDataObject.ProfileCode = reader.ProfileCode;
               readerDataObject.FirmwareVersion = reader.FirmwareVersion;
               readerDataObject.KernelVersion = reader.KernelVersion;
               readerDataObject.TemplateTypeCode = reader.TemplateTypeCode;
               readerDataObject.Gateway = reader.Gateway;
               readerDataObject.Subnet = reader.Subnet;
               readerDataObject.UseServerMode = reader.UseServerMode;
               readerDataObject.UseServerMatching = reader.UseServerMatching;
               readerDataObject.TimeSync = reader.TimeSync;
               readerDataObject.CardFormatCode = reader.CardFormatCode;
               readerDataObject.WiegandOutputCode = reader.WiegandOutputCode;
               readerDataObject.FailCode = reader.FailCode;
               readerDataObject.CardReadModeCode = reader.CardReadModeCode;
               //readerDataObject.CardReadMode=
               readerDataObject.OperationModeCode = reader.OperationModeCode;
               readerDataObject.DHCP = reader.DHCP;
               readerDataObject.DeviceID = reader.DeviceId;
               readerDataObject.TimeZone = (long)reader.TimeZone.TotalSeconds;
               return readerDataObject;
          }

          public static BiometricReader FromDataObjectToReaderEntity(ReadersDataObject readerDataObject)
          {
               BiometricReader reader = new BiometricReader();
               reader.Id = readerDataObject.ID;
               reader.DeviceTypeCode = (int)readerDataObject.TypeCode;
               reader.IpAddress = readerDataObject.IPAddress;
               reader.ReaderName = readerDataObject.Name;
               reader.ServerIpAddress = readerDataObject.ServerIPAddress;
               reader.Port = readerDataObject.ServerPort;
               reader.Location = readerDataObject.Location;
               reader.DefaultReader = readerDataObject.DefaultReader;
               reader.CardOffset = readerDataObject.CardOffset;
               reader.FacilityCode = readerDataObject.FacilityCode;
               reader.WiegandPassthrough = readerDataObject.WiegandPassthrough;
               reader.Online = readerDataObject.Online;
               reader.DeviceHandle = readerDataObject.DeviceHandle;
               reader.ProfileCode = readerDataObject.ProfileCode == null ? 0 : (int)readerDataObject.ProfileCode; //Removed BS_CONSTANTS.BS_Custom Profile code
               reader.FirmwareVersion = readerDataObject.FirmwareVersion;
               reader.KernelVersion = readerDataObject.KernelVersion;
               reader.TemplateTypeCode = readerDataObject.TemplateTypeCode == null ? 0 : (int)readerDataObject.TemplateTypeCode;
               reader.Gateway = readerDataObject.Gateway;
               reader.Subnet = readerDataObject.Subnet;
               reader.UseServerMode = readerDataObject.UseServerMode;
               reader.UseServerMatching = readerDataObject.UseServerMatching;
               reader.TimeSync = readerDataObject.TimeSync;
               reader.CardFormatCode = (int)(readerDataObject.CardFormatCode == null ? 0 : readerDataObject.CardFormatCode); //Corp1000 code from BS_Constants
               reader.WiegandOutputCode = readerDataObject.WiegandOutputCode == null ? 0 : (int)readerDataObject.WiegandOutputCode;
               reader.FailCode = readerDataObject.FailCode;
               reader.CardReadModeCode = (int)(readerDataObject.CardReadModeCode == null ? 0 : readerDataObject.CardReadModeCode);
               //readerDataObject.CardReadMode=
               reader.OperationModeCode = (int)(readerDataObject.OperationModeCode == null ? 0 : readerDataObject.OperationModeCode);
               reader.DHCP = readerDataObject.DHCP;
               reader.DeviceId = readerDataObject.DeviceID;
               reader.TimeZone = new TimeSpan(readerDataObject.TimeZone);
               return reader;
          }
     }
}
