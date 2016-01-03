using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{

    public class AddReaderDataObject 
    {
    
       
        public AddReaderDataObject()
        {

        }
        public long DeviceID { get; set; }
        public bool DHCP { get; set; }
        public string FirmwareVersion { get; set; }
        public string Gateway { get; set; }
        public string IPAddress { get; set; }
        public string ServerIPAddress { get; set; }
        public int ServerPort { get; set; }
        public string Subnet { get; set; }
        public bool UseServerMode { get; set; }
        public bool TimeSync { get; set; }
        public string Type { get; set; }
        public bool Online { get; set; }
        public string MACAddress { get; set; }

        public string strDeviceType { get; set; }
      
        public bool? ReadStatus { get; set;  }
        public bool? UpdateStatus { get; set;  }
        public bool? VerifyStatus { get; set;  }
        public string ReadStatusMessage { get; set; }
        public string UpdateStatusMessage { get; set; }
        public string VerifyStatusMessage { get; set; }

        public bool?  UseServerMatching { get; set; }
    }
}
