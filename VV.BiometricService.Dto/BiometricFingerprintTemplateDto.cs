using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Entertech.BiometricService.Dto
{
	[DataContract(IsReference=true)]
    public class BiometricFingerprintTemplateDto : INotifyPropertyChanged
    {
		[DataContract]
		public enum Finger
		{
			[EnumMember]
			Unknown = 0,
			[EnumMember]
			LeftPinky = 1,
			[EnumMember]
			LeftRing = 2,
			[EnumMember]
			LeftMiddle = 3,
			[EnumMember]
			LeftIndex = 4,
			[EnumMember]
			LeftThumb = 5,
			[EnumMember]
			RightThumb = 6,
			[EnumMember]
			RightIndex = 7,
			[EnumMember]
			RightMiddle = 8,
			[EnumMember]
			RightRing = 9,
			[EnumMember]
			RightPinky = 10
		};

		private int _id;
		private Finger _fingerIndex;
		private byte[] _data;
		private int _qualityScore;
		private UserDto _user;
	    private bool _storeOnCard;


	    [DataMember]
        public int Id {
			get { return _id; }
			protected set { _id = value; RaisePropertyChanged("Id"); }
		}

		[DataMember]
		public Finger FingerIndex
		{
			get { return _fingerIndex; }
			set { _fingerIndex = value; RaisePropertyChanged("FingerIndex"); }
		}
		
		[DataMember]
		public byte[] Data
		{
			get { return _data; }
			set { _data = value; RaisePropertyChanged("Data"); }
		}

		[DataMember]
		public int QualityScore
		{
			get { return _qualityScore; }
			set { _qualityScore = value; RaisePropertyChanged("QualityScore"); }
		}

		[DataMember]
		public UserDto User
		{
			get { return _user; }
			set { _user = value; RaisePropertyChanged("User"); }
		}

        [DataMember]
        public bool StoreOnCard
        {
            get { return _storeOnCard; }
            set { _storeOnCard = value; RaisePropertyChanged("StoreOnCard");}
        }

	    public event PropertyChangedEventHandler PropertyChanged;
		public void RaisePropertyChanged(string propertyName)
		{
			PropertyChangedEventHandler handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}
    }
}
