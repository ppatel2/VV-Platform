using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusEventDataObject
    {
        public Guid DeviceGuid { get; set; }
        public string EventDescription { get; set; }
        public Guid EventGuid { get; set; }
        public int EventID { get; set; }
        public int EventType { get; set; }
        public Guid UserGuid { get; set; }
        public DateTime SystemDateTime { get; set;  }
        public long ActivityRecordId { get; set;  }
    }
}
