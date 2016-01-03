using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusGenericDeviceDataObject
    {
        public Guid DeviceGuid { get; set; }
        public int Type { get; set; }
  
 
        public string Name { get ; set; }
   

        public int NodeDeviceNumber { get; set; }
  

        public int NodeSerialNumber { get; set; }
  
         public Guid ControllerGuid { get; set; }

        
  
    }
}
