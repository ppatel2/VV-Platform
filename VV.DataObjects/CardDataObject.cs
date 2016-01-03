using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace VV.DataObjects
{
     public class CardDataObject
     {
          public string Id { get; set; }

            public string ExternalId { get; set; }

          public bool IsActive { get; set; }

          public bool IsBypass { get; set;  }

          public string BadgeNumber { get; set; }

          public int Priority { get; set; }

          public long FacilityCode { get; set; }

          public string CredentialType { get; set; }

          public TransformedBitmap TypeImage { get; set; }

          public string PIN { get; set; }

          public ObservableCollection<LocationDataObject> Locations { get; set; }
          

           
     }
}
