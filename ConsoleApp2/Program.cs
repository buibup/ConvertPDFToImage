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

            var countDoc =  doc.Pages.Count;
            for(var i=0; i < countDoc; i++)
            {
                Image emf = doc.SaveAsImage(i, Spire.Pdf.Graphics.PdfImageType.Metafile);
                Image bmp = new Bitmap((int)(emf.Size.Width * 2), (int)(emf.Size.Height * 2)); 
                using (Graphics g = Graphics.FromImage(bmp))
                {
                    g.ScaleTransform(2.0f, 2.0f);
                    g.DrawImage(emf, new Rectangle(new Point(0, 0), emf.Size), new Rectangle(new Point(0, 15), emf.Size), GraphicsUnit.Pixel);
                }
                bmp.Save($"convertToBmp{i}.bmp", ImageFormat.Bmp);
                System.Diagnostics.Process.Start($"convertToBmp{i}.bmp");
            }
        }
    }
}
