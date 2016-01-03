using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusTimebandDataObject
    {
        public int Id { get; set;  }
        public string Name { get; set; }
        public string Data { get; set; }

        public bool IsNew { get; set; }

        public bool ToDelete { get; set; }
    }
}
