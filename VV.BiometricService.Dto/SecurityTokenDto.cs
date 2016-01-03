using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Newtonsoft.Json;
using System.Runtime.Serialization;
using System.ComponentModel;
using Newtonsoft.Json.Converters;

namespace Entertech.BiometricService.Dto
{
     public class SecurityTokenDto
     {
          private int _id;
          private int _userId;
          private string _userName;
          private string _password;
          private string _level;
          private byte[] _template;
          private List<string> _locations;
          private string _lastUsedIP;
          private string _lastUpdatedBy;
          //private DateTime _lastUsed;
          
          [JsonProperty("Id")]
          [DataMember(Name = "Id")]
          public int Id 
          { 
               get { return _id; } 
               set { _id = value; RaisePropertyChanged("Id"); } 
          }


          [JsonProperty("UID")]
          [DataMember(Name = "UID")]
          public int UserID
          {
               get { return _userId; }
               set { _userId = value; RaisePropertyChanged("UserId"); }
          }

          [JsonProperty("UserName")]
          [DataMember(Name = "UserName")]
          public string UserName
          {
               get { return _userName; }
               set { _userName = value; RaisePropertyChanged("UserName"); }
          }

          [JsonProperty("Password")]
          [DataMember(Name = "Password")]
          public string Password
          {
               get { return _password; }
               set { _password = value; RaisePropertyChanged("Password"); }
          }
          
          [JsonProperty("Level")]
          [DataMember(Name = "Level")]
          public string Level
          {
               get { return _level; }
               set { _level = value; RaisePropertyChanged("Level"); }
          }
          
          [JsonProperty("Template")]
          [DataMember(Name = "Template")]
          public byte[] Template
          {
               get { return _template; }
               set { _template = value; RaisePropertyChanged("Template"); }
          }
          
          [JsonProperty("Locations")]
          [DataMember(Name = "Locations")]
          public List<string> Locations
          {
               get { return _locations; }
               set { _locations = value; RaisePropertyChanged("Locations"); }
          }

          [JsonProperty("LastUsedIP")]
          [DataMember(Name = "LastUsedIP")]
          public string LastUsedIP
          {
               get { return _lastUsedIP; }
               set { _lastUsedIP = value; RaisePropertyChanged("LastUsedIP"); }
          }

          [JsonProperty("UpdatedBy")]
          [DataMember(Name = "UpdatedBy")]
          public string UpdatedBy
          {
               get { return _lastUpdatedBy; }
               set { _lastUpdatedBy = value; RaisePropertyChanged("UpdatedBy"); }
          }

          public event PropertyChangedEventHandler PropertyChanged;
          public void RaisePropertyChanged(string propertyName)
          {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
          }
     }
}
