using System;
using System.Windows.Forms;
using System.Diagnostics;
using PdfSharp;
using PdfSharp.Drawing;
using PdfSharp.Pdf;

namespace BestOil
{
  
    public class PDF
    {

        public static void CreatePDF(DataBase DB, string filename,string totalPrice)
        {            
            string time = "Tarix: " + DateTime.Now.ToShortDateString() + "  " + DateTime.Now.ToShortTimeString();

            PdfDocument pdf = new PdfDocument();
            pdf.Info.Title = "Payment Check";
            PdfPage pdfPage = pdf.AddPage();
            XGraphics graph = XGraphics.FromPdfPage(pdfPage);
            XFont font = new XFont("Verdana", 20, XFontStyle.Bold);
            graph.DrawString("BEST OIL", font, XBrushes.Black, new XRect(0, 0, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            XFont font2 = new XFont("Verdana", 16, XFontStyle.Regular);
            graph.DrawString("Bakı, Xətai rayonu, Nobel pr,15 AZ1025", font2, XBrushes.Black, new XRect(0, 30, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString("(+99412) 488-67-61", font2, XBrushes.Black, new XRect(0, 50, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString(time, font2, XBrushes.Black, new XRect(150, 80, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString("Miqdar          Qiymət            Cəmi", font2, XBrushes.Black, new XRect(90, 120, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            graph.DrawString("-------------------------------------------------------------------------------------------", font2, XBrushes.Black, new XRect(0, 140, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            int column = 160;

            foreach (var gasoline in DB.Gasolines)
            {
               
                graph.DrawString(gasoline.Gasoline, font2, XBrushes.Black, new XRect(0, column, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                string data = gasoline.Quantity + "          " + gasoline.Price + "                   " + gasoline.TotalPrice ;
                graph.DrawString(data, font2, XBrushes.Black, new XRect(90, column, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                column += 20;
            }

            foreach (var eat in DB.Eats)
            {

                graph.DrawString(eat.Eat, font2, XBrushes.Black, new XRect(0, column, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);

                string data = eat.Count + "          " + eat.Price + "                    " + eat.TotalPrice ;
                graph.DrawString(data, font2, XBrushes.Black, new XRect(90, column, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
                column += 20;
            }
            graph.DrawString("-------------------------------------------------------------------------------------------", font2, XBrushes.Black, new XRect(0, column, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopLeft);
            column += 20;
            graph.DrawString("CƏMİ "+totalPrice + "  AZN ", font, XBrushes.Black, new XRect(0, column, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);
            column += 40;
            graph.DrawString("Təşəkkür Edirik", font2, XBrushes.Black, new XRect(0, column, pdfPage.Width.Point, pdfPage.Height.Point), XStringFormats.TopCenter);

            pdf.Save(filename);
            Process.Start(filename);
        }
    }
}