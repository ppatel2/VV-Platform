using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusDeviceModel
    {
        [DataMember]
        public Guid DeviceGuid { get; set; }

        [DataMember]
        public Guid ControllerGuid { get; set; }

        [DataMember]
        public int NodeSerialNumber { get; set; }

        [DataMember]
        public int NodeDeviceNumber { get; set; }

        [DataMember]
        public int Type { get; set; }

        [DataMember]
        public string Name { get; set; }

        [DataMember]
        public Guid DeviceGroupGuid { get; set; }

        [DataMember]
        public bool Approved { get; set; }

        [DataMember]
        public bool DoorForced { get; set; }

        [DataMember]
        public bool TamperAlarm { get; set; }

        [DataMember]
        public bool ForcedLatchAlarm { get; set; }

        [DataMember]
        public int EntryDelay { get; set; }

        [DataMember]
        public int ExitDelay { get; set; }

        [DataMember]
        public int ProppedDelay { get; set; }

        [DataMember]
        public bool ProppedSeconds { get; set; }

        [DataMember]
        public int? SecurityLevel { get; set; }

        [DataMember]
        public bool Auth1Unlocks2 { get; set; }

        [DataMember]
        public bool Auth2Unlocks1 { get; set; }
    }
}
