using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{
    public class FaceTemplateObject
    {
        public const int MAX_NO_FACE_TEMPLATE_ENTRIES = 25;
//        public int Id { get; protected set; }
        public int Id { get; set; }
        public int nType { get; set; }  //max of 5
        public int nIndex { get; set; } //max of 25, only 20 get used
        public byte[] Data { get; set; }
        public int UserID { get; set;  }
        public DateTime? CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public string CreatedBy { get; set; }
        public string UpdatedBy { get; set; }
        public long Checksum { get; set; }
        public string EnterpriseLevel { get; set; }
          
        public void CalculateChecksum()
        {
            Checksum = 0;
            if (Data != null && Data.Length > 0)
            {
                for (int i = 0; i < Data.Length; i++)
                    Checksum += Data[i];
            }
            else
                Checksum = 0;
        }
    }
     public class FaceDataObject
     {
         public const int MAX_FACE_TEMPLATE = 5;
         public int Id { get; set; }

         // public ObservableCollection<TemplateObject> Templates { get; set; }

        public byte[] ImageData { get; set; }
        public int nIndex { get; set; } //max of 5
        public List<FaceTemplateObject> TemplateData { get; set; }       
        public  int QualityScore { get; set; }
		public int UserID { get; set;  }
		public  DateTime? CreatedAt { get; set; }
		public  DateTime? UpdatedAt { get; set; }
		public  string CreatedBy { get; set; }
		public  string UpdatedBy { get; set; }

        public  string EnterpriseLevel { get; set; }

        public FaceDataObject()
        {
            TemplateData = new List<FaceTemplateObject>();
            for (int x = 0; x < FaceTemplateObject.MAX_NO_FACE_TEMPLATE_ENTRIES; x++)
                TemplateData.Add(new FaceTemplateObject());
        }
     }
}
