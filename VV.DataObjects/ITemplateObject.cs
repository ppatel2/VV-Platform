using System;
namespace VV.DataObjects
{
    interface ITemplateObject
    {
        long Checksum { get; set; }
        byte[] Data { get; set; }
        int FingerIndex { get; set; }
        int Id { get; set; }
        int QualityScore { get; set; }
        System.Windows.Media.Imaging.BitmapSource Representation { get; set; }
        System.Windows.Media.Imaging.BitmapSource ThumbnailRepresentation { get; set; }
        DateTime? UpdatedAt { get; set; }
        int UserID { get; set; }
    }
}
