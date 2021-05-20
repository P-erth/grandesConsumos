using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Drawing;

namespace Crc
{
    class Program
    {

        static void Main(string[] args)
        {
            var path2 = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "ppdd.txt");
            string text2 = System.IO.File.ReadAllText(@path2);
            XImage img =   XImage.FromFile("template2.jpg");

       
            
            int pagina =  text2.Length / 9009 ;
            int pivote = 7;





            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();
            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            XFont font = new XFont("Helvetica", 9, XFontStyle.Regular);

            String nis = text2.Substring(0,pivote);

            String nombre = text2.Substring(++pivote, 30);
            
            String domiReal = text2.Substring(pivote+=30, 30);
            String postal = text2.Substring(pivote+=30, 30);
            String localidad = text2.Substring(pivote+=30, 30);
            String socio = text2.Substring(pivote += 30, 7);
            String socioDesde = text2.Substring(0, 7);
            String socioActa = text2.Substring(0, 7);
            String socioTipo = text2.Substring(0, 7);
            String socioDoc = text2.Substring(0, 7);
            String inf1 = text2.Substring(0, 7);
            String inf2 = text2.Substring(0, 7);
            String inf3 = text2.Substring(0, 7);
            String inf4 = text2.Substring(0, 7);
            String inf5 = text2.Substring(0, 7);
            String inf6 = text2.Substring(0, 7);
            String cuit = text2.Substring(0, 7);
            String condiva = text2.Substring(0, 7);
            String cbu = text2.Substring(0, 7);
            String cuFecha = text2.Substring(0, 7);
            String cuHora = text2.Substring(0, 7);
            String vto = text2.Substring(0, 7);



            // Draw image

            gfx.DrawImage(img, 0, 0);
            // Draw the text

            //gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height),XStringFormats.Center);
            gfx.DrawString(nis, font, XBrushes.Black,0,30);
            gfx.DrawString(nombre, font, XBrushes.Black, 0, 40);
            gfx.DrawString(domiReal, font, XBrushes.Black, 0, 50);
            gfx.DrawString(postal, font, XBrushes.Black, 0, 60);
            gfx.DrawString(localidad, font, XBrushes.Black , 0, 70);



            // Save the document...
            //document.CustomValues.CompressionMode = PdfCustomValueCompressionMode.Compressed;
            document.Options.FlateEncodeMode = PdfFlateEncodeMode.BestCompression;
            const string filename = "HelloWorld.pdf";
            document.Save(filename);
            System.Diagnostics.Process.Start(filename);

            //
            var path = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "foo.txt");
            string text = System.IO.File.ReadAllText(@path);





            foreach (string value in args)
            {
              // Console.WriteLine(value);
                String banana = CalculaCRC(value, Encoding.UTF8);
                //String banana = value;
                System.IO.File.WriteAllText(@path, banana);
            }

        }

        static String CalculaCRC(String value, Encoding enc)
        {
            byte[] data = enc.GetBytes(value);
            int crcValue = 0xFFFF;
            for ( int b = 0; b <data.Length; b++)
            {
                for(int i = 0; i < 8; i++)
                {
                    Boolean bit = (((int)((uint) data[b] >> (7 - i))) & 1) == 1;
                    Boolean c15 = (crcValue >> 15 & 1) == 1;
                    crcValue <<= 1;
                   if (c15 ^ bit)
                    {
                        crcValue ^= 0x1021;
                    }
                    
                }
                
            }
            crcValue &= 0xffff;
            int hexString =  (crcValue & 0xFFFF);
            hexString = (crcValue & 0xFFFF);
            string retu = Convert.ToString(hexString , 16);
            
           

            return  retu;
        }

      
    }

}
