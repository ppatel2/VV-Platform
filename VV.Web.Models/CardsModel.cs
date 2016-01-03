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
    public class CardsModel
    {
        [DataMember]
        [Required]
        public string Url;

        [DataMember]
        [Required]
        public string ExternalId { get; set; }

        [DataMember]
        [Required]
        public string BadgeNumber { get; set; }

        [DataMember]
        [Required]
        public bool IsActive { get; set; }

        [DataMember]
        [Required]
        public string PIN { get; set; }

        [DataMember]
        [Required]
        public int Priority;

        [DataMember]
        [Required]
        public long FacilityCode;

        [DataMember]
        [Required]
        public bool IsBypass;
    }
}
