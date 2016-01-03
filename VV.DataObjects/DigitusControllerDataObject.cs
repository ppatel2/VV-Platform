using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusControllerDataObject
    {
        private System.Guid controllerGuid = new System.Guid(new Byte[16]);

        private string unitModel = string.Empty;

        private string mac = string.Empty;

        private string ipAssignment = string.Empty;

        private string ipAddress = string.Empty;

        private string subnet = string.Empty;

        private string gateway = string.Empty;

        private string remotePort = "1001";

        private string name = string.Empty;

        private string online = string.Empty;

        private int remoteNodeFirmwareVersion = 0;

        private int remoteNodeFpgaVersion = 0;

        private int controllerFirmwareVersion = 0;

        private int controllerFpgaVersion = 0;

        private int enlineFirmwareVersion = 0;

        private int enlineFpgaVersion = 0;

        private string downloadLogs = string.Empty;

 

        public int ControllerFirmwareVersion
        {
            get
            {
                return this.controllerFirmwareVersion;
            }
            set
            {
                this.controllerFirmwareVersion = value;
            }
        }

        public int ControllerFpgaVersion
        {
            get
            {
                return this.controllerFpgaVersion;
            }
            set
            {
                this.controllerFpgaVersion = value;
            }
        }

        public string DownloadLogs
        {
            get
            {
                return this.downloadLogs;
            }
            set
            {
                this.downloadLogs = value;
            }
        }

        public int EnlineFirmwareVersion
        {
            get
            {
                return this.enlineFirmwareVersion;
            }
            set
            {
                this.enlineFirmwareVersion = value;
            }
        }

        public int EnlineFpgaVersion
        {
            get
            {
                return this.enlineFirmwareVersion;
            }
            set
            {
                this.enlineFirmwareVersion = value;
            }
        }

        public string Gateway
        {
            get
            {
                return this.gateway;
            }
            set
            {
                this.gateway = value;
            }
        }

        public System.Guid Guid
        {
            get
            {
                return this.controllerGuid;
            }
            set
            {
                this.controllerGuid = value;
            }
        }

        public string IpAddress
        {
            get
            {
                return this.ipAddress;
            }
            set
            {
                this.ipAddress = value;
            }
        }

        public string IpAssignment
        {
            get
            {
                return this.ipAssignment;
            }
            set
            {
                this.ipAssignment = value;
            }
        }

        public string Mac
        {
            get
            {
                return this.mac;
            }
            set
            {
                this.mac = value;
            }
        }

        public string Name
        {
            get
            {
                return this.name;
            }
            set
            {
                this.name = value;
            }
        }

        public string Online
        {
            get
            {
                return this.online;
            }
            set
            {
                this.online = value;
            }
        }

        public int RemoteNodeFirmwareVersion
        {
            get
            {
                return this.remoteNodeFirmwareVersion;
            }
            set
            {
                this.remoteNodeFirmwareVersion = value;
            }
        }

        public int RemoteNodeFpgaVersion
        {
            get
            {
                return this.remoteNodeFpgaVersion;
            }
            set
            {
                this.remoteNodeFpgaVersion = value;
            }
        }

        public string RemotePort
        {
            get
            {
                return this.remotePort;
            }
            set
            {
                this.remotePort = value;
            }
        }

        public string Subnet
        {
            get
            {
                return this.subnet;
            }
            set
            {
                this.subnet = value;
            }
        }

        public string UnitModel
        {
            get
            {
                return this.unitModel;
            }
            set
            {
                this.unitModel = value;
            }
        }

   

        
    }
}
