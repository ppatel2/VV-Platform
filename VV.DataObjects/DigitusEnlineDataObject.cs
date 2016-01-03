using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusEnlineDataObject
    {
        public string Approved { get; set; }
        public Guid ControllerGuid { get; set; }
        public Guid EnlineGuid { get; set; }
        public string Has125IdReader { get; set; }
        public string HasFingerReader { get; set; }
        public string HasRfidReader { get; set; }
        public string Name { get; set; }
        public int NodeSerialNumber { get; set; }
        public int SecurityLevel { get; set; }
        public string ShowClock { get; set; }
        public string TwelveHourClock { get; set; }
        public string UkDateFormat { get; set; }
        public string UpdateEnline { get; set; }
        public string UseFinger { get; set; }
        public string UsePin { get; set; }
        public string UseRfid { get; set; }

        public string Use125IdReader { get; set; }
    }
}
