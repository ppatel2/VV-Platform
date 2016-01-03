using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusConnectionInfoDataObject
    {
        public int Id;
        public string Name { get; set;  }
        public string Password { get; set; }
        public string Pin { get; set; }
        public string Port { get; set; }
        public string ServerIP { get; set; }


        public bool IsNew { get; set; }
    }
}
