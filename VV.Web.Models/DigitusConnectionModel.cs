using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Text;
using System.Threading.Tasks;

namespace VV.Web.Models
{
    [DataContract]
    public class DigitusConnectionModel
    {
        [DataMember]
        public string Name { get; set; }
        [DataMember]
        public string Password { get; set; }
        [DataMember]
        public string Pin { get; set; }
        [DataMember]
        public string Port { get; set; }
        [DataMember]
        public string ServerIP { get; set; }
    }
}
