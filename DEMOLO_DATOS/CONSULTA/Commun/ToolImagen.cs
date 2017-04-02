using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;


using System.Drawing;
using System.IO;
using System.Drawing.Imaging;

namespace CONSULTA.Commun
{
    public class ToolImagen
    {

        public static byte[] ImageToByte(Bitmap img){


            try
            {
                using (var stream = new MemoryStream())
                {
                    img.Save(stream, ImageFormat.Png);
                    return stream.ToArray();
                }
            }
            catch (Exception ex)
            {

                int x=0;
                throw;
            }
            

            /*ImageConverter converter = new ImageConverter();
            return (byte[])converter.ConvertTo(img, typeof(byte[]));*/
        }

        public static Bitmap Base64StringToBitmap(string base64String)
        {
            Bitmap bmpReturn = null;

            byte[] byteBuffer = Convert.FromBase64String(base64String);
            MemoryStream memoryStream = new MemoryStream(byteBuffer);

            memoryStream.Position = 0;

            bmpReturn = (Bitmap)Bitmap.FromStream(memoryStream);

            memoryStream.Close();
            memoryStream = null;
            byteBuffer = null;

            return bmpReturn;
        }

        public static string ToBase64String(Bitmap bmp, ImageFormat imageFormat)
        {
            string base64String = string.Empty;

            MemoryStream memoryStream = new MemoryStream();
            bmp.Save(memoryStream, imageFormat);

            memoryStream.Position = 0;
            byte[] byteBuffer = memoryStream.ToArray();

            memoryStream.Close();

            base64String = Convert.ToBase64String(byteBuffer);
            byteBuffer = null;

            return base64String;
        }
    }
}