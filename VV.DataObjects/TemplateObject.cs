using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Media.Imaging;
using System.Runtime.Serialization;

namespace VV.DataObjects
{
    [DataContract]
     public class TemplateObject 
     {  
          [DataMember ]
          public int Id { get; set; }
          [DataMember]
          public int QualityScore { get; set; }
          [DataMember]
          public byte[] Data { get; set; }
          [DataMember]
          public long Checksum { get; set; }
          [DataMember]
          public BitmapSource Representation { get; set; }
          public BitmapSource ThumbnailRepresentation { get; set; }
          [DataMember]
          public int FingerIndex { get; set;  }
          [DataMember]
          public int UserID { get; set;  }
          [DataMember]
          public DateTime? UpdatedAt { get; set; }

     }
}
