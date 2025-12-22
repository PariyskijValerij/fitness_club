using System;
using System.Data;
using System.IO;
using iTextSharp.text;
using iTextSharp.text.pdf;

namespace fitness_club.Data
{
    public static class PdfReportHelper
    {
        private static readonly Font TitleFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 16);
        private static readonly Font HeaderFont = FontFactory.GetFont(FontFactory.HELVETICA_BOLD, 11);
        private static readonly Font NormalFont = FontFactory.GetFont(FontFactory.HELVETICA, 11);
        private static readonly Font FooterFont = FontFactory.GetFont(FontFactory.HELVETICA_OBLIQUE, 10);

        public static void ExportDataTableToPdfTable(DataTable table, string reportTitle, string filePath)
        {
            if (table == null) throw new ArgumentNullException(nameof(table));

            using (var stream = new FileStream(filePath, FileMode.Create, FileAccess.Write, FileShare.None))
            {
                var doc = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                var writer = PdfWriter.GetInstance(doc, stream);

                doc.Open();

                var title = new Paragraph(reportTitle, TitleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 15f
                };
                doc.Add(title);

                var pdfTable = new PdfPTable(table.Columns.Count)
                {
                    WidthPercentage = 100
                };
                pdfTable.SpacingAfter = 0f;
                pdfTable.HeaderRows = 1;

                foreach (DataColumn column in table.Columns)
                {
                    var cell = new PdfPCell(new Phrase(column.ColumnName, HeaderFont))
                    {
                        BackgroundColor = new BaseColor(230, 230, 230),
                        HorizontalAlignment = Element.ALIGN_CENTER,
                        VerticalAlignment = Element.ALIGN_MIDDLE,
                        Padding = 5f
                    };
                    pdfTable.AddCell(cell);
                }

                foreach (DataRow row in table.Rows)
                {
                    foreach (var item in row.ItemArray)
                    {
                        string value = item?.ToString() ?? "";

                        if (item is DateTime dt)
                        {
                            value = dt.ToString("dd.MM.yyyy");
                        }

                        var cell = new PdfPCell(new Phrase(value, NormalFont))
                        {
                            Padding = 4f,
                            VerticalAlignment = Element.ALIGN_MIDDLE
                        };
                        pdfTable.AddCell(cell);
                    }
                }

                doc.Add(pdfTable);

                AddTimestamp(doc);

                doc.Close();
                writer.Close();
            }
        }

        public static void ExportMembershipReport(string filePath, string clientName, DataRow membershipInfo, DataTable usageHistory)
        {
            using (var stream = new FileStream(filePath, FileMode.Create))
            {
                var doc = new Document(PageSize.A4, 30f, 30f, 30f, 30f);
                PdfWriter.GetInstance(doc, stream);
                doc.Open();

                var title = new Paragraph("MEMBERSHIP REPORT", TitleFont)
                {
                    Alignment = Element.ALIGN_CENTER,
                    SpacingAfter = 20f
                };
                doc.Add(title);

                doc.Add(CreateKeyValuePair("Client Name:", clientName));
                doc.Add(new Paragraph(" ", NormalFont));

                string type = membershipInfo["membership_name"].ToString();
                string club = membershipInfo["club_name"].ToString();
                string start = Convert.ToDateTime(membershipInfo["start_date"]).ToString("dd.MM.yyyy");
                string end = Convert.ToDateTime(membershipInfo["end_date"]).ToString("dd.MM.yyyy");
                string status = membershipInfo["membership_status"].ToString().ToUpper();

                doc.Add(CreateKeyValuePair("Membership Type:", type));
                doc.Add(CreateKeyValuePair("Home Club:", club));
                doc.Add(CreateKeyValuePair("Validity Period:", $"{start} — {end}"));
                doc.Add(CreateKeyValuePair("Current Status:", status));

                doc.Add(new Paragraph(" ", NormalFont));

                var tableHeader = new Paragraph("Usage History (Bookings)", HeaderFont)
                {
                    SpacingAfter = 10f
                };
                doc.Add(tableHeader);

                if (usageHistory != null && usageHistory.Rows.Count > 0)
                {
                    PdfPTable historyTable = new PdfPTable(6);
                    historyTable.WidthPercentage = 100;
                    historyTable.SetWidths(new float[] { 2f, 1.5f, 3.5f, 3f, 1.5f, 2f });

                    historyTable.SpacingAfter = 0f;

                    string[] headers = { "Date", "Time", "Session", "Trainer", "Room", "Status" };
                    foreach (var h in headers)
                    {
                        var cell = new PdfPCell(new Phrase(h, HeaderFont))
                        {
                            BackgroundColor = new BaseColor(230, 230, 230),
                            HorizontalAlignment = Element.ALIGN_CENTER,
                            Padding = 5f
                        };
                        historyTable.AddCell(cell);
                    }

                    foreach (DataRow row in usageHistory.Rows)
                    {
                        string date = Convert.ToDateTime(row["session_date"]).ToString("dd.MM.yyyy");
                        string time = row["start_time"].ToString();
                        string session = row["session_type"].ToString();
                        string trainer = row["trainer_name"].ToString();
                        string room = row["room_number"].ToString();
                        string bookStatus = row["booking_status"].ToString();

                        historyTable.AddCell(new PdfPCell(new Phrase(date, NormalFont)) { Padding = 4f });
                        historyTable.AddCell(new PdfPCell(new Phrase(time, NormalFont)) { Padding = 4f });
                        historyTable.AddCell(new PdfPCell(new Phrase(session, NormalFont)) { Padding = 4f });
                        historyTable.AddCell(new PdfPCell(new Phrase(trainer, NormalFont)) { Padding = 4f });
                        historyTable.AddCell(new PdfPCell(new Phrase(room, NormalFont)) { Padding = 4f });
                        historyTable.AddCell(new PdfPCell(new Phrase(bookStatus, NormalFont)) { Padding = 4f });
                    }

                    doc.Add(historyTable);
                }
                else
                {
                    var noData = new Paragraph("No bookings found for this membership.", NormalFont)
                    {
                        SpacingAfter = 0f,
                        Font = { Color = BaseColor.DARK_GRAY }
                    };
                    doc.Add(noData);
                }

                AddTimestamp(doc);
                doc.Close();
            }
        }

        private static Paragraph CreateKeyValuePair(string label, string value)
        {
            var p = new Paragraph();
            p.Add(new Chunk(label + " ", HeaderFont));
            p.Add(new Chunk(value, NormalFont));
            p.SpacingAfter = 3f;
            return p;
        }

        private static void AddTimestamp(Document doc)
        {
            var p = new Paragraph($"Report generated: {DateTime.Now:dd.MM.yyyy HH:mm}", FooterFont)
            {
                Alignment = Element.ALIGN_LEFT,
                SpacingBefore = 2f 
            };
            doc.Add(p);
        }
    }
}