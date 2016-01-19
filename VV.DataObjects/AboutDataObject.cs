using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;

namespace VV.DataObjects
{
     public class AboutDataObject
     {
          public string ClientVersion
          {
               get;
               set;
          }

          public string ServerVersion
          {
               get;
               set;
          }

          public string SupportInformation
          {
               get;
               set;
          }

        public string LogoType { get; set; }
          public byte[] Logo 
          { 
               get; 
               set; 
          }
     }
}
