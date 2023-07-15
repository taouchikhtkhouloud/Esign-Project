//using iText.Kernel.Font;
//using iText.Kernel.Pdf;
//using iText.Layout;
//using iText.Layout.Element;
//using iText.Layout.Properties;
//using System.IO;

//namespace Esign.Client.Extensions
//{
//    public class PdfGenerator
//    {
//        public static void GeneratePdf(string fileName, string title, string body)
//        {
//            //Create a new document
//            using (PdfWriter writer = new PdfWriter(fileName))
//            {
//                using (PdfDocument pdf = new PdfDocument(writer))
//                {
//                    //Open the document
//                    Document document = new Document(pdf);

//                    //Add a title
//                    PdfFont titleFont = PdfFontFactory.CreateFont(FontConstants.HELVETICA_BOLD);
//                    Paragraph titleParagraph = new Paragraph(title).SetFont(titleFont).SetFontSize(18).SetTextAlignment(TextAlignment.CENTER);
//                    document.Add(titleParagraph);

//                    //Add some text
//                    PdfFont bodyFont = PdfFontFactory.CreateFont(FontConstants.HELVETICA);
//                    Paragraph bodyParagraph = new Paragraph(body).SetFont(bodyFont).SetFontSize(12).SetTextAlignment(TextAlignment.JUSTIFIED);
//                    document.Add(bodyParagraph);

//                    //Close the document
//                    document.Close();
//                }
//            }
//        }
//    }
//}
