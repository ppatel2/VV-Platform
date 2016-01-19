using System;
using System.Windows.Media.Imaging;

namespace VV.DataObjects
{
    public class EmployeeDataObject
    {
        public string FirstName
        {
            get;
            set;
        }
        public string MiddleName
        {
            get;
            set;
        }
        public string LastName
        {
            get;
            set;
        }

        public BitmapImage Image
        {
            get;
            set;
        }

        public byte[] ImageData { get; set; }
        public string ImageType { get; set; }

        public int Id
        {
            get;
            set;
        }

        public string Address { get; set; }
        public string PhoneNumber { get; set; }
        public string CellNumber { get; set; }
        public string AppID { get; set; }
        public string Password { get; set; }

        public bool IsActive { get; set; }

        public bool IsDeleted { get; set; }
        public DateTime? CreatedAt { get; set; }
        public string CreatedBy { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string UpdatedBy { get; set; }
        public DateTime? DeletedAt { get; set; }
        public string DeletedBy { get; set; }

    }
}