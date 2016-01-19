using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace VV.DataObjects
{
    public class AccountDataObject
    {
        public string Name { get; set; }
        public EmployeeDataObject PrimaryContact { get; set; }
        public EmployeeDataObject SecondaryContact { get; set; }
        public string PhoneNumber { get; set; }
        public string CellPhoneNumber { get; set; }
        public string FaxNumber { get; set; }
        public string Extension { get; set; }
        public LocationDataObject Location { get; set; }
        public string GoogleAPICode { get; set; }
        public string OldURL { get; set; }
        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }

    }
}
