using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace VV.DataObjects
{

    public class ReadersDataObject
    {
        # region Enumerations
        public enum TypeEnum
        {
            Unknown = -1,
            BioStation = 0,
            BioEntryPlus = 1,
            BioLiteNet = 2,
            DStation = 4,
            BioStationT2 = 6,
            FaceStation = 10,
            BioEntryPlusW = 11,
            BioMini = 9999,
             BioLiteNetGen2 = 203,
             BioStation2 = 208
              
        };
        public enum ProfileEnum
        {
            Default = -1,
            Facebook = 0
        }
        public enum TemplateTypeEnum
        {
            Unknown = -1,
            Suprema = 0,
            ANSI = 1,
            ISO = 2
        }

        public enum WiegandOutputEnum
        {
            Unknown = -1,
            User = 0,
            Card = 1,
        }

        public enum CardFormatEnum
        {
            Unknown = -1,
            Corp1000 = 0,
            Standard_26bit = 1,
            _37bit_H10304 = 2
        }

        public enum CardReadModeEnum
        {
            Unknown = -1,
            User = 0,
            CSN = 1,
        }

        public enum OperationModeEnum
        {
            Unknown = -1,  //note no support for unknown, defaults to NoChange
            NoChange = 0,
            CardPlusBiometric = 1,
            CardPlusBiometricAndBiometricOnly = 2,
            CardOnly = 3,

        }

        public enum FaceOperationModeEnum
        {
            None=0,
            FaceOnly=1, //default
            FaceAndPassword,
            FuncKeyAndFace,
            FuncKeyAndFaceAndPassword,
            FaceAndFuncKey,
            FaceAndPasswordAndFuncKey,
        }

        public enum CardforFaceOperationModeEnum
        {
            None=0, //default
            CardOnly=1,
            CardAndFace,
            CardAndPassword,
            CardAndFaceOrPassword,
            CardAndFaceAndPassword,
        }

        
        public static Dictionary<CardFormatEnum, string> ReaderCardFormatDescriptions = new Dictionary<CardFormatEnum, string> {
              {CardFormatEnum.Unknown, "Default"}
              ,{CardFormatEnum.Corp1000 , "35 Bit Corporate 1000"}
              ,{CardFormatEnum.Standard_26bit,"26 Bit Standard" }
              ,{CardFormatEnum._37bit_H10304, "37 Bit H10304"}
        
         };

        public static Dictionary<TypeEnum, string> ReaderTypeDescriptions = new Dictionary<TypeEnum, string> {
              {TypeEnum.Unknown, "Unknown"}
               ,{TypeEnum.BioStation , "BioStation"}
              ,{TypeEnum.BioEntryPlus,"BioEntry Plus" }
               ,{TypeEnum.BioLiteNet, "BioLite Net"}
               ,{TypeEnum.DStation, "D Station"}
              ,{TypeEnum.BioStationT2,"BioStation T2" }
               ,{TypeEnum.FaceStation, "FaceStation"}         
               ,{TypeEnum.BioEntryPlusW, "BioEntry W"}
               ,{TypeEnum.BioMini, "BioMini"}
               ,{TypeEnum.BioStation2, "BioStation 2"}
               ,{TypeEnum.BioLiteNetGen2, "BioLite Net - BioStar 2.0"}
         };

        public static Dictionary<ProfileEnum, string> ReaderProfileDescriptions = new Dictionary<ProfileEnum, string> {
              {ProfileEnum.Default, "Default"}
              ,{ProfileEnum.Facebook,"Custom" }
         
         };

        public static Dictionary<TemplateTypeEnum, string> ReaderTemplateTypeDescriptions = new Dictionary<TemplateTypeEnum, string>
         {
             {TemplateTypeEnum.Unknown, "Unknown"}
             ,{TemplateTypeEnum.Suprema, "Suprema" }
             ,{TemplateTypeEnum.ANSI , "ANSI"}
             ,{TemplateTypeEnum.ISO , "ISO"}
         };

        public static Dictionary<WiegandOutputEnum, string> WieganOutputDescriptions = new Dictionary<WiegandOutputEnum, string>
         {
              {WiegandOutputEnum.Unknown, "Default"}
              ,{WiegandOutputEnum.Card, "Card #" }
             ,{WiegandOutputEnum.User , "User ID"}
         };

        public static Dictionary<CardReadModeEnum, string> CardReadModeDescriptions = new Dictionary<CardReadModeEnum, string>
         {
             {CardReadModeEnum.Unknown, "Default"}
              ,{CardReadModeEnum.User, "Secure ID" }
             ,{CardReadModeEnum.CSN , "CSN"}
         };

        public static Dictionary<OperationModeEnum, string> OperationModeDescriptions = new Dictionary<OperationModeEnum, string>
         {
             {OperationModeEnum.NoChange , "No Change"}
             ,{OperationModeEnum.CardPlusBiometricAndBiometricOnly, "Card + Biometric/Biometric Only" }
             ,{OperationModeEnum.CardPlusBiometric, "Card + Biometric" }
             ,{OperationModeEnum.CardOnly, "Card Only" }
         };

        public static Dictionary<CardforFaceOperationModeEnum, string> CardforFaceOperationModeDescriptions = new Dictionary<CardforFaceOperationModeEnum, string>
         {
             {CardforFaceOperationModeEnum.None,"None"}
             ,{CardforFaceOperationModeEnum.CardOnly, "Card Only"}
             ,{CardforFaceOperationModeEnum.CardAndFace, "Card + Face"}
             ,{CardforFaceOperationModeEnum.CardAndPassword, "Card + Password"}
             ,{CardforFaceOperationModeEnum.CardAndFaceAndPassword , "Card + Face + Password"}
             ,{CardforFaceOperationModeEnum.CardAndFaceOrPassword, "Card + Face/Password" }
         };
       
        public static Dictionary<FaceOperationModeEnum, string> FaceOperationModeDescriptions = new Dictionary<FaceOperationModeEnum, string>
         {
             {FaceOperationModeEnum.None, "None" }
             ,{FaceOperationModeEnum.FaceOnly, "Face Only"}
             ,{FaceOperationModeEnum.FaceAndPassword, "Face + Password"}
             ,{FaceOperationModeEnum.FuncKeyAndFace, "FuncKey + Face" }
             ,{FaceOperationModeEnum.FuncKeyAndFaceAndPassword, "FuncKey + Face + Password" }
             ,{FaceOperationModeEnum.FaceAndFuncKey, "Face + FuncKey" }
             ,{FaceOperationModeEnum.FaceAndPasswordAndFuncKey, "Face + Password + Func Key" }
         };

        private int? cardReadModeCode;
        private string cardReadMode;
        private string cardFormat;
        private int? cardFormatCode;
        private int? profileCode;
        private string profile;
        private string templateType;
        private int? templateTypeCode;
        private int? typeCode;
        private string type;
        private string wiegandOutput;
        private int? wiegandOutputCode;
        private string operationMode;
        private int? operationModeCode;
        private string faceoperationMode;
        private int? faceoperationModeCode;
        private string cardfaceoperationMode;
        private int? cardfaceoperationModeCode;
        private long timezone;

        public static int? FindCardFormatCode(string descr)
        {
            foreach (var entry in ReaderCardFormatDescriptions)
            {
                // do something with entry.Value or entry.Key
                if (entry.Value.IndexOf(descr.Trim()) > -1)
                    return (int)entry.Key;
            }
            return null;
        }
        public static int? FindReaderType(string descr)
        {

            foreach (var entry in ReaderTypeDescriptions)
            {
                // do something with entry.Value or entry.Key
                if (entry.Value.IndexOf(descr.Trim()) > -1)
                    return (int)entry.Key;
            }
            return null;

        }
        public static int? FindReaderProfileCode(string descr)
        {

            foreach (var entry in ReaderProfileDescriptions)
            {
                if (entry.Value.IndexOf(descr.Trim()) > -1)
                    return (int)entry.Key;
            }
            return null;

        }
        public static int? FindReaderTemplateTypeCode(string descr)
        {

            foreach (var entry in ReaderTemplateTypeDescriptions)
            {
                if (entry.Value.IndexOf(descr.Trim()) > -1)
                    return (int)entry.Key;
            }
            return null;

        }
        public static int? FindWieganOutputCode(string descr)
        {
            foreach (var entry in WieganOutputDescriptions)
            {
                if (entry.Value.IndexOf(descr.Trim()) > -1)
                    return (int)entry.Key;
            }
            return null;
        }
        public static int? FindCardReadModeCode(string descr)
        {
            foreach (var entry in CardReadModeDescriptions)
            {
                // do something with entry.Value or entry.Key
                if (entry.Value.IndexOf(descr.Trim()) > -1)
                    return (int)entry.Key;
            }
            return null;
        }
        public static int? FindOperationModeCode(string descr)
        {
            if (descr == null)
                return null;
            foreach (var entry in OperationModeDescriptions)
            {
                // do something with entry.Value or entry.Key
                if (entry.Value==descr.Trim())
                    return (int)entry.Key;
            }
            return null;
        }

        public static int? FindFaceOperationModeCode(string descr)
        {
            if (descr == null)
                return null;
            foreach (var entry in FaceOperationModeDescriptions)
            {
                // do something with entry.Value or entry.Key
                if (entry.Value == descr.Trim())
                    return (int)entry.Key;
            }
            return null;
        }

        public static int? FindCardFaceOperationModeCode(string descr)
        {
            if (descr == null)
                return null;
            foreach (var entry in CardforFaceOperationModeDescriptions)
            {
                // do something with entry.Value or entry.Key
                if (entry.Value == descr.Trim())
                    return (int)entry.Key;
            }
            return null;
        }
        # endregion

        #region Public Properties
        public string Name { get; set; }
        public string Location { get; set; }

        public int DeviceHandle { get; set; }

        public bool DefaultReader { get; set; }

        public string Profile
        {
            get { return profile; }

            set
            {
                profile = value;
                profileCode = FindReaderProfileCode(value);
            }
        }
        public int? ProfileCode
        {
            get { return profileCode; }
            set
            {
                if (value != null && Enum.IsDefined(typeof(ProfileEnum), value))
                {
                    profileCode = value;
                    profile = ReaderProfileDescriptions[(ProfileEnum)value];
                }
            }
        }
        public bool Online { get; set; }

        public long DeviceID { get; set; }
        public string Type
        {
            get { return type; }
            set
            {
                type = value;
                typeCode = FindReaderType(value);
            }
        }
        public int? TypeCode
        {
            get { return typeCode; }
            set
            {
                if (value != null && Enum.IsDefined(typeof(TypeEnum), value))
                {
                    typeCode = value;
                    type = ReaderTypeDescriptions[(TypeEnum)value];
                }
            }
        }

        public int FacilityCode { get; set; }

        public string CardFormat
        {
            get { return cardFormat; }
            set
            {
                cardFormat = value;
                cardFormatCode = FindCardFormatCode(value);
            }
        }
        public int? CardFormatCode
        {
            get { return cardFormatCode; }
            set
            {
                if (value != null && Enum.IsDefined(typeof(CardFormatEnum), value))
                {
                    cardFormatCode = value;
                    cardFormat = ReaderCardFormatDescriptions[(CardFormatEnum)value];
                }
            }
        }
        public int CardOffset { get; set; }

        public string IPAddress { get; set; }

        public string Gateway { get; set; }

        public string Subnet { get; set; }

        public string ServerIPAddress { get; set; }

        public bool WiegandPassthrough { get; set; }

        public int ServerPort { get; set; }

        public string FirmwareVersion { get; set; }

        public string KernelVersion { get; set; }

        public string ProductName { get; set; }

        public string WiegandOutput
        {
            get { return wiegandOutput; }
            set
            {
                wiegandOutput = value;
                wiegandOutputCode = FindWieganOutputCode(value);
            }
        }
        public int? WiegandOutputCode
        {

            get { return wiegandOutputCode; }
            set
            {
                if (value != null && Enum.IsDefined(typeof(WiegandOutputEnum), value))
                {
                    wiegandOutputCode = value;
                    wiegandOutput = WieganOutputDescriptions[(WiegandOutputEnum)value];
                }
            }
        }

        public string FailCode { get; set; }

        public bool UseServerMode { get; set; }

        public bool UseServerMatching { get; set; }

        public bool TimeSync { get; set; }
        public DateTime? LastSync { get; set; }
        public DateTime? UpdatedAt { get; set; }

        public string CardReadMode
        {
            get { return cardReadMode; }

            set
            {
                cardReadMode = value;
                cardReadModeCode = FindCardReadModeCode(value);
            }
        }
        public int? CardReadModeCode
        {
            get { return cardReadModeCode; }
            set
            {
                if (value != null && Enum.IsDefined(typeof(CardReadModeEnum), value))
                {
                    cardReadModeCode = value;
                    cardReadMode = CardReadModeDescriptions[(CardReadModeEnum)value];
                }
            }
        }

        public string OperationMode
        {
            get { return operationMode; }

            set
            {
                operationMode = value;
                operationModeCode = FindOperationModeCode(value);
            }
        }
        public int? OperationModeCode
        {
            get { return operationModeCode; }
            
            set
            {
                if (value != null && Enum.IsDefined(typeof(OperationModeEnum), value))
                {
                    operationModeCode = value;
                    operationMode = OperationModeDescriptions[(OperationModeEnum)value];
                }
            }
        }

        public string FaceOperationMode
        {
            get { return faceoperationMode; }

            set
            {
                faceoperationMode = value;
                faceoperationModeCode = FindFaceOperationModeCode(value);
            }
        }
        public int? FaceOperationModeCode
        {
            get { return faceoperationModeCode; }

            set
            {
                if (value != null && Enum.IsDefined(typeof(OperationModeEnum), value))
                {
                    faceoperationModeCode = value;
                    faceoperationMode = FaceOperationModeDescriptions[(FaceOperationModeEnum)value];
                }
            }
        }

        public string CardFaceOperationMode
        {
            get { return faceoperationMode; }

            set
            {
                cardfaceoperationMode = value;
                cardfaceoperationModeCode = FindCardFaceOperationModeCode(value);
            }
        }
        public int? CardFaceOperationModeCode
        {
            get { return cardfaceoperationModeCode; }

            set
            {
                if (value != null && Enum.IsDefined(typeof(OperationModeEnum), value))
                {
                    cardfaceoperationModeCode = value;
                    cardfaceoperationMode = CardforFaceOperationModeDescriptions[(CardforFaceOperationModeEnum)value];
                }
            }
        }

        public string TemplateType
        {
            get { return templateType; }
            set
            {
                templateType = value;
                templateTypeCode = FindReaderTemplateTypeCode(value);
            }
        }
        public int? TemplateTypeCode
        {
            get { return templateTypeCode; }
            set
            {
                if (value != null && Enum.IsDefined(typeof(TemplateTypeEnum), value))
                {
                    templateTypeCode = value;
                    templateType = ReaderTemplateTypeDescriptions[(TemplateTypeEnum)value];
                }
            }
        }
        public bool DHCP { get; set; }

        public int ID { get; set; }

        //public void UpdateCodes()
        //{
        //    this.CardFormat = this.cardFormat;
        //    this.CardReadMode = this.cardReadMode;
        //    this.Profile = this.profile;
        //    this.TemplateType = this.templateType;
        //    this.Type = this.type;
        //    this.WiegandOutput = this.wiegandOutput;
        //}
        public bool ReadStatus { get; set; }
        public bool UpdateStatus { get; set; }

        public long TimeZone
        {
            get { return timezone; }
            set
            {
                timezone = value;
            }
        }
        # endregion
    }
}
