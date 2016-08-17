using MigraDoc.DocumentObjectModel;
using MigraDoc.Rendering;
using PdfSharp.Pdf;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Base_Oversight_Accumulator.LocalStorage
{
    /// <summary>
    /// ReportGenerator -- Converts text file to PDF using MigraDoc library.
    /// </summary>
  
    class ReportGenerator
    {
        static Document CreateDocument()
        {
            string line = null;
            Document document = new Document();
            Section section = document.AddSection();
            Paragraph paragraph = section.AddParagraph();
            paragraph.Format.Font.Color = Colors.Black;
            System.IO.TextReader readFile = new StreamReader("reports\\temp.txt");


            while (true)
            {
                line = readFile.ReadLine();
                if (line == null)
                {
                    break;
                }
                else
                {
                    paragraph.AddText(line);

                }
            }

            return document;
        }

        public void GenerateReport()
        {
            Document document = CreateDocument();
            const bool unicode = true;
            const PdfFontEmbedding embedding = PdfFontEmbedding.None;
            PdfDocumentRenderer pdfRenderer = new PdfDocumentRenderer(unicode, embedding);
            pdfRenderer.Document = document;
            pdfRenderer.RenderDocument();
            int RandomFileName;
            Random x = new Random();
            RandomFileName = x.Next(1, 1000000000);
            string filename = "reports\\" + RandomFileName.ToString() + ".pdf";
            pdfRenderer.PdfDocument.Save(filename);
            File.Delete("reports\\temp.txt");
            Process.Start(filename);
        }
    }
}
