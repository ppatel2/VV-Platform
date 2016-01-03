using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace Entertech.BiometricService.Dto
{
     [DataContract(IsReference = true)]
     public class CardDto
     {
          private int _id;
          private long _externalId;
          private long _badgeNumber;
          private long _facilityCode;
          private int _priority;
          private UserDto _user;
          private bool _isBypass;
          private bool _isActive;
          private string _PIN;
          private Dictionary<string, string> _properties;
          private List<string> _locations;
          private string _externalId1;

          [DataMember]
          public int Id
          {
               get { return _id; }
               set { _id = value; RaisePropertyChanged("Id"); }
          }
          
          [DataMember]
          public long ExternalId
          {
               get { return _externalId; }
               set { _externalId = value; RaisePropertyChanged("ExternalId"); }
          }
          
          [DataMember]
         public string ExternalId1
          {
              get { return _externalId1;  }
              set { _externalId1 = value; RaisePropertyChanged("ExternalId1"); }
          }
          
          [DataMember]
          public long BadgeNumber
          {
               get { return _badgeNumber; }
               set { _badgeNumber = value; RaisePropertyChanged("BadgeNumber"); }
          }

          [DataMember]
          public long FacilityCode
          {
               get { return _facilityCode; }
               set { _facilityCode = value; RaisePropertyChanged("FaciityCode"); }
          }

          [DataMember]
          public int Priority
          {
               get { return _priority; }
               set { _priority = value; RaisePropertyChanged("Priority"); }
          }

          [DataMember]
          public UserDto User
          {
               get { return _user; }
               set { _user = value; RaisePropertyChanged("User"); }
          }

          [DataMember]
          public bool IsBypass
          {
               get { return _isBypass; }
               set { _isBypass = value; RaisePropertyChanged("IsBypass"); }
          }

          [DataMember]
          public bool IsActive
          {
               get { return _isActive; }
               set { _isActive = value; RaisePropertyChanged("IsActive"); }
          }

          [DataMember]
          public string PIN
          {
               get { return _PIN; }
               set { _PIN = value; RaisePropertyChanged("PIN"); }
          }

          [DataMember]
          public Dictionary<string, string> Properties
          {
               get { return _properties; }
               set { _properties = value; RaisePropertyChanged("Properties"); }
          }

          [DataMember]
          public List<string> Locations
          {
               get { return _locations; }
               set { _locations = value; RaisePropertyChanged("Locations"); }
          }

          public event PropertyChangedEventHandler PropertyChanged;
          public void RaisePropertyChanged(string propertyName)
          {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
          }
     }
}
