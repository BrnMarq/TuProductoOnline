using iTextSharp.text;
using iTextSharp.text.pdf;
using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using TuProductoOnline.Models;
using TuProductoOnline.Utils;
using System.Net.Http.Headers;
using TuProductoOnline.Consts;
using System.Reflection.Emit;
using System.Text.Json;
using System.Text.Json.Serialization;
using iTextSharp.tool.xml;
using System.IO;
using System.Runtime.InteropServices.ComTypes;
using System.Reflection;
using static iTextSharp.text.pdf.hyphenation.TernaryTree;
using com.itextpdf.text.pdf;
using Org.BouncyCastle.Asn1;
using System.Runtime.InteropServices;
using iTextSharp.tool.xml.html.table;

namespace TuProductoOnline.Views
{
    public class PageEventHelper : PdfPageEventHelper
    {
        // This is the contentbyte object of the writer
        PdfContentByte cb;
        // we will put the final number of pages in a template
        PdfTemplate template;
        // this is the BaseFont we are going to use for the header / footer
        BaseFont bf = null;
        // This keeps track of the creation time
        DateTime PrintTime = DateTime.Now;
        #region Properties
        private string _Title;
        public string Title
        {
            get { return _Title; }
            set { _Title = value; }
        }

        private string _HeaderLeft;
        public string HeaderLeft
        {
            get { return _HeaderLeft; }
            set { _HeaderLeft = value; }
        }
        private string _HeaderRight;
        public string HeaderRight
        {
            get { return _HeaderRight; }
            set { _HeaderRight = value; }
        }
        private Font _HeaderFont;
        public Font HeaderFont
        {
            get { return _HeaderFont; }
            set { _HeaderFont = value; }
        }
        private Font _FooterFont;
        public Font FooterFont
        {
            get { return _FooterFont; }
            set { _FooterFont = value; }
        }
        #endregion
        // we override the onOpenDocument method
        public override void OnOpenDocument(PdfWriter writer, Document document)
        {
            try
            {
                PrintTime = DateTime.Now;
                bf = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);
                cb = writer.DirectContent;
                template = cb.CreateTemplate(document.PageSize.Width, 50);
                
            }
            catch (DocumentException de)
            {
            }
            catch (System.IO.IOException ioe)
            {
            }
        }

        public override void OnStartPage(PdfWriter writer, Document document)
        {
            base.OnStartPage(writer, document);
            Rectangle pageSize = document.PageSize;
            if (Title != string.Empty)
            {
                using (StringReader sr = new StringReader(Title))
                {
                    //Usar el modificador para editar el archivo pdf con el string que transformamos.
                    XMLWorkerHelper.GetInstance().ParseXHtml(writer, document, sr);

                }

                iTextSharp.text.Image img = iTextSharp.text.Image.GetInstance(Properties.Resources.LogoCompleto, System.Drawing.Imaging.ImageFormat.Png);
                img.ScaleToFit(200, 120);
                img.Alignment = iTextSharp.text.Image.UNDERLYING;
                img.SetAbsolutePosition(document.LeftMargin, document.Top - 60);
                document.Add(img);

                Paragraph saltoDeLinea = new Paragraph(" ");
                document.Add(saltoDeLinea);

                //TablaProductos.

                PdfPTable TablaHeader = new PdfPTable(6);

                TablaHeader.HorizontalAlignment = 0;
                TablaHeader.TotalWidth = 545f;
                TablaHeader.LockedWidth = true;
                float[] widths = new float[] { 75f, 110f, 160f, 40f, 100f, 115f };
                TablaHeader.SetWidths(widths);

                
                addCell(TablaHeader, "Cantidad", 1);
                addCell(TablaHeader, "Nombre", 1);
                addCell(TablaHeader, "Descripcion", 1);
                addCell(TablaHeader, "IVA", 1);
                addCell(TablaHeader, "Precio", 1);
                addCell(TablaHeader, "Monto", 1);


                document.Add(TablaHeader);

                //Metodo para agregar celda con caracteristicas personalizadas

                void addCell(PdfPTable table, string text, int rowspan)
                {
                    BaseFont bfTimes = BaseFont.CreateFont(BaseFont.TIMES_BOLD, BaseFont.CP1252, false);
                    iTextSharp.text.Font times = new iTextSharp.text.Font(bfTimes, 11, iTextSharp.text.Font.BOLD, iTextSharp.text.BaseColor.WHITE);

                    PdfPCell cell = new PdfPCell(new Phrase(text));
                    cell.Rowspan = rowspan;
                    cell.Padding = 7;
       
                    cell.BackgroundColor = new iTextSharp.text.BaseColor(51, 153, 255);//(169, 169, 169);
                    cell.HorizontalAlignment = PdfPCell.ALIGN_CENTER;
                    cell.VerticalAlignment = PdfPCell.ALIGN_MIDDLE;
                    table.AddCell(cell);
                }

            }
            if (HeaderLeft + HeaderRight != string.Empty)
            {
                PdfPTable HeaderTable = new PdfPTable(2);
                HeaderTable.DefaultCell.VerticalAlignment = Element.ALIGN_MIDDLE;
                HeaderTable.TotalWidth = pageSize.Width - 80;
                HeaderTable.SetWidthPercentage(new float[] { 45, 45 }, pageSize);

                PdfPCell HeaderLeftCell = new PdfPCell(new Phrase(8, HeaderLeft, HeaderFont));
                HeaderLeftCell.Padding = 5;
                HeaderLeftCell.PaddingBottom = 8;
                HeaderLeftCell.BorderWidthRight = 0;
                HeaderTable.AddCell(HeaderLeftCell);
                PdfPCell HeaderRightCell = new PdfPCell(new Phrase(8, HeaderRight, HeaderFont));
                HeaderRightCell.HorizontalAlignment = PdfPCell.ALIGN_RIGHT;
                HeaderRightCell.Padding = 5;
                HeaderRightCell.PaddingBottom = 8;
                HeaderRightCell.BorderWidthLeft = 0;
                HeaderTable.AddCell(HeaderRightCell);
               
                HeaderTable.WriteSelectedRows(0, -1, pageSize.GetLeft(40), pageSize.GetTop(50), cb);
            }
        }

        public override void OnEndPage(PdfWriter writer, Document document)
        {
            base.OnEndPage(writer, document);
            int pageN = writer.PageNumber;
            String text = "Página " + pageN + "/";
            float len = bf.GetWidthPoint(text, 8);
            Rectangle pageSize = document.PageSize;
            
            cb.BeginText();
            cb.SetFontAndSize(bf, 9);
            cb.SetTextMatrix(pageSize.GetLeft(38), pageSize.GetBottom(30));
            cb.ShowText(text);
            cb.EndText();

            cb.AddTemplate(template, pageSize.GetLeft(40) + len, pageSize.GetBottom(30));
            cb.BeginText();
            cb.SetFontAndSize(bf, 9);
            cb.ShowTextAligned(PdfContentByte.ALIGN_RIGHT,
                "Impreso el " + PrintTime.ToString(),
                pageSize.GetRight(40),
                pageSize.GetBottom(30), 0);
            cb.EndText();
        }

        public override void OnCloseDocument(PdfWriter writer, Document document)
        {
            base.OnCloseDocument(writer, document);
  
            template.BeginText();
            template.SetFontAndSize(bf, 9);
            template.SetTextMatrix(3, 0);
            template.ShowText("" + (writer.PageNumber));
            template.EndText();
        }
    }
}
