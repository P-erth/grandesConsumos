using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Drawing;
using ZXing;

namespace Crc
{
    class Program
    {

        static void Main(string[] args)
        {
            var path2 = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "ppdd.txt");
            string text2 = System.IO.File.ReadAllText(@path2);
            XImage img = XImage.FromFile("template2.jpg");

            
            int pagina = text2.Length / 9009;
            int pivote = 7;

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();
            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont font = new XFont("Courier", 9, XFontStyle.Regular);

            String nis = text2.Substring(0, pivote);

            String nombre = text2.Substring(++pivote, 30);

            String domiReal = text2.Substring(pivote += 30, 30);
            String postal = text2.Substring(pivote += 30, 30);
            String localidad = text2.Substring(pivote += 30, 30);
            String socio = text2.Substring(pivote += 30, 8);
            String socioDesde = text2.Substring(pivote += 8, 8);
            String socioActa = text2.Substring(pivote += 8, 8);
            String socioTipo = text2.Substring(pivote += 8, 3);
            String socioDoc = text2.Substring(pivote += 3, 11);
            String inf1 = text2.Substring(pivote += 11, 52);
            String inf2 = text2.Substring(pivote += 52, 52);
            String inf3 = text2.Substring(pivote += 52, 52);
            String inf4 = text2.Substring(pivote += 52, 52);
            String inf5 = text2.Substring(pivote += 52, 52);
            String inf6 = text2.Substring(pivote += 52, 52);
            String cuit = text2.Substring(pivote += 52, 11);
            String condiva = text2.Substring(pivote += 11, 20);
            String cbu = text2.Substring(pivote += 20, 22);
            String cuFecha = text2.Substring(pivote += 22, 2) + "/" + text2.Substring(pivote += 2, 2) + "/" + text2.Substring(pivote += 2, 4);
            String cuHora = text2.Substring(pivote += 4, 2) + ":" + text2.Substring(pivote += 2, 2);

            String diaVto = text2.Substring(pivote += 2, 2);
            String mesVto = text2.Substring(pivote += 2, 2);
            String añoVto = text2.Substring(pivote += 2, 4);

          
            
            if (mesVto == "12")
            {
                mesVto = "01";
                int año = Int32.Parse(añoVto);
                añoVto = año.ToString();
            }
            else
            {
                int mes = Int32.Parse(mesVto);
                mes++;
                mesVto = mes.ToString();
            }
            String proxVto = diaVto + "/" + mesVto + "/" + añoVto;
            String lspParte1 = text2.Substring(pivote += 4, 1);
            String lspParte2 = text2.Substring(pivote += 1, 4);
             
            String lsp = lspParte1 + "-" + lspParte2 + "-" + text2.Substring(pivote += 4, 8);

            //String lsp2 = text2.Substring(pivote += 8, 1) + "-" + text2.Substring(pivote += 1, 4) + "-" + text2.Substring(pivote += 4, 8);
            String codCom = text2.Substring(pivote += 8, 2);
            String cesp = text2.Substring(pivote += 2, 14);
            String cespEmis = text2.Substring(pivote += 14, 2) + "/" + text2.Substring(pivote += 2, 2) + "/" + text2.Substring(pivote += 2, 4);
            String cespVto = text2.Substring(pivote += 4, 2) + "/" + text2.Substring(pivote += 2, 2) + "/" + text2.Substring(pivote += 2, 4);
            String lspTarifa = text2.Substring(pivote += 4, 6);
            String lspSocial = text2.Substring(pivote += 6, 1);
            String lspMedidor = text2.Substring(pivote += 1, 10);
            String lspEstadoAnt = text2.Substring(pivote += 10, 10);
            String lspEstadoAnFec = text2.Substring(pivote += 10, 2) + "/" + text2.Substring(pivote += 2, 2) + "/" + text2.Substring(pivote += 2, 4);
            String lspEstadoAc = text2.Substring(pivote += 4, 10);
            String lspEstadoAcFec = text2.Substring(pivote += 10, 2) + "/" + text2.Substring(pivote += 2, 2) + "/" + text2.Substring(pivote += 2, 4);
            String lspFactor = text2.Substring(pivote += 4, 4);
            String lspConsumo = text2.Substring(pivote += 4, 8);
            String lspSecuencia = text2.Substring(pivote += 8, 10);
            String cuerpoA1 = text2.Substring(pivote += 10, 85);
            String cuerpoA2 = text2.Substring(pivote += 85, 85);
            String cuerpoA3 = text2.Substring(pivote += 85, 85);
            String cuerpoA4 = text2.Substring(pivote += 85, 85);
            String cuerpoA5 = text2.Substring(pivote += 85, 85);
            String cuerpoA6 = text2.Substring(pivote += 85, 85);
            String cuerpoA7 = text2.Substring(pivote += 85, 85);
            String cuerpoA8 = text2.Substring(pivote += 85, 85);
            String cuerpoA9 = text2.Substring(pivote += 85, 85);
            String cuerpoA10 = text2.Substring(pivote += 85, 85);
            String cuerpoA11 = text2.Substring(pivote += 85, 85);
            String cuerpoA12 = text2.Substring(pivote += 85, 85);
            String cuerpoA13 = text2.Substring(pivote += 85, 85);
            String cuerpoA14 = text2.Substring(pivote += 85, 85);
            String cuerpoA15 = text2.Substring(pivote += 85, 85);
            String cuerpoA16 = text2.Substring(pivote += 85, 85);
            String cuerpoA17 = text2.Substring(pivote += 85, 85);
            String cuerpoA18 = text2.Substring(pivote += 85, 85);
            String cuerpoA19 = text2.Substring(pivote += 85, 85);
            String cuerpoA20 = text2.Substring(pivote += 85, 85);
            String cuerpoA21 = text2.Substring(pivote += 85, 85);
            String cuerpoA22 = text2.Substring(pivote += 85, 85);
            String cuerpoA23 = text2.Substring(pivote += 85, 85);
            String cuerpoA24 = text2.Substring(pivote += 85, 85);
            String cuerpoA25 = text2.Substring(pivote += 85, 85);
            String cuerpoA26 = text2.Substring(pivote += 85, 85);
            String cuerpoA27 = text2.Substring(pivote += 85, 85);
            String cuerpoA28 = text2.Substring(pivote += 85, 85);
            String cuerpoA29 = text2.Substring(pivote += 85, 85);
            String cuerpoA30 = text2.Substring(pivote += 85, 85);
            String cuerpoA31 = text2.Substring(pivote += 85, 85);
            String cuerpoA32 = text2.Substring(pivote += 85, 85);
            String cuerpoA33 = text2.Substring(pivote += 85, 85);
            String cuerpoA34 = text2.Substring(pivote += 85, 85);
            String cuerpoA35 = text2.Substring(pivote += 85, 85);
            String cuerpoA36 = text2.Substring(pivote += 85, 85);
            String cuerpoA37 = text2.Substring(pivote += 85, 85);
            String cuerpoA38 = text2.Substring(pivote += 85, 85);
            String cuerpoA39 = text2.Substring(pivote += 85, 85);
            String cuerpoA40 = text2.Substring(pivote += 85, 85);

            String deudasA1 = text2.Substring(pivote += 85, 50);
            String deudasA2 = text2.Substring(pivote += 50, 50);
            String deudasA3 = text2.Substring(pivote += 50, 50);
            String deudasA4 = text2.Substring(pivote += 50, 50);
            String deudasA5 = text2.Substring(pivote += 50, 50);
            String deudasA6 = text2.Substring(pivote += 50, 50);
            String deudasA7 = text2.Substring(pivote += 50, 50);
            String deudasA8 = text2.Substring(pivote += 50, 50);
            String deudasA9 = text2.Substring(pivote += 50, 50);
            String deudasA10 = text2.Substring(pivote += 50, 50);
            String deudasA11 = text2.Substring(pivote += 50, 50);
            String deudasA12 = text2.Substring(pivote += 50, 50);

            String estadisticos1 = text2.Substring(pivote += 50, 50);
            String estadisticos2 = text2.Substring(pivote += 50, 50);
            String estadisticos3 = text2.Substring(pivote += 50, 50);
            String estadisticos4 = text2.Substring(pivote += 50, 50);
            String estadisticos5 = text2.Substring(pivote += 50, 50);
            String estadisticos6 = text2.Substring(pivote += 50, 50);
            String estadisticos7 = text2.Substring(pivote += 50, 50);

            String recargos1 = text2.Substring(pivote += 50, 50);
            String recargos2 = text2.Substring(pivote += 50, 50);
            String recargos3 = text2.Substring(pivote += 50, 50);
            String recargos4 = text2.Substring(pivote += 50, 50);
            String recargos5 = text2.Substring(pivote += 50, 50);
            String recargos6 = text2.Substring(pivote += 50, 50);
            String recargos7 = text2.Substring(pivote += 50, 50);
            String recargos8 = text2.Substring(pivote += 50, 50);
            String recargos9 = text2.Substring(pivote += 50, 50);
            String recargos10 = text2.Substring(pivote += 50, 50);
            String recargos11 = text2.Substring(pivote += 50, 50);

            String promedio = text2.Substring(pivote += 50, 8); ///CONVERTIRLO A ENTERO Y DESPUES A STRING


            String totControl = text2.Substring(pivote += 8, 8);
            if (totControl == "00000000") totControl = "0";

            String cod1 = text2.Substring(pivote += 8, 28);


            //String totControl2 = text2.Substring(pivote += 8, 8);
            //if (totControl2 == "00000000") totControl2 = "0";
            
            
            //saco los ceros de la parte entera del importe
            String totImporteEntero = text2.Substring(pivote += 8, 10);
            long parteEntera = long.Parse(totImporteEntero);
            totImporteEntero = parteEntera.ToString();
            String totImporteDecimal = text2.Substring(pivote += 10, 2);
            // y guardo todo el importe entero
            String totImporte = totImporteEntero + "." + totImporteDecimal;

            //////////////////DATOS PARA QR1///////////////////
            String qr1 = "";
            qr1 += "000201";//Formato
            qr1 += "010212";//Metodo de inicio
            qr1 += "40230010com.yacare0105Y1103";//Datos Yacare
            qr1 += "5015001130545748831";//Cuil Empresa
            qr1 += "52044900"; //Codigo comercio
            qr1 += "5303032"; //Moneda de la TX
            String importe = Int32.Parse(cod1.Substring(18, 7)).ToString();
            String dec = cod1.Substring(25, 2);
            String cant = importe.Length.ToString();
            qr1 += "540" + cant + importe +  "." + dec; //Importe
            qr1 += "5802AR"; //Codigo de pais
            qr1 += "5925COOPERATIVAELECTRICACOLON"; //Nombre de empresa
            qr1 += "6005Colon"; //Ciudad empresa
            qr1 += "61043280"; //Codigo postal
            String idCliente = cod1.Substring(4, 7);
            qr1 += "62230108" + totControl + "0607" + idCliente; //Datos cliente
            qr1 += "6304"; //digitos de mierda de verificacion de Yacaré

            String crc = CalculaCRC(qr1, Encoding.UTF8);
            //QR1 ES EL STRING DEL QR1 JEJE
            qr1 += crc;
            ///////////////////////////////////////////////////

            // Draw image
            gfx.DrawImage(img, 0, 0);

            //Draw the QR
            var bcWriter = new ZXing.BarcodeWriter
            {
                Format = ZXing.BarcodeFormat.QR_CODE,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 300,
                    Width = 300,
                    Margin = 0
                },
            };

            Bitmap bm = new Bitmap(bcWriter.Write(qr1), 300, 300);
            XImage img2 = XImage.FromGdiPlusImage((Image)bm);
            img2.Interpolate = false;
            gfx.DrawImage(img2, 0, 0);

            // Draw the text

            //gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height),XStringFormats.Center);
            gfx.DrawString(nis, font, XBrushes.Black, 0, 30);
            gfx.DrawString(nombre, font, XBrushes.Black, 0, 40);
            gfx.DrawString(domiReal, font, XBrushes.Black, 0, 50);
            gfx.DrawString(postal, font, XBrushes.Black, 0, 60);
            gfx.DrawString(localidad, font, XBrushes.Black, 0, 70);
            // gfx.DrawMatrixCode()

            
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
            for (int b = 0; b < data.Length; b++)
            {
                for (int i = 0; i < 8; i++)
                {
                    Boolean bit = (((int)((uint)data[b] >> (7 - i))) & 1) == 1;
                    Boolean c15 = (crcValue >> 15 & 1) == 1;
                    crcValue <<= 1;
                    if (c15 ^ bit)
                    {
                        crcValue ^= 0x1021;
                    }

                }

            }
            crcValue &= 0xffff;
            int hexString = (crcValue & 0xFFFF);
            hexString = (crcValue & 0xFFFF);
            string retu = Convert.ToString(hexString, 16);



            return retu;
        }


    }

}