using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace VV.DataObjects
{
    public class UsersAdminDataObject
     {
          public int Id   {  get;  set;   }
  
          public string DevicePassword { get; set; }

           public bool IsAdministrator { get; set; }

          public bool IsDeviceAdministrator { get; set;  }

     }
}
