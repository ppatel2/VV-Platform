using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{

    public class ReadersBasicInfoDataObject
    {
        public int ID { get; set;  }
        public string ReaderName { get; set;  }
        public string Location { get; set; }
        public object  ReaderDataObject { get; set;  }

    }
 
}
