using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusAlarmModel
    {
        [DataMember]
        public DateTime AckedTime { get; set; }
        [DataMember]
        public DateTime ActiveTime { get; set; }
        [DataMember]
        public Guid AlarmGuid { get; set; }
        [DataMember]
        public int AlarmType { get; set; }
        [DataMember]
        public DateTime ClearedTime { get; set; }
        [DataMember]
        public Guid ControllerGuid { get; set; }
        [DataMember]
        public Guid DeviceGuid { get; set; }
        [DataMember]
        public string DeviceName { get; set; }
        [DataMember]
        public int DeviceNumber { get; set; }
        [DataMember]
        public string DeviceType { get; set; }
        [DataMember]
        public string EventDescription { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public int EventID { get; set; }
        [DataMember]
        public int EventType { get; set; }
        [DataMember]
        public int NodeSN { get; set; }
        [DataMember]
        public string State { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public int UserID { get; set; }
        [DataMember]
        public string UserName { get; set; }
        [DataMember]
        public int AlarmStatus { get; set; }
        [DataMember]
        public DateTime LastAction { get; set; }
    }
}
