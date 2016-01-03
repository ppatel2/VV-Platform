using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace Entertech.BiometricService.Dto
{
	[DataContract(IsReference = true)]
	public class BiometricReaderDto : INotifyPropertyChanged
	{
		private int _deviceHandle;
		private int _deviceId;
		private string _ipAddress;
          private string _serverIpAddress;
          private string _readerName;
          private string _location;
          private int _port;
          private bool _defaultReader;
          private int _deviceType;
	      private int _id;
          private long _cardOffset;
          private long _facilityCode;
          private bool _wiegandPassthrough;
          private bool _online;
          private int _profilecode;
          private string _firmwareversion;
          private string _kernelversion;
          private string _gateway;
          private string _subnet;
          private bool _DHCP;
          private bool _TimeSync;
          private int _cardreadmodecode;
          private string _failcode;
          private int _wiegandoutputcode;  //BS2WiegandConfigType
          private int _cardformatcode;
          private int _operationmodecode;


          private Dictionary<string, string> _properties;
	    
          [DataMember]
          public int Id
	     {
	          get { return _id; }
	          set { _id = value; RaisePropertyChanged("Id"); }
	     }
          
          [DataMember]
          public int Port
          {
               get { return _port; }
               set { _port = value; RaisePropertyChanged("Port"); }
          }
	     
          [DataMember]
		public int DeviceHandle
		{
			get { return _deviceHandle; }
			set { _deviceHandle = value; RaisePropertyChanged("DeviceHandle"); }
		}

          [DataMember]
          public bool DefaultReader
          {
               get { return _defaultReader; }
               set { _defaultReader = value; RaisePropertyChanged("DefaultReader"); }
          }

          [DataMember]
          public bool WiegandPassthrough
          {
               get { return _wiegandPassthrough; }
               set { _wiegandPassthrough = value; RaisePropertyChanged("WiegandPassthrough"); }
          }
          
          [DataMember]
          public bool Online
          {
               get { return _online; }
               set { _online = value; RaisePropertyChanged("Online"); }
          }

		[DataMember]
		public int DeviceId
		{
			get { return _deviceId; }
			set { _deviceId = value; RaisePropertyChanged("DeviceId"); }
		}

		[DataMember]
		public string IpAddress
		{
			get { return _ipAddress; }
			set { _ipAddress = value; RaisePropertyChanged("IpAddress"); }
		}

          [DataMember]
          public string ServerIpAddress 
          {
               get { return _serverIpAddress; }
               set { _serverIpAddress = value; RaisePropertyChanged("ServerIpAddress"); }
          }

          [DataMember]
          public string ReaderName
          {
               get { return _readerName; }
               set { _readerName = value; RaisePropertyChanged("ReaderName"); }
          }
          
          [DataMember]
          public string Location
          {
               get { return _location; }
               set { _location = value; RaisePropertyChanged("Location"); }
          }
          
		[DataMember]
		public int DeviceType
		{
			get { return _deviceType; }
			set { _deviceType = value; RaisePropertyChanged("DeviceType"); }
		}
          
          [DataMember]
          public long FacilityCode
          {
               get { return _facilityCode; }
               set { _facilityCode = value; RaisePropertyChanged("FacilityCode"); }
          }

          [DataMember]
          public long CardOffset
          {
               get { return _cardOffset; }
               set { _cardOffset = value; RaisePropertyChanged("CardOffset"); }
          }

        [DataMember]
        public Dictionary<string, string> Properties
        {
            get { return _properties; }
            set { _properties = value; RaisePropertyChanged("Properties"); }
        }
        [DataMember]
        public bool UseServerMode
        {
            get { return _useServerMode; }
            set { _useServerMode = value; RaisePropertyChanged("UseServerMode"); }
        }
        public bool useServerMatching
        {
            get { return _useServerMatching; }
            set { _useServerMatching = value; RaisePropertyChanged("UseServerMatching"); }
        }
        public bool DHCP
        {
            get { return _DHCP; }
            set { _DHCP = value; RaisePropertyChanged("DHCP"); }
        }

        public bool TimeSync
        {
            get { return _TimeSync; }
            set { _TimeSync = value; RaisePropertyChanged("TimeSync"); }
        }

		public event PropertyChangedEventHandler PropertyChanged;
        private bool _useServerMode;
        private bool _useServerMatching;

        public void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

        [DataMember]
        public int ProfileCode
        {
            get { return _profilecode; }
            set { _profilecode = value; RaisePropertyChanged("ProfileCode"); }
         }

        [DataMember]
        public string FirmwareVersion
        {
            get {return _firmwareversion;}
            set { _firmwareversion=value; RaisePropertyChanged("FirmwareVersion");}
         }

         [DataMember]
        public  string KernelVersion 
        {
            get{return _kernelversion;}
            set{ _kernelversion=value; RaisePropertyChanged("KernelVersion"); }
        }

         [DataMember]
        public string Gateway 
        { 
            get{ return _gateway;}
            set{ _gateway=value;RaisePropertyChanged("GateWay");}
        }

        [DataMember]
        public  string Subnet 
        { 
            get{return _subnet;}
            set { _subnet = value; RaisePropertyChanged("Subnet"); }
        }

        [DataMember]
        public int CardReadModeCode
        {
            get { return _cardreadmodecode; }
            set { _cardreadmodecode = value; RaisePropertyChanged("CardReadModeCode"); }
        }
        [DataMember]
        public string FailCode
        {
            get { return _failcode; }
            set { _failcode = value; RaisePropertyChanged("FailCode"); }
        }

        [DataMember]
        public int WiegandOutputCode
        {
            get { return _wiegandoutputcode; }
            set { _wiegandoutputcode = value; RaisePropertyChanged("WiegandOutputCode"); }
        }  

        [DataMember]
        public int CardFormatCode
        {
            get { return _cardformatcode; }
            set { _cardformatcode = value; RaisePropertyChanged("CardFormatCode"); }
        }  

        
        [DataMember]
        public int OperationModeCode
        {
            get { return _operationmodecode; }
            set { _operationmodecode = value; RaisePropertyChanged("OperationModeCode"); }
        }  
     }

}
