using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusEventModel
    {
        [DataMember]
        public Guid DeviceGuid { get; set; }
        [DataMember]
        public string EventDescription { get; set; }
        [DataMember]
        public Guid EventGuid { get; set; }
        [DataMember]
        public int EventId { get; set; }
        [DataMember]
        public int EventType { get; set; }
        [DataMember]
        public Guid UserGuid { get; set; }
        [DataMember]
        public DateTime SystemDateTime { get; set; }
        [DataMember]
        public long ActivityRecordId { get; set; }
    }
}
