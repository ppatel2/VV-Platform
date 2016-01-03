using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;

namespace VV.Web.Models
{
    [DataContract]
    public class ReadersModel
    {
        [DataMember]
        public string Url;

        [DataMember]
        public string Name;

        [DataMember]
        public string Location;

        [DataMember]
        public bool DefaultReader;

        [DataMember]
        public string Profile;

        [DataMember]
        public bool Online;

        [DataMember]
        public long DeviceID;

        [DataMember]
        public string IPAddress;
    }
}
