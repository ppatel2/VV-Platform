using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Media.Imaging;

namespace VV.Web.Server.HelperClasses
{
    public class BitmapImageConverter
    {
        public static string GetBase64Representation(BitmapImage image)
        {
            byte[] data;

            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                data = ms.ToArray();
            }

            return Convert.ToBase64String(data);
        }

        public static String GetPNGBase64Representation(BitmapImage image)
        {
            byte[] data;

            BitmapEncoder encoder = new BmpBitmapEncoder();
            encoder.Frames.Add(BitmapFrame.Create(image));
            using (MemoryStream ms = new MemoryStream())
            {
                encoder.Save(ms);
                System.Drawing.Bitmap bitmap = new System.Drawing.Bitmap(ms);

                bitmap.Save(ms, ImageFormat.Png);
                data = ms.ToArray();
            }
            return Convert.ToBase64String(data);
        }

        public static void savePNGImage(string base64)
        {
            byte[] data = Convert.FromBase64String(base64);
            using (MemoryStream stream = new MemoryStream(data))
            {
                string outputPath = null;

                string fileName = Path.GetRandomFileName();

                outputPath = Path.Combine(System.IO.Path.GetTempPath(), fileName);
                outputPath = outputPath + ".png";

                using (Image image = Image.FromStream(stream))
                {
                    image.Save(outputPath, ImageFormat.Png);
                }
                //    BitmapImage image = new BitmapImage();
                //image.BeginInit();
                //image.StreamSource = stream;
                //image.EndInit();

                //string outputPath = null;

                //string fileName = Path.GetRandomFileName();

                //outputPath = Path.Combine(System.IO.Path.GetTempPath(), fileName);
                //outputPath = outputPath + ".bmp";

                //using (var fs = new FileStream(outputPath, FileMode.Create))
                //{
                //    BitmapEncoder encoder = new BmpBitmapEncoder();
                //    encoder.Frames.Add(BitmapFrame.Create(image));
                //    encoder.Save(fs);
                //}
            }
        }

        
        public static void saveBitmapImage(string base64)
        {
            byte[] data = Convert.FromBase64String(base64);
            using (MemoryStream stream = new MemoryStream(data))
            {
                BitmapImage image = new BitmapImage();
                image.BeginInit();
                image.StreamSource = stream;
                image.EndInit();

                string outputPath = null;

                string fileName = Path.GetRandomFileName();

                outputPath = Path.Combine(System.IO.Path.GetTempPath(), fileName);
                outputPath = outputPath + ".bmp";

                using (var fs = new FileStream(outputPath, FileMode.Create))
                {
                    BitmapEncoder encoder = new BmpBitmapEncoder();
                    encoder.Frames.Add(BitmapFrame.Create(image));
                    encoder.Save(fs);
                }
            }
        }

        public static BitmapImage GetTemplateImage(byte[] data)
        {
            try
            {
                var templateClass = new TemplateRepresentation();
                //var pathToImage = templateClass.TemplateDataToPath(template.Data);
                string pathToImage = templateClass.SaveTemplateToImageFile(data);
                if (!String.IsNullOrWhiteSpace(pathToImage))
                {
                    BitmapImage src = new BitmapImage();
                    src.BeginInit();
                    src.CreateOptions = BitmapCreateOptions.IgnoreImageCache;
                    src.UriSource = new Uri(pathToImage, UriKind.Relative);
                    src.CacheOption = BitmapCacheOption.OnLoad;
                    src.EndInit();
                    src.Freeze();
                    try
                    {
                        File.Delete(pathToImage);
                    }
                    catch
                    {
                        // ok,this is a temporary file
                    }
                    return src;
                }
                else return null;
            }
            catch
            {
                throw;
            }
        }
    }
}
