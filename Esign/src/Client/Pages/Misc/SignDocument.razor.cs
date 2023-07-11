
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

namespace Esign.Client.Pages.Misc
{
    public partial class SignDocument
    {
       

        [Parameter] public int documentId { get; set; }
        [Parameter] public string code { get; set; }

        [Inject] private IDocumentManager DocumentManager { get; set; }

        private string enteredCode;
        private IEnumerable<GetAllDocumentsResponse> _pagedData;
        private GetDocumentByIdQuery docById = new();
      


        private async Task LoadData()
        {
            var request = new GetAllPagedDocumentsRequest { };
            var response = await DocumentManager.GetAllAsync(request);
            if (response.Succeeded)
            {

                _pagedData = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task HandleSubmit()
        {
            if (enteredCode == code)
            {
                // Code matches, sign the document
                // Add your sign document logic here
                docById.Id = documentId;
                //var doc = DocumentManager.GetByIdAsync(docById);
                await LoadData();
                var doc = _pagedData.FirstOrDefault(c => c.Id == documentId);
                doc.status = true;
               
                var document = new AddEditDocumentCommand
                {
                    Id = doc.Id,
                    Title = doc.Title,
                    Description = doc.Description,
                    URL = doc.URL,
                    IsPublic = doc.IsPublic,
                    DocumentTypeId = doc.DocumentTypeId,
                    Client = doc.Client,
                    Value = doc.Value,
                    fileType = doc.fileType,
                    keywords = doc.keywords,
                    status = true
                };
                var response = await DocumentManager.SaveAsync(document);
                if (response.Succeeded)
                {
                    _snackBar.Add("Document signed successfully!", Severity.Success);

                }
                else
                {
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
               
               
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


