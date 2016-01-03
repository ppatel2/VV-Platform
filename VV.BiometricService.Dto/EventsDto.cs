using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Runtime.Serialization;
using System.Collections.ObjectModel;
using System.ComponentModel;
using Newtonsoft.Json;

namespace Entertech.BiometricService.Dto
{
     [DataContract]
     public class EventsDto : INotifyPropertyChanged
     {
          private long _id;
          private long _readerId;
          private long _deviceId;
          private string _readerName;
          private string _readerLocation;
          private DateTime _deviceEventTime;
          private DateTime _systemEventTime;
          private int _logTypeId;
          private string _message;
          private long _userId;
          private long _cardId;
          //private IDictionary<string, string> _properties;
          private Guid _guid { get; set; }
          private string _userName;
          private string _ip;
          private string _user;

          [JsonProperty("Id")]
          [DataMember(Name = "Id")]
          public long Id
          {
               get { return _id; }
               set { _id = value; RaisePropertyChanged("Id"); }
          }

          [JsonProperty("ReaderId")]
          [DataMember(Name = "ReaderId")]
          public long ReaderId
          {
               get { return _readerId; }
               set { _readerId = value; RaisePropertyChanged("ReaderId"); }
          }

          [JsonProperty("DeviceId")]
          [DataMember(Name = "DeviceId")]
          public long DeviceId
          {
               get { return _deviceId; }
               set { _deviceId = value; RaisePropertyChanged("Reader"); }
          }

          [JsonProperty("ReaderName")]
          [DataMember(Name = "ReaderName")]
          public string ReaderName
          {
               get { return _readerName; }
               set { _readerName = value; RaisePropertyChanged("ReaderName"); }
          }

          [JsonProperty("ReaderLocation")]
          [DataMember(Name = "ReaderLocation")]
          public string ReaderLocation
          {
               get { return _readerLocation; }
               set { _readerLocation = value; RaisePropertyChanged("Location"); }
          }

          [JsonProperty("DeviceEventTime")]
          [DataMember(Name = "DeviceEventTime")]
          public DateTime DeviceEventTime
          {
               get { return _deviceEventTime; }
               set { _deviceEventTime = value; RaisePropertyChanged("EventTime"); }
          }

          [JsonProperty("SystemEventTime")]
          [DataMember(Name = "SystemEventTime")]
          public DateTime SystemEventTime
          {
               get { return _systemEventTime; }
               set { _systemEventTime = value; RaisePropertyChanged("SystemEventTime"); }
          }

          [JsonProperty("LogTypeId")]
          [DataMember(Name = "LogTypeId")]
          public int LogTypeId
          {
               get { return _logTypeId; }
               set { _logTypeId = value; RaisePropertyChanged("Status"); }
          }

          [JsonProperty("Message")]
          [DataMember(Name = "Message")]
          public string Message
          {
               get { return _message; }
               set { _message = value; RaisePropertyChanged("Message"); }
          }

          [JsonProperty("UserId")]
          [DataMember(Name = "UserId")]
          public long UserId
          {
               get { return _userId; }
               set { _userId = value; RaisePropertyChanged("User"); }
          }

          [JsonProperty("CardId")]
          [DataMember(Name = "CardId")]
          public long CardId
          {
               get { return _cardId; }
               set { _cardId = value; RaisePropertyChanged("Card"); }
          }

          [JsonProperty("UserName")]
          [DataMember(Name = "UserName")]
          public string UserName
          {
               get { return _userName; }
               set { _userName = value; RaisePropertyChanged("UserName"); }
          }

          [JsonProperty("User")]
          [DataMember(Name = "User")]
          public string User
          {
               get { return _user; }
               set { _user = value; RaisePropertyChanged("User"); }
          }

          [JsonProperty("IP")]
          [DataMember(Name = "IP")]
          public string IP
          {
               get { return _ip; }
               set { _ip = value; RaisePropertyChanged("IP"); }
          }
          /*[JsonConverter(typeof(JsonDictionaryAttribute))]
          [DataMember(Name = "Properties")]
          public IDictionary<string, string> Properties
          {
               get 
               {
                    return _properties; 
               }
               set
               {
                    _properties = value;
                    RaisePropertyChanged("Properties"); 
               }
          }
          */
          [JsonProperty("GUID")]
          [DataMember(Name = "GUID")]
          public Guid GUID
          {
               get { return _guid; }
               set { _guid = value; RaisePropertyChanged("Guid"); }
          }

          public event PropertyChangedEventHandler PropertyChanged;
          public void RaisePropertyChanged(string propertyName)
          {
               PropertyChangedEventHandler handler = PropertyChanged;
               if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
          }
     }
}
