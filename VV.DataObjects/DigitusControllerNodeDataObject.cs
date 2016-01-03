using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusControllerNodeDataObject
    {
        public Guid ControllerGuid { get; set; }
        public string Name { get; set; }
        public int NodeSerialNumber { get; set; }
    }
}
