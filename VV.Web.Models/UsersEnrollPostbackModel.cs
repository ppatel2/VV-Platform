using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Runtime.Serialization;
using System.ComponentModel.DataAnnotations;

namespace VV.Web.Models
{
    [DataContract]
    public class UsersEnrollPostbackModel
    {
        [DataMember]
        public int ReturnCode;

        [DataMember]
        public string ReturnMessage;

        [DataMember]
        public string Base64PNGImage;
    }
}
