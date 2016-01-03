using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusDeviceGroupModel
    {
        [DataMember]
        public Guid DeviceGroupGuid { get; set; }
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Description { get; set; }
    }
}
