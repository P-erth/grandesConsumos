using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using PdfSharp.Drawing;
using PdfSharp.Pdf;
using PdfSharp.Pdf.IO;
using System.Drawing;
using ZXing;

namespace grandesConsumos
{
    class Program
    {

        // Declaracion de fuentes
        public static XFont fontCourierBold15 = new XFont("Courier New", 15, XFontStyle.Bold);
        public static XFont fontCourierBold14 = new XFont("Courier New", 14, XFontStyle.Bold);
        public static XFont fontCourierBold13 = new XFont("Courier New", 13, XFontStyle.Bold);
        public static XFont fontCourierBold7 = new XFont("Courier New", 7, XFontStyle.Bold);
        public static XFont fontCourier7 = new XFont("Courier New", 7, XFontStyle.Regular);
        public static XFont fontCourier8 = new XFont("Courier New", 8, XFontStyle.Regular);
        public static XFont fontCourier6 = new XFont("Courier New", 6, XFontStyle.Regular);
        public static XFont fontCourierBold10 = new XFont("Courier New", 10, XFontStyle.Bold);
        public static XFont fontCourierBold9 = new XFont("Courier New", 9, XFontStyle.Bold);
        /////////////////////////

        static void Main(string[] args)
        {
            var path2 = Path.Combine(System.AppDomain.CurrentDomain.BaseDirectory, "PPDD-T2.txt");
            string textToParse = System.IO.File.ReadAllText(@path2);
            int pagina = textToParse.Length / 6615;
            int pivote = 0;//El mascherano del parseo


            for (int p = 0; p < pagina; p++)
            {

                PdfDocument document = new PdfDocument();
                document.Info.Title = "Created with PDFsharp";
     
                if (p != 0)
                {
                    pivote += 6615;
                }

                string textToParseInPage = textToParse.Substring(pivote, 6615); 
                pdfGeneratorGrandesConsumos(textToParseInPage, document);
                
                String nis = textToParseInPage.Substring(0, 8);
                String lspSecuencia = textToParseInPage.Substring(278, 10);

                // Save the document...
                document.Options.FlateEncodeMode = PdfFlateEncodeMode.BestCompression;
                string filename = nis + "_" + lspSecuencia + ".pdf";
                var pathToWrite = Path.GetFullPath("Historico\\" + textToParse.Substring(161, 2) + textToParse.Substring(163, 4) + "\\");
                Directory.CreateDirectory(pathToWrite);
                Console.WriteLine("Procesando: " + pathToWrite + filename);
                document.Save(pathToWrite + filename);
                
                //System.Diagnostics.Process.Start(pathToWrite + filename);

            }
            var pathFinal = Path.GetFullPath("Historico\\" + textToParse.Substring(545, 2) + textToParse.Substring(547, 4) + "\\");
            Console.WriteLine("Archivos guardados en: " + pathFinal);
            Console.WriteLine("Presione la tecla ENTER para finalizar.");
            Console.ReadLine();
        }

        private static void pdfGeneratorGrandesConsumos(string pagina, PdfDocument document)
        {


            int pivote = 0;
            PdfPage page = document.AddPage();
            page.Size = PdfSharp.PageSize.A4;

            // Get an XGraphics object for drawing
            XGraphics gfx = XGraphics.FromPdfPage(page);
            XImage img = XImage.FromFile("templateGrandes.jpg");
            gfx.DrawImage(img, 0, 0);

            //Armado de variables
            String nis = pagina.Substring(pivote, 8);
            String nombre = pagina.Substring(pivote += 8, 30);
            String domiReal = pagina.Substring(pivote += 30, 30);
            String localidad = pagina.Substring(pivote += 30, 30);

            String socio = pagina.Substring(pivote += 30, 8);
            String cuit = pagina.Substring(pivote += 8, 11);
            String condiva = pagina.Substring(pivote += 11, 20);
            String cbu = pagina.Substring(pivote += 20, 22);
            String cuFecha = pagina.Substring(pivote += 22, 2) + "/" + pagina.Substring(pivote += 2, 2) + "/" + pagina.Substring(pivote += 2, 4);
            String cuHora = pagina.Substring(pivote += 4, 2) + ":" + pagina.Substring(pivote += 2, 2);
            String cuVto = pagina.Substring(pivote += 2, 2) + "/" + pagina.Substring(pivote += 2, 2) + "/" + pagina.Substring(pivote += 2, 4);
            String lsp = pagina.Substring(pivote += 4, 1) + "-" + pagina.Substring(pivote += 1, 4) + "-" + pagina.Substring(pivote += 4, 8);
            String lspCod = pagina.Substring(pivote += 8, 2);
            String cespNum = pagina.Substring(pivote += 2, 14);
            String cespEmision = pagina.Substring(pivote += 14, 2) + "/" + pagina.Substring(pivote += 2, 2) + "/" + pagina.Substring(pivote += 2, 4);
            String cespVto = pagina.Substring(pivote += 4, 2) + "/" + pagina.Substring(pivote += 2, 2) + "/" + pagina.Substring(pivote += 2, 4);
            String lspTarifa = pagina.Substring(pivote += 4, 10);
            String estadoDE = pagina.Substring(pivote += 10, 10);
            String lspEstadoDF = pagina.Substring(pivote += 10, 2) + "/" + pagina.Substring(pivote += 2, 2) + "/" + pagina.Substring(pivote += 2, 4);
            String estadoHE = pagina.Substring(pivote += 4, 10);
            String lspEstadoHF = pagina.Substring(pivote += 10, 2) + "/" + pagina.Substring(pivote += 2, 2) + "/" + pagina.Substring(pivote += 2, 4);
            String lspFactor = pagina.Substring(pivote += 4, 4);
            String lspCoseno = pagina.Substring(pivote += 4, 4);
            String lspSecuencia = pagina.Substring(pivote += 4, 10);

            List<string> cuerpos = new List<string>();//Tabla Cuerpo
            cuerpos.Add(pagina.Substring(pivote += 10, 50));
            for (int i = 0; i < 39; i++) cuerpos.Add(pagina.Substring(pivote += 50, 50));

            List<string> cuerpos2 = new List<string>();//Tabla Cuerpo
            cuerpos2.Add(pagina.Substring(pivote += 50, 80));
            for (int i = 0; i < 39; i++) cuerpos2.Add(pagina.Substring(pivote += 80, 80));


            List<string> deudas = new List<string>();//Tabla Cuerpo
            deudas.Add(pagina.Substring(pivote += 80, 40));
            for (int i = 0; i < 11; i++) deudas.Add(pagina.Substring(pivote += 40, 40));

            List<string> recargos = new List<string>();//Tabla Cuerpo
            recargos.Add(pagina.Substring(pivote += 40, 50));
            for (int i = 0; i < 11; i++) recargos.Add(pagina.Substring(pivote += 50, 50));

            String totControl = pagina.Substring(pivote += 50, 8);
            String total = int.Parse(pagina.Substring(pivote += 8, 10)).ToString() + "." + pagina.Substring(pivote += 10, 2);

            String cod = pagina.Substring(pivote += 2, 25);


            ///desde aca se dibujan los textos
            int posy;
            posy = 197;
            //cuerpo
            foreach (string cuerpo in cuerpos) gfx.DrawString(cuerpo, fontCourier7, XBrushes.Black, 5, posy += 7);
            posy = 197;
            foreach (string cuerpo in cuerpos2) gfx.DrawString(cuerpo, fontCourier7, XBrushes.Black, 255, posy += 7);
            posy = 490;
            foreach (string deuda in deudas) gfx.DrawString(deuda, fontCourier7, XBrushes.Black, 189, posy += 7);
            posy = 483;
            foreach (string recargo in recargos) gfx.DrawString(recargo, fontCourier7, XBrushes.Black, 20, posy += 7);




            gfx.DrawString("Numeración emitida como gran contribuyente el " + cuFecha + " a las " + cuHora, fontCourierBold7, XBrushes.Black, 20, 462);
            gfx.DrawString(cuVto, fontCourierBold14, XBrushes.Black, 375, 491);
            gfx.DrawString(total, fontCourierBold14, XBrushes.Black, 495, 491);

            posy = 20;
            gfx.DrawString("Liq. Serv. Publicos", fontCourierBold7, XBrushes.Black, 400, posy);
            gfx.DrawString(lsp, fontCourierBold7, XBrushes.Black, 500, posy);
            gfx.DrawString("Código Comprobante", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(lspCod, fontCourierBold7, XBrushes.Black, 555, posy);
            gfx.DrawString("C.E.S.P Número", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(cespNum, fontCourierBold7, XBrushes.Black, 505, posy);
            gfx.DrawString("Vencimiento CESP", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(cespVto, fontCourierBold7, XBrushes.Black, 522, posy);
            gfx.DrawString("Control de pago", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(totControl, fontCourierBold7, XBrushes.Black, 530, posy);
            gfx.DrawString("Fecha emisión", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(cespEmision, fontCourierBold7, XBrushes.Black, 522, posy);
            gfx.DrawString("Estado Anter.", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(lspEstadoDF, fontCourierBold7, XBrushes.Black, 522, posy);
            gfx.DrawString("Estado Actual", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(lspEstadoHF, fontCourierBold7, XBrushes.Black, 522, posy);
            gfx.DrawString("Factor", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(int.Parse(lspFactor).ToString(), fontCourierBold7, XBrushes.Black, 556, posy);
            gfx.DrawString("Coseno Fi.", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(lspCoseno, fontCourierBold7, XBrushes.Black, 548, posy);
            gfx.DrawString("Secuencia", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(lspSecuencia, fontCourierBold7, XBrushes.Black, 523, posy);
            gfx.DrawString("Tarifa", fontCourierBold7, XBrushes.Black, 400, posy += 10);
            gfx.DrawString(lspTarifa, fontCourierBold7, XBrushes.Black, 527, posy);
            gfx.DrawString("NIS", fontCourierBold14, XBrushes.Black, 397, posy += 15);
            gfx.DrawString(int.Parse(nis).ToString(), fontCourierBold14, XBrushes.Black, 510, posy);


            gfx.DrawString(nombre, fontCourierBold14, XBrushes.Black, 25, 92);
            if (domiReal == localidad)
            {
                gfx.DrawString(domiReal, fontCourierBold14, XBrushes.Black, 25, 105);
            }
            else
            {
                gfx.DrawString(domiReal, fontCourierBold14, XBrushes.Black, 25, 105);
                gfx.DrawString(localidad, fontCourierBold14, XBrushes.Black, 25, 118);
            }

            gfx.DrawString("Cond.Iva: " + condiva, fontCourierBold7, XBrushes.Black, 25, 138);
            gfx.DrawString("CUIT: " + cuit, fontCourierBold7, XBrushes.Black, 155, 138);
            DrawBarCodeGrandesConsumos(gfx, cod);
            gfx.DrawString("*" + cod + "*", fontCourier6, XBrushes.Black, 70, 163);

        }

        private static void DrawBarCodeGrandesConsumos(XGraphics gfx, string code)
        {
            var bcWriter = new BarcodeWriter
            {
                Format = BarcodeFormat.CODE_128,
                Options = new ZXing.Common.EncodingOptions
                {
                    Height = 20,
                    Width = 253,
                    Margin = 0
                },
            };
            bcWriter.Options.PureBarcode = true;
            //Drawing BarCode1
            Bitmap bm = bcWriter.Write(code);
            XImage img = XImage.FromGdiPlusImage((Image)bm);
            img.Interpolate = false;
            gfx.DrawImage(img, 30, 142);

        }

    }

}