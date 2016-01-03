using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusDeviceScheduleModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public Guid GroupGuid { get; set; }
        [DataMember]
        public Dictionary<string, int> DeviceTimebandPairs { get; set; }
    }
}
