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
    public class UsersEnrollModel
    {
        [DataMember]
        [Required]
        public int deviceID { get; set; }

        [DataMember]
        [Required]
        [Range(0,9,ErrorMessage = "Allowed range of Finger Index is 0-9")]
        public int fingerIndex { get; set; }

        [DataMember]
        [Required]
        [Range(20,80, ErrorMessage = "Allowed range of Enroll Quality is 20-80")]
        public int enrollQuality { get; set; }

        [DataMember]
        [Required]
        [Url(ErrorMessage = "Url is not valid fully-qualified, use 127.0.0.1 for localhosts")]
        public string callbackUrl { get; set; }
    }
}
