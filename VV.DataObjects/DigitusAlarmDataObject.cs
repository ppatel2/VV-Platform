using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusAlarmDataObject
    {
        public DateTime AckedTime { get; set; }
        public DateTime ActiveTime { get; set; }
        public Guid AlarmGuid { get; set; }
        public int AlarmType { get; set; }
        public DateTime ClearedTime { get; set; }
        public Guid ControllerGuid { get; set; }
        public Guid DeviceGuid { get; set; }
        public string DeviceName { get; set; }
        public int DeviceNumber { get; set; }
        public string DeviceType { get; set; }
        public string EventDescription { get; set; }
        public Guid EventGuid { get; set; }
        public int EventID { get; set; }
        public int EventType { get; set; }
        public int NodeSN { get; set; }
        public string State { get; set; }
        public Guid UserGuid { get; set; }
        public int UserID { get; set; }
        public string UserName { get; set; }
        public int AlarmStatus { get; set; }
    }
}
