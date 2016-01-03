using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class DigitusDeviceDataObject
    {
        private Guid deviceGuid = new Guid("00000000-0000-0000-0000-000000000000");

        private Guid controllerGuid = new Guid("00000000-0000-0000-0000-000000000000");

        private int nodeSerialNumber = 0;

        private int nodeDeviceNumber = 0;

        private int type = 0;

        private string name = string.Empty;

        private Guid groupGuid = new Guid("00000000-0000-0000-0000-000000000000");

        private string approved = "N";

        private string doorForced = "Y";

        private string tamperAlarm = "N";

        private string forcedLatchAlarm = "N";

        private int entryDelay = 5;

        private int exitDelay = 5;

        private int proppedDelay = 0;

        private string proppedSeconds = "N";

        private int? securityLevel = new int?(3);

        private string auth1Unlocks2 = "N";

        private string auth2Unlocks1 = "N";

        private byte status1 = 0;

        private byte status2 = 0;

        private byte status3 = 0;

  

        public string Approved
        {
            get
            {
                return this.approved;
            }
            set
            {
                this.approved = value;
            }
        }

        public string Auth1Unlocks2
        {
            get
            {
                return this.auth1Unlocks2;
            }
            set
            {
                this.auth1Unlocks2 = value;
            }
        }

        public string Auth2Unlocks1
        {
            get
            {
                return this.auth2Unlocks1;
            }
            set
            {
                this.auth2Unlocks1 = value;
            }
        }

        public Guid ControllerGuid
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

        public Guid DeviceGuid
        {
            get
            {
                return this.deviceGuid;
            }
            set
            {
                this.deviceGuid = value;
            }
        }

        public string DoorForced
        {
            get
            {
                return this.doorForced;
            }
            set
            {
                this.doorForced = value;
            }
        }

        public int EntryDelay
        {
            get
            {
                return this.entryDelay;
            }
            set
            {
                this.entryDelay = value;
            }
        }

        public int ExitDelay
        {
            get
            {
                return this.exitDelay;
            }
            set
            {
                this.exitDelay = value;
            }
        }

        public string ForcedLatchAlarm
        {
            get
            {
                return this.forcedLatchAlarm;
            }
            set
            {
                this.forcedLatchAlarm = value;
            }
        }

        public Guid GroupGuid
        {
            get
            {
                return this.groupGuid;
            }
            set
            {
                this.groupGuid = value;
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

        public int NodeDeviceNumber
        {
            get
            {
                return this.nodeDeviceNumber;
            }
            set
            {
                this.nodeDeviceNumber = value;
            }
        }

        public int NodeSerialNumber
        {
            get
            {
                return this.nodeSerialNumber;
            }
            set
            {
                this.nodeSerialNumber = value;
            }
        }

        public int ProppedDelay
        {
            get
            {
                return this.proppedDelay;
            }
            set
            {
                this.proppedDelay = value;
            }
        }

        public string ProppedSeconds
        {
            get
            {
                return this.proppedSeconds;
            }
            set
            {
                this.proppedSeconds = value;
            }
        }

        public int? SecurityLevel
        {
            get
            {
                return this.securityLevel;
            }
            set
            {
                this.securityLevel = value;
            }
        }

        public byte Status1
        {
            get
            {
                return this.status1;
            }
            set
            {
                this.status1 = value;
            }
        }

        public byte Status2
        {
            get
            {
                return this.status2;
            }
            set
            {
                this.status2 = value;
            }
        }

        public byte Status3
        {
            get
            {
                return this.status3;
            }
            set
            {
                this.status3 = value;
            }
        }

        public string TamperAlarm
        {
            get
            {
                return this.tamperAlarm;
            }
            set
            {
                this.tamperAlarm = value;
            }
        }

        public int Type
        {
            get
            {
                return this.type;
            }
            set
            {
                this.type = value;
            }
        }
  
    }
}
