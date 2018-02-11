using Spire.Pdf;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp2
{
    class Program
    {
        static void Main(string[] args)
        {
            PdfDocument doc = new PdfDocument();
            doc.LoadFromFile("sample.pdf");
            Image bmp = doc.SaveAsImage(0);
            Image emf = doc.SaveAsImage(0, Spire.Pdf.Graphics.PdfImageType.Metafile);
            Image zoomImg = new Bitmap((int)(emf.Size.Width * 2), (int)(emf.Size.Height * 2));
            using (Graphics g = Graphics.FromImage(zoomImg))
            {
                g.ScaleTransform(2.0f, 2.0f);
                g.DrawImage(emf, new Rectangle(new Point(0, 0), emf.Size), new Rectangle(new Point(0, 0), emf.Size), GraphicsUnit.Pixel);
            }
            bmp.Save("convertToBmp.bmp", ImageFormat.Bmp);
            System.Diagnostics.Process.Start("convertToBmp.bmp");
            //emf.Save("convertToEmf.png", ImageFormat.Png);
            //System.Diagnostics.Process.Start("convertToEmf.png");
            //zoomImg.Save("convertToZoom.png", ImageFormat.Png);
            //System.Diagnostics.Process.Start("convertToZoom.png");
        }
    }
}
