using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Entertech.BiometricService.Dto
{
     [DataContract(IsReference = true)]
     public class UserDto : INotifyPropertyChanged
     {
          private int _id;
          private int _associatedUserId;
          private string _name;
          private ObservableCollection<BiometricFingerprintTemplateDto> _templates;
          private ObservableCollection<CardDto> _cards;
          private ObservableCollection<BiometricReaderDto> _biometricReaders;
          private string _password;
          private bool _isAdministrator;
          private bool _isDeviceAdministrator;
          private string _devicePassword;
          private Dictionary<string, string> _properties;
          private AssociatedUserIdDto _associatedUserIdDto;
          private byte[] _userImage;
          private ObservableCollection<string> _locations;
          private string _externalId;

          [DataMember]
          public int Id
          {
               get { return _id; }
               set { _id = value; RaisePropertyChanged("Id"); }
          }
          [DataMember]
          public string ExternalID
          {
              get { return _externalId; }
              set { _externalId = value; RaisePropertyChanged("ExternalID"); }
          }
          [DataMember]
          public int AssociatedUserId
          {
               get { return _associatedUserId; }
               set { _associatedUserId = value; RaisePropertyChanged("AssociatedUserId"); }
          }

          [DataMember]
          public AssociatedUserIdDto AssociatedUserIdObject
          {
               get { return _associatedUserIdDto; }
               set { _associatedUserIdDto = value; RaisePropertyChanged("AssociatedUserIdObject"); }
          }

          [DataMember]
          public string Name
          {
               get { return _name; }
               set { _name = value; RaisePropertyChanged("Name"); }
          }

          [DataMember]
          public ObservableCollection<BiometricFingerprintTemplateDto> Templates
          {
               get { return _templates; }
               set { _templates = value; RaisePropertyChanged("Templates"); }
          }

          [DataMember]
          public ObservableCollection<CardDto> Cards
          {
               get { return _cards; }
               set { _cards = value; RaisePropertyChanged("Cards"); }
          }

          [DataMember]
          public string Password
          {
               get { return _password; }
               set { _password = value; RaisePropertyChanged("Password"); }
          }

          [DataMember]
          public bool IsAdministrator
          {
               get { return _isAdministrator; }
               set { _isAdministrator = value; RaisePropertyChanged("IsAdministrator"); }
          }

          [DataMember]
          public bool IsDeviceAdministrator
          {
               get { return _isDeviceAdministrator; }
               set { _isDeviceAdministrator = value; RaisePropertyChanged("IsDeviceAdministrator"); }
          }

          [DataMember]
          public string DevicePassword
          {
               get { return _devicePassword; }
               set { _devicePassword = value; RaisePropertyChanged("DevicePassword"); }
          }

          [DataMember]
          public ObservableCollection<BiometricReaderDto> BiometricReaders
          {
               get { return _biometricReaders; }
               set { _biometricReaders = value; RaisePropertyChanged("BiometricReaders"); }
          }

          [DataMember]
          public Dictionary<string, string> Properties
          {
               get { return _properties; }
               set { _properties = value; RaisePropertyChanged("Properties"); }
          }

          [DataMember]
          public byte[] UserImage
          {
               get { return _userImage; }
               set { _userImage = value; RaisePropertyChanged("UserImage"); }
          }

          [DataMember]
          public ObservableCollection<string> Locations
          {
               get { return _locations; }
               set { _locations = value; RaisePropertyChanged("Locations"); }
          }

          public UserDto()
          {
               Templates = new ObservableCollection<BiometricFingerprintTemplateDto>();
               Cards = new ObservableCollection<CardDto>();
               BiometricReaders = new ObservableCollection<BiometricReaderDto>();
          }

          //[OnDeserialized()]
          //internal virtual void OnDeserializeMethod(StreamingContext context)
          //{
          //    if (Templates != null)
          //        Templates = Templates.ToList();
          //}

          public event PropertyChangedEventHandler PropertyChanged;
          public void RaisePropertyChanged(string propertyName)
          {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
          }
     }
}