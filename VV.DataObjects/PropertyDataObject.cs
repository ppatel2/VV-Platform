using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
     public class PropertyDataObject
     {
          public string ID { get; set;  }

          public KeyValuePair<string, string> Property { get; set; }
     }
}
