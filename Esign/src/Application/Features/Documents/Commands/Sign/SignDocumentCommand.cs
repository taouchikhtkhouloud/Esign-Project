using AutoMapper;
using Esign.Application.Interfaces.Repositories;
using Esign.Application.Interfaces.Services;
using Esign.Domain.Entities.Misc;
using Esign.Shared.Wrapper;
using iTextSharp.text;
using iTextSharp.text.pdf;
using iTextSharp.text.pdf.parser;
using MediatR;
using Microsoft.Extensions.Localization;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Esign.Application.Features.Documents.Commands.Sign
{
    public partial class SignDocumentCommand : IRequest<Result<string>>
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string nom { get; set; }
        [Required]
        public string prenom { get; set; }
        [Required]
        public int Hauteur { get; set; }
        [Required]
        public int Largeur { get; set; }
        [Required]
        public bool isRight { get; set; }
        [Required]
        public bool isTop { get; set; }
        [Required]
        public bool allPages { get; set; }
    }
    internal class AddEditDocumentCommandHandler : IRequestHandler<SignDocumentCommand, Result<string>>
    {
        private readonly IMapper _mapper;
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IUploadService _uploadService;
        private readonly IStringLocalizer<AddEditDocumentCommandHandler> _localizer;

        public AddEditDocumentCommandHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IUploadService uploadService, IStringLocalizer<AddEditDocumentCommandHandler> localizer)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _uploadService = uploadService;
            _localizer = localizer;
        }

        public async Task<Result<string>> Handle(SignDocumentCommand command, CancellationToken cancellationToken)
        {
            var code_url = Guid.NewGuid().ToString("N");
            var signed = $"https://localhost:44398/Validation_document/{code_url}";

           //var taille = _context.TailleQrcodes.FirstOrDefault();
            var Hauteur = command.Hauteur;
            var Largeur = command.Largeur;

            //var position = _context.PositionQrCodes.FirstOrDefault();
            //var textx = position.TextX;
            //var textz = position.TextZ;
            //var positionx = position.PositionQrcX;
            //var positionz = position.PositionQrcZ;

            // Mise en forme du code QR
            BarcodeQRCode qr = new BarcodeQRCode(signed, Hauteur, Largeur, null);
            var imgQR = qr.GetImage();

            //await TailleQrcode();

            var document = await _unitOfWork.Repository<Domain.Entities.Misc.Document>().GetByIdAsync(command.Id);

            var folderName = "";
            var fileStorage = "Files\\Documents\\Dossier\\";

            var filePath = System.IO.Path.Combine(folderName, document.URL);
            var filePathS = System.IO.Path.Combine(fileStorage, $"{code_url}.pdf");

            PdfReader reader = new PdfReader(filePath);
            for (int i = 1; i <= reader.NumberOfPages; i++)
            {
                string text = PdfTextExtractor.GetTextFromPage(reader, i, new SimpleTextExtractionStrategy());
                string[] lines = text.Split(new string[] { "\r\n", "\n" }, StringSplitOptions.None);
                //foreach (string line in lines)
                //{
                //    Console.WriteLine(line);
                //}

                //if (i == 1)
                //{
                    
                //}
            }
            if (!command.allPages)
            {
                FileStream fs = new FileStream(filePathS, FileMode.Create, FileAccess.Write, FileShare.None);
                PdfStamper stamper = new PdfStamper(reader, fs);
                PdfContentByte cb = stamper.GetOverContent(1);

                Phrase phrase = new Phrase("");

                Rectangle pageSize = reader.GetPageSize(1);
                //float textX = pageSize.Left + textx;
                //float textY = pageSize.Bottom + textz;
                // Positionnement du code QR
                imgQR.SetAbsolutePosition(0, 0);
                cb.AddImage(imgQR);


                ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, phrase, 0, 0, 0);
                // Enregistrement du fichier modifié
                stamper.Close();
                fs.Close();
            }
            else
            {
                    FileStream fs = new FileStream(filePathS, FileMode.Create, FileAccess.Write, FileShare.None);
                    PdfStamper stamper = new PdfStamper(reader, fs);
                for(int j=1; j <= reader.NumberOfPages; j++)
                {
                    PdfContentByte cb = stamper.GetOverContent(j);

                    Phrase phrase = new Phrase("");

                    Rectangle pageSize = reader.GetPageSize(j);
                    //float textX = pageSize.Left + textx;
                    //float textY = pageSize.Bottom + textz;
                    // Positionnement du code QR
                    imgQR.SetAbsolutePosition(0, 0);
                    cb.AddImage(imgQR);


                    ColumnText.ShowTextAligned(cb, Element.ALIGN_RIGHT, phrase, 0, 0, 0);
                    // Enregistrement du fichier modifié
                }
                    stamper.Close();
                fs.Close();
            }
            document.NomSignateur = command.nom;
            document.PrenomSignateur = command.prenom;
            document.FileUrlsSigne = filePathS;
            document.DateSignature = DateTime.Now;
            document.CodeSignature = code_url;
            document.status=true;
            await _unitOfWork.Repository<Domain.Entities.Misc.Document>().UpdateAsync(document);
           
            return await Result<string>.SuccessAsync("le document a été signé");
        }
    }
}
