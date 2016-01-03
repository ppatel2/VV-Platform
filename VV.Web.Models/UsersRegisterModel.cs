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
    public class UsersRegisterModel
    {
        [DataMember]
        [Required]
        public string UserName { get; set; }

        [DataMember]
        [Required]
        public string Password { get; set; }

        [DataMember]
        [Required]
        [Compare("Password", ErrorMessage = "Passwords do not match")]
        public string ConfirmPassword { get; set; }

        [DataMember]
        [Required]
        [RegularExpression("(?i)^Admin|User", ErrorMessage = "Role must be User or Admin")]
        public string Role { get; set; }
    }
}
