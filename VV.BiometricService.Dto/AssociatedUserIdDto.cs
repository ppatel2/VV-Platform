using System.Runtime.Serialization;
using System.ComponentModel;
using System.Collections.Generic;

namespace Entertech.BiometricService.Dto
{
     [DataContract(IsReference = true)]
     public class AssociatedUserIdDto
     {
          private int _id;
          private string _externalId;
          
          [DataMember]
          public int Id
          {
               get { return _id; }
               set { _id = value; RaisePropertyChanged("Id"); }
          }

          [DataMember]
          public string ExternalId
          {
               get { return _externalId; }
               set { _externalId = value; RaisePropertyChanged("ExternalId"); }
          }

          public event PropertyChangedEventHandler PropertyChanged;
          public void RaisePropertyChanged(string propertyName)
          {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
          }

     }
}
