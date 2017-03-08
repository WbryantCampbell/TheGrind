using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;
using System.Web;

namespace ImageConverter
{
    class Program
    {
        static void Main(string[] args)
        {
            Bitmap image1 = (Bitmap)Image.FromFile(@"C:\_repos\TheGrind\ImageConverter\Signatures\sig.png", true);

            ImageConverter imgCon = new ImageConverter();

            var signatureBytes = imgCon.imageToByteArray(image1);

            foreach (var sig in signatureBytes)
            {
                Console.Write(sig);
            }

            Console.ReadLine();

            Console.WriteLine();
            Console.WriteLine("Let's go back!");

            Console.ReadLine();

            var byteToImage = imgCon.byteArrayToImage(signatureBytes);

            byteToImage.Save(@"C:\_repos\TheGrind\ImageConverter\Signatures\NewImages\NewSig.PNG");

            Console.WriteLine("Check and see if it made it");
            Console.ReadLine();

        }

        public class ImageConverter
        {
            public ImageConverter()
            {
            }

            public byte[] imageToByteArray(Image imageIn)
            {
                MemoryStream ms = new MemoryStream();
                imageIn.Save(ms, System.Drawing.Imaging.ImageFormat.Png);
                return ms.ToArray();
            }

            public Image byteArrayToImage(byte[] byteArrayIn)
            {
                MemoryStream ms = new MemoryStream(byteArrayIn);
                Image returnImage = Image.FromStream(ms);
                return returnImage;
            }
        }
    }
}
