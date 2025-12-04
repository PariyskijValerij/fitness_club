using System;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace fitness_club.Data
{
    public static class PdfReportHelper
    {
        public static void ExportDataTableToPdf(DataTable table, string reportTitle, string filePath)
        {
            if (table == null) throw new ArgumentNullException("table");

            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var doc = new Document(PageSize.A4, 50f, 20f, 50f, 50f);

                var writer = PdfWriter.GetInstance(doc, stream);

                writer.PageEvent = new PdfFooterEvent();

                doc.Open();

                var titleFont = FontFactory.GetFont("Arial", 16, Font.BOLD);
                var headerFont = FontFactory.GetFont("Arial", 12, Font.BOLD);
                var dataFont = FontFactory.GetFont("Arial", 12, Font.NORMAL);
                var separatorFont = FontFactory.GetFont("Arial", 10, Font.ITALIC, BaseColor.GRAY);

                var titleParagraph = new Paragraph(reportTitle, titleFont);
                titleParagraph.Alignment = Element.ALIGN_CENTER;
                titleParagraph.SpacingAfter = 20f; 
                doc.Add(titleParagraph);

                foreach (DataRow row in table.Rows)
                {
                    var entryParagraph = new Paragraph();

                    entryParagraph.KeepTogether = true;

                    entryParagraph.IndentationLeft = 40f;
                    entryParagraph.SpacingAfter = 10f;

                    foreach (DataColumn column in table.Columns)
                    {
                        object rawValue = row[column];
                        string valueStr;

                        if (rawValue is DateTime dt)
                        {
                            valueStr = dt.ToString("dd.MM.yyyy");
                        }
                        else
                        {
                            valueStr = rawValue?.ToString() ?? "-";
                            if (valueStr.EndsWith(" 0:00:00"))
                            {
                                valueStr = valueStr.Replace(" 0:00:00", "");
                            }
                        }

                        var fieldName = new Chunk(column.ColumnName + ": ", headerFont);
                        var fieldValue = new Chunk(valueStr, dataFont);

                        var line = new Paragraph();
                        line.Add(fieldName);
                        line.Add(fieldValue);

                        entryParagraph.Add(line);
                    }

                    entryParagraph.Add(new Paragraph("_______________________________________", separatorFont));

                    doc.Add(entryParagraph);
                    doc.Add(new Paragraph(" "));
                }

                doc.Close();
            }
        }

        private class PdfFooterEvent : PdfPageEventHelper
        {
            public override void OnEndPage(PdfWriter writer, Document document)
            {
                PdfContentByte cb = writer.DirectContent;

                var footerFont = BaseFont.CreateFont(BaseFont.HELVETICA, BaseFont.CP1252, BaseFont.NOT_EMBEDDED);

                cb.BeginText();
                cb.SetFontAndSize(footerFont, 10);

                cb.SetTextMatrix(document.Left, document.Bottom - 10);

                string text = "Generated: " + DateTime.Now.ToString("dd.MM.yyyy HH:mm");
                cb.ShowText(text);

                cb.EndText();
            }
        }
    }
}