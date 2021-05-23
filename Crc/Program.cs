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
            int pivote = 8;

            // Create a new PDF document
            PdfDocument document = new PdfDocument();
            document.Info.Title = "Created with PDFsharp";

            // Create an empty page
            PdfPage page = document.AddPage();
            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);

            //XPdfFontOptions options = new XPdfFontOptions(PdfFontEncoding.Unicode, PdfFontEmbedding.Always);
            XFont fontCourier8 = new XFont("Courier", 8, XFontStyle.Regular);
            XFont fontCourier7 = new XFont("Courier", 7, XFontStyle.Regular);


            String nis = text2.Substring(0, pivote);

            String nombre = text2.Substring(pivote, 30);

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

            List<string> cuerpos = new List<string>();//Tabla Cuerpo
            cuerpos.Add(text2.Substring(pivote += 10, 85));
            for (int i = 0; i < 39; i++) cuerpos.Add(text2.Substring(pivote += 85, 85));
            List<string> deudas = new List<string>();//Tabla Deuda
            deudas.Add(text2.Substring(pivote += 85, 50));
            for (int i = 0; i < 11; i++) deudas.Add("aaaaaaaaaaeeeeeeeeeeaaaaaaaaaaeeeeeeeeeedddddddddd" + (pivote+=50).ToString());//deudas.Add(text2.Substring(pivote += 50, 50));
            List<string> estadisticos = new List<string>();//Tabla estadisticos
            for (int i = 0; i < 7; i++) estadisticos.Add(text2.Substring(pivote += 50, 50));
            List<string> recargos = new List<string>();//Tabla recargos
            for (int i = 0; i < 11; i++) recargos.Add("aaaaaaaaaaeeeeeeeeeeaaaaaaaaaaeeeeeeeeeedddddddddd" + (pivote+=50).ToString()); //recargos.Add(text2.Substring(pivote += 50, 50));

            Console.WriteLine(recargos);
            String promedio = long.Parse(text2.Substring(pivote += 50, 8)).ToString(); ///CONVERTIRLO A ENTERO Y DESPUES A STRING


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
            String cant = (importe.Length + 3).ToString() ;
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
                    Height = 100,
                    Width = 100,
                    Margin = 0
                },
            };

            Bitmap bm = new Bitmap(bcWriter.Write(qr1), 100, 100);
            XImage img2 = XImage.FromGdiPlusImage((Image)bm);
            img2.Interpolate = false;
            gfx.DrawImage(img2, 490, 330);

            // Draw the text
            XFont fontCourierBold20 = new XFont("Courier New", 20,XFontStyle.Bold);
            XFont fontCourierBold15 = new XFont("Courier New", 15, XFontStyle.Bold);
            XFont fontCourierBold7 = new XFont("Courier New", 7, XFontStyle.Bold);
            //gfx.DrawString("Hello, World!", font, XBrushes.Black, new XRect(0, 0, page.Width, page.Height),XStringFormats.Center);



            gfx.DrawString("NIS:  " + (long.Parse(nis)).ToString(), fontCourierBold15, XBrushes.Black, 410, 90);
            gfx.DrawString(nombre, fontCourierBold15, XBrushes.Black, 25, 92);
            gfx.DrawString(domiReal, fontCourierBold15, XBrushes.Black, 25, 105);
            gfx.DrawString(postal, fontCourierBold15, XBrushes.Black, 25, 118);
            gfx.DrawString(localidad, fontCourierBold15, XBrushes.Black, 25, 131);
            gfx.DrawString(condiva, fontCourier7, XBrushes.Black, 25, 142);
            gfx.DrawString(cuit, fontCourier7, XBrushes.Black, 155, 142);
            // gfx.DrawMatrixCode()



            fontCourier7 = new XFont("Courier New", 7, XFontStyle.Regular);
            int posy = 185;
            foreach (string cuerpo in cuerpos) gfx.DrawString(cuerpo, fontCourier7, XBrushes.Black, 243, posy += 7);
            posy = 176;
            XFont fontCourier6 = new XFont("Courier New", 6, XFontStyle.Regular);
            foreach (string deuda in deudas) gfx.DrawString(deuda, fontCourier6, XBrushes.Black, 43, posy += 7);
            posy = 255;
            foreach (string estadistico in estadisticos) gfx.DrawString(estadistico, fontCourier6, XBrushes.Black, 43, posy += 7);
            gfx.DrawString("Promedio : " + promedio, fontCourier6, XBrushes.Black, 105, posy += 7);
            posy = 326;
            foreach (string recargo in recargos) gfx.DrawString(recargo, fontCourier6, XBrushes.Black, 30, posy += 7);

            posy = 22;
            gfx.DrawString("Liq. Serv. Públicos", fontCourierBold7, XBrushes.Black, 400, posy);
            gfx.DrawString(lsp, fontCourierBold7, XBrushes.Black, 500, posy);
            gfx.DrawString("Código Comprobante", fontCourierBold7, XBrushes.Black, 400, posy+=10);
            gfx.DrawString(codCom, fontCourierBold7, XBrushes.Black, 555, posy);
            gfx.DrawString("C.E.S.P. Número", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(cesp, fontCourierBold7, XBrushes.Black, 505, posy);
            gfx.DrawString("Vencimiento CESP", fontCourierBold7, XBrushes.Black, 400, posy+=10);
            gfx.DrawString(cespVto, fontCourierBold7, XBrushes.Black, 522, posy);
            gfx.DrawString("Control de pago", fontCourierBold7, XBrushes.Black, 400, posy+=10);
            gfx.DrawString(totControl, fontCourierBold7, XBrushes.Black, 530, posy);
            gfx.DrawString("Fecha emisión", fontCourierBold7, XBrushes.Black, 400, posy+=10);
            gfx.DrawString(cespEmis, fontCourierBold7, XBrushes.Black, 522, posy);

            posy = 102;
            gfx.DrawString("Medidor Nro.", fontCourierBold7, XBrushes.Black, 275, posy);
            gfx.DrawString(lspMedidor, fontCourierBold7, XBrushes.Black, 352, posy);
            gfx.DrawString("Estado Anter.", fontCourierBold7, XBrushes.Black, 400, posy);
            gfx.DrawString((long.Parse(lspEstadoAnt)).ToString(), fontCourierBold7, XBrushes.Black, 470, posy);
            gfx.DrawString(lspEstadoAnFec, fontCourierBold7, XBrushes.Black, 505, posy);
            gfx.DrawString("Socio", fontCourierBold7, XBrushes.Black, 275, posy+=7);
            gfx.DrawString(socio, fontCourierBold7, XBrushes.Black, 360, posy);

            gfx.DrawString("Tarifa", fontCourierBold7, XBrushes.Black, 275, posy+=7);
            gfx.DrawString(lspTarifa, fontCourierBold7, XBrushes.Black, 368, posy);
            gfx.DrawString("Pxmo. vto. desde", fontCourierBold7, XBrushes.Black, 275, posy+=14);
            gfx.DrawString(proxVto, fontCourierBold7, XBrushes.Black, 356, posy);
            
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