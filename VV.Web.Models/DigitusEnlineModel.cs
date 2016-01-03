using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusEnlineModel
    {
        [DataMember]
        public Guid EnlineGuid { get; set; }
        [DataMember]
        public bool Approved { get; set; }
        [DataMember]
        public Guid ControllerGuid { get; set; }
        [DataMember]
        public bool Has125IdReader { get; set; }
        [DataMember]
        public bool HasFingerReader { get; set; }
        [DataMember]
        public bool HasRfidReader { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public int NodeSerialNumber { get; set; }
        [DataMember]
        public int SecurityLevel { get; set; }
        [DataMember]
        public bool ShowClock { get; set; }
        [DataMember]
        public bool TwelveHourClock { get; set; }
        [DataMember]
        public bool UkDateFormat { get; set; }
        [DataMember]
        public bool UpdateEnline { get; set; }
        [DataMember]
        public bool UseFinger { get; set; }
        [DataMember]
        public bool UsePin { get; set; }
        [DataMember]
        public bool UseRfid { get; set; }
    }
}
