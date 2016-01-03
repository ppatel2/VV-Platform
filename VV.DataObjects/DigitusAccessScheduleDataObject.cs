using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusAccessScheduleDataObject
    {
        public string Name { get; set; }

        public Guid GroupGuid { get; set;  }
        public Dictionary <string,int> DeviceTimebandPairs  { get; set; }


        public bool ToDelete { get; set; }

        public bool IsNew { get; set; }

        public int Id { get; set; }
    }
}
