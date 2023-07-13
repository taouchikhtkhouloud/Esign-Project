
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
        [Parameter] public AddEditDocumentCommand AddEditDocumentModel { get; set; } = new();

        private string enteredCode;
        private IEnumerable<GetAllDocumentsResponse> _pagedData;
        private GetDocumentByIdQuery docById = new();
        private int _totalItems;
        private int _currentPage;
        private string _searchString = "";


        private async Task LoadData(int pageNumber, int pageSize)
        {
            var request = new GetAllPagedDocumentsRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString };
            var response = await DocumentManager.GetAllAsync(request);
            if (response.Succeeded)
            {
                _totalItems = response.TotalCount;
                _currentPage = response.CurrentPage;
                var data = response.Data;
                var loadedData = data.Where(element =>
                {
                    if (string.IsNullOrWhiteSpace(_searchString))
                        return true;
                    if (element.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (element.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (element.DocumentType.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    return false;
                });
               
                data = loadedData.ToList();
                _pagedData = data;
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
                //docById.Id = documentId;
                ////var doc = DocumentManager.GetByIdAsync(docById);
                //await LoadData(2,100);
                //var doc = _pagedData.FirstOrDefault(c => c.Id == documentId);

                //Console.WriteLine("---------->",doc);
                //var document = new AddEditDocumentCommand
                //{
                //    Id = doc.Id,
                //    Title = doc.Title,
                //    Description = doc.Description,
                //    URL = doc.URL,
                //    IsPublic = doc.IsPublic,
                //    DocumentTypeId = doc.DocumentTypeId,
                //    Client = doc.Client,
                //    Value = doc.Value,
                //    fileType = doc.fileType,
                //    keywords = doc.keywords,
                //    status = true
                //};
                //var response = await DocumentManager.SaveAsync(document);
                AddEditDocumentModel.status = true;
                var response = await DocumentManager.SaveAsync(AddEditDocumentModel);
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


