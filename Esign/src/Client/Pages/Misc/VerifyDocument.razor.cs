using Esign.Application.Features.Documents.Queries.GetByFolderId;
using Esign.Client.Infrastructure.Managers.Misc.Document;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Esign.Client.Pages.Misc
{
    public partial class VerifyDocument
    {
        [Inject] private IDocumentManager DocumentManager { get; set; }

        [Parameter] public string valeurCode { get; set; }

        protected GetDocumentByFolderIdResponse document { get; set; } = new();


        private List<GetDocumentByFolderIdResponse> _document = new();
        protected override async Task OnInitializedAsync()
        {
            await GetDocumentsAndFoldersAsync();
            await VerificationDoc(valeurCode);
            //await LoadDataAsync();
        }

        private async Task VerificationDoc(string id)
        {

            if (_document != null)
            {
                Console.WriteLine("documet lwl --->", _document.FirstOrDefault());
                    document = _document.FirstOrDefault();



               
            }
            else
            {
                _snackBar.Add("Error: Unable to retrieve data fron _document.", Severity.Error);
            }

        }
        private async Task GetDocumentsAndFoldersAsync()
        {
            // Get documents

            var documentResponse = await DocumentManager.GetByFolderAsync();
            Console.WriteLine("GetByFolderAsync", documentResponse);
            // Check if documentResponse and folderResponse are not null
            if (documentResponse != null )
            {
                Console.WriteLine("GetByFolderAsync", documentResponse);



                // Check if documentResponse.Data is not null
                if (documentResponse.Data != null)
                {
                   
                    _document = documentResponse.Data.Where(el=>el.CodeSignature==valeurCode).ToList();

                   
                }
                else
                {
                    // Handle the case when documentResponse.Data is null
                    _snackBar.Add("Error: Unable to retrieve documents data.", Severity.Error);
                }
            }
            else
            {
                _snackBar.Add("Error: Unable to retrieve data.", Severity.Error);
            }
        }




    }
}
