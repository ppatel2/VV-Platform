using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
     public class FingerDataObject
     {
         public enum FingerCode
         {
             Unknown = -1,

             LeftThumb = 0,
             LeftIndexFinger = 1,
             LeftMiddleFinger = 2,
             LeftRingFinger = 3,
             LeftLittleFinger = 4,

             RightThumb = 5,
             RightIndexFinger = 6,
             RightMiddleFinger = 7,
             RightRingFinger = 8,
             RightLittleFinger = 9
         };
         public static Dictionary<FingerCode, string> FingerCodeDescriptions = new Dictionary<FingerCode, string> {
         
              {FingerCode.LeftThumb,"Left Thumb" }
              ,{FingerCode.LeftIndexFinger, "Left Index Finger"}
              ,{FingerCode.LeftMiddleFinger,"Left Middle Finger" }
              ,{FingerCode.LeftRingFinger, "Left Ring Finger"}
              ,{FingerCode.LeftLittleFinger,"Left Little Finger" }

              ,{FingerCode.RightThumb, "Right Thumb"}
              ,{FingerCode.RightIndexFinger, "Right Index Finger"}
              ,{FingerCode.RightMiddleFinger,"Right Middle Finger" } 
              ,{FingerCode.RightRingFinger, "Right Ring Finger"}
              ,{FingerCode.RightLittleFinger,"Right Little Finger"}   
         };
         public static FingerCode FindFinger(string fingerStr)
         {

             foreach (KeyValuePair<FingerCode, string> entry in FingerCodeDescriptions)
             {
                 // do something with entry.Value or entry.Key
                 if ( entry.Value.IndexOf (fingerStr.Trim()) > -1) 
                     return entry.Key; 
             }
             return FingerCode.Unknown;

         }
          public int Id { get; set; }
          public string FingerIndex { get; set; }
          public DateTime? UpdatedAt { get; set; }

          public ObservableCollection<TemplateObject> Templates { get; set; }

 
     }
}
