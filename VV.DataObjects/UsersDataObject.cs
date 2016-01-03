using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace VV.DataObjects
{
     public class UsersDataObject
     {
          public string Name 
          { 
               get; 
               set; 
          }

          public BitmapImage Image
          { 
               get; 
               set; 
          }

          public byte[] ImageData { get; set;  }

          public int Id
          {
               get;
               set;
          }

          public string ExternalID { get; set; }

          public string DevicePassword { get; set; }

          public string Password { get; set; }

          public bool IsActive { get; set; }

          public bool IsAdministrator { get; set; }

          public bool IsDeviceAdministrator { get; set;  }

          public int TemplatesCount { get; set; }

          public int CardsCount { get; set; }

          public int FingersCount { get; set; }

          public int FacesCount { get; set; }

          public TransformedBitmap ThumbnailImage { get; set; }

          public int FaceCount { get; set; }

          public ObservableCollection<FingerDataObject> Fingers { get; set; }

          public ObservableCollection<FaceDataObject> Faces { get; set; }

          public ObservableCollection<CardDataObject> Cards { get; set; }

          public ObservableCollection<LocationDataObject> Locations { get; set; }

          public ObservableCollection<PropertyDataObject> Properties { get; set; }

          public DateTime? UpdatedAt;
          public object UserVM { get; set;  }

         //Format is "location - 1"
          public int GetActualID_DeviceID(string location)
          {
              String strid = ExternalID.Substring(location.Length + 3, ExternalID.Length - location.Length - 3);
              return Convert.ToInt32(strid);
          }

          public int GetActualID_DeviceID()
          {
              int idx=ExternalID.LastIndexOf(" - ");
              idx += 3; //we need to point to the end of the search
              if (idx > ExternalID.Length - 1)
                  return Id;
              return Convert.ToInt32(ExternalID.Substring(idx, ExternalID.Length - idx));
          }
     }
}
