using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using VV.DataObjects;
namespace VV.DataObjects
{
    public class ReaderDescriptionsDataObject
    {
        public Dictionary<ReadersDataObject.CardFormatEnum, string> ReaderCardFormatDescriptions = ReadersDataObject.ReaderCardFormatDescriptions ; 
        public  Dictionary<ReadersDataObject.TypeEnum, string> ReaderTypeDescriptions = ReadersDataObject.ReaderTypeDescriptions;
        public  Dictionary<ReadersDataObject.ProfileEnum, string> ReaderProfileDescriptions = ReadersDataObject.ReaderProfileDescriptions;
        public Dictionary<ReadersDataObject.TemplateTypeEnum, string> ReaderTemplateTypeDescriptions = ReadersDataObject.ReaderTemplateTypeDescriptions;
        public Dictionary<ReadersDataObject.WiegandOutputEnum, string> WieganOutputDescriptions = ReadersDataObject.WieganOutputDescriptions;
        public  Dictionary<ReadersDataObject.CardReadModeEnum, string> CardReadModeDescriptions = ReadersDataObject.CardReadModeDescriptions;
        public Dictionary<ReadersDataObject.OperationModeEnum, string> CardOperationModeDescriptions = ReadersDataObject.OperationModeDescriptions;
        public Dictionary<ReadersDataObject.FaceOperationModeEnum, string> FaceOperationModeDescriptions = ReadersDataObject.FaceOperationModeDescriptions;
        public Dictionary<ReadersDataObject.CardforFaceOperationModeEnum, string> CardFaceOperationModeDescriptions = ReadersDataObject.CardforFaceOperationModeDescriptions;
    }
}
