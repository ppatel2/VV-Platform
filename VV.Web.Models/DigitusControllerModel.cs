using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusControllerModel
    {
        [DataMember]
        public Guid ControllerGuid;
        [DataMember]
        public string UnitModel;
        [DataMember]
        public string IPAssignment;
        [DataMember]
        public string IPAddress;
        [DataMember]
        public string Subnet;
        [DataMember]
        public string Gateway;
        [DataMember]
        public string RemotePort;
        [DataMember]
        public string Name;
        [DataMember]
        public bool Online;
        [DataMember]
        public int RemoteNodeFirmwareVersion;
        [DataMember]
        public int RemoteNodeFpgaVersion;
        [DataMember]
        public int ControllerFirmwareVersion;
        [DataMember]
        public int ControllerFpgaVersion;
        [DataMember]
        public int EnlineFirmwareVersion;
        [DataMember]
        public int EnlineFpgaVersion;
        [DataMember]
        public bool DownloadLogs;
    }
}
