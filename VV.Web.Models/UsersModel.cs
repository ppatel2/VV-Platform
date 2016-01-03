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
    public class UsersModel
    {
        [DataMember]
        [Required]
        public string Url;

        [DataMember]
        [Required]
        public string Name { get; set; }

        [DataMember]
        [Required]
        public string ExternalID { get; set; }

        [DataMember]
        [Required]
        public bool IsActive { get; set; }

        [DataMember]
        [Required]
        public DateTime? UpdatedAt;

        [DataMember]
        [Required]
        public int CardsCount;

        [DataMember]
        [Required]
        public int FingersCount;
    }
}
