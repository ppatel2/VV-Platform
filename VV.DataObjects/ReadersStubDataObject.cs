using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{

    public class ReadersStubDataObject
    {
        public int ID { get; set;  }

        public string Name { get; set; }
        public string Location { get; set; }
        public bool DefaultReader { get; set; }
        public string Profile { get; set; }
        public bool Online { get; set; }
        public long DeviceID { get; set; }
        public string IPAddress { get; set; }
        public object  ReaderDataObject { get; set;  }
    }
 
}
