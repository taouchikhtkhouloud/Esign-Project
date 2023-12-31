﻿
using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Application.Features.Documents.Queries.GetAll;
using Esign.Application.Features.Documents.Queries.GetById;
using Esign.Application.Requests.Documents;
using Esign.Client.Infrastructure.Managers.Misc.Document;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using System.Drawing.Imaging;
using System.IO;
using QRCoder;
using System.Drawing;
using Microsoft.JSInterop;
using Net.ConnectCode.BarcodeFontsStandard2D;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.AspNetCore.Components.Forms;
using Esign.Application.Requests;
using System.Security.Claims;

namespace Esign.Client.Pages.Misc
{
    public partial class SignDocument
    {
       

        [Parameter] public int documentId { get; set; }
        [Parameter] public string code { get; set; }

        [Inject] private IDocumentManager DocumentManager { get; set; }
        [Parameter] public AddEditDocumentCommand AddEditDocumentModel { get; set; } = new();
        [Parameter] public List<string> User { get; set; } = new();
        private string Url { get; set; } = "https://translate.google.com/";

        private string enteredCode;
        [Inject] IJSRuntime JSRuntime { get; set; }

        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        //private string GenerateQRCode()
        //{
        //    QRCoder.QRCodeGenerator qrGenerator = new QRCodeGenerator();
        //    QRCodeData qrCodeData = qrGenerator.CreateQrCode(Url, QRCodeGenerator.ECCLevel.Q);
        //    QRCode qrCode = new QRCode(qrCodeData);
        //    Bitmap qrCodeImage = qrCode.GetGraphic(20);

        //    using (MemoryStream ms = new MemoryStream())
        //    {
        //        qrCodeImage.Save(ms, ImageFormat.Png);
        //        byte[] imageBytes = ms.ToArray();
        //        return "data:image/png;base64," + Convert.ToBase64String(imageBytes);
        //    }
        //}

        private async Task EditDocument()
        {
            string documentPath = "../Files/Documents/Northwind Report.pdf";
            byte[] pdfBytes = await JSRuntime.InvokeAsync<byte[]>("editDocument", documentPath);

            //Check if the pdfBytes is not null before saving
            if (pdfBytes != null)
            {
                //Save the PDF bytes as a file on the client-side
                await UploadFiles(pdfBytes, Path.GetFileName(documentPath));
            }
            else
            {
                //Handle the case where pdfBytes is null(e.g., show an error message)
                Console.WriteLine("PDF generation failed.");
            }
        }
      
        private async Task UploadFiles(byte[] pdfBytes, string fileName)
        {
            if (pdfBytes != null)
            {
                var buffer = pdfBytes;
                var extension = Path.GetExtension(fileName);
                var format = "application/octet-stream";
                AddEditDocumentModel.URL = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                AddEditDocumentModel.UploadRequest = new UploadRequest { Data = buffer, UploadType = Application.Enums.UploadType.Document, Extension = extension };

                
            }
        }

        private async Task HandleSubmit()
        {
           
    // Close the PDF document
 
            if (enteredCode == code)
            {
                //try
                //{
                //    Document document = new Document();
                //    string baseDirectory = AppDomain.CurrentDomain.BaseDirectory;
                //    string filePath = Path.Combine(baseDirectory, "test.pdf");
                //    MemoryStream memory = new MemoryStream();
                //    Console.WriteLine(filePath);
                //    string sanitizedFilePath = Path.GetFullPath(filePath);

                //    PdfWriter writer = PdfWriter.GetInstance(document, memory);

                //    // Open the PDF document
                //    document.Open();

                //    // Create a new paragraph with the QR code HTML
                //    Paragraph paragraph = new Paragraph();
                //    paragraph.Font = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 12f);
                //    paragraph.Add(new Chunk("hello world", new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.UNDEFINED, 12f)));
                //    document.Add(paragraph);
                //    Console.WriteLine("---------->", document);
                //    document.Close();
                //    Console.WriteLine("---------->>", memory);
                //}
                //catch (Exception ex)
                //{
                //    Console.WriteLine("------------->Error: " + ex.Message);
                //}

                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
                var parameters = new DialogParameters();
                parameters.Add(nameof(SigningDoc.AddEditDocumentModel), AddEditDocumentModel);
                parameters.Add(nameof(SigningDoc.User), User);
                var dialog = _dialogService.Show<SigningDoc>(_localizer["Define your Qr Code position "], parameters, options);
                var result1 = await dialog.Result;


            }
            else
            {
                // Code doesn't match
                _snackBar.Add("Invalid code entered!", Severity.Error);
            }

            // Close the dialog
            
        }

    }


}


