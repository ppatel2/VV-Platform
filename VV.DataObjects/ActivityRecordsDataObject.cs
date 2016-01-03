using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class ActivityRecordsDataObject
    {
       public long  Id { get; set; }
       public long UserId { get; set; }
       public long CardId { get; set; }
       public int LogTypeId { get; set; }
       public string Message { get; set; }
       public long DeviceId { get; set; }
       public DateTime DeviceEventTime { get; set; }
       public DateTime SystemEventTime { get; set; }
       public long ReaderId { get; set; }
       public string ReaderName { get; set; }
       public string ReaderLocation { get; set; }
       public string UserName { get; set; }
       public string Name { get; set; }
       public string IP { get; set; }
      
    }
}
