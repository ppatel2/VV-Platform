using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace VV.Web.Server.HelperClasses
{


    public class TemplateRepresentation
    {
        [DllImport("FPTemplateAPI.dll", CharSet = CharSet.Ansi, CallingConvention = CallingConvention.StdCall, EntryPoint = "SaveTemplateImageAsBMP")]
        public static extern bool SaveTemplateImageAsBMP(byte[] pTemplate /*input*/ , string pFilePath /*file name*/, bool bColor);

        private static byte[] data;

        public TemplateRepresentation()
        {
            data = new byte[1];
        }

        //public string TemplateDataToPath(byte[] templateData)
        //{
        //    data = templateData;
        //    if (templateData != null)
        //    {
        //        Image imageData;
        //        MemoryStream ms = new MemoryStream();

        //        var tmp = new HelperClasses.TempFile();
        //        try { File.Delete(tmp.Path); }
        //        catch (Exception e)
        //        {
        //            throw e;
        //        } // best effort

        //        bool result = SaveTemplateImageAsBMP(templateData, tmp.Path, true);
        //        if (!result)
        //        {
        //            throw new Exception(string.Format("Failed to get Template Representation. {0}", result));
        //        }
        //        try
        //        {
        //            using (FileStream stream = new FileStream(tmp.Path, FileMode.Open, FileAccess.Read))
        //            {
        //                imageData = Image.FromStream(stream);
        //            }

        //        }
        //        catch   //(Exception e)
        //        {
        //            //something went wrong, return no data
        //            imageData = null;
        //            //need to log issue
        //        }
        //        if (imageData != null)
        //            return tmp.Path;
        //    }

        //    return "";
        //}

        internal string SaveTemplateToImageFile(byte[] templateData)
        {
            string outputPath = null;

            string fileName = Path.GetRandomFileName();

            outputPath = Path.Combine(System.IO.Path.GetTempPath(), fileName);
            outputPath = outputPath + ".bmp"; // Path.ChangeExtension(outputPath, ".bmp");
            Image imageData;
            bool result = SaveTemplateImageAsBMP(templateData, outputPath, true);
            if (!result)
            {
                throw new Exception(string.Format("Failed to get Template Representation. {0}", result));
            }
            try
            {
                using (FileStream stream = new FileStream(outputPath, FileMode.Open, FileAccess.Read))
                {
                    imageData = Image.FromStream(stream);
                }

            }
            catch   //(Exception e)
            {
                //something went wrong, return no data
                throw;
                //need to log issue

            }


            return outputPath;
        }
    }
}


