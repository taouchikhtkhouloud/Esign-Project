using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Application.Features.Documents.Commands.Sign;
using Esign.Client.Infrastructure.Managers.Misc.Document;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Esign.Client.Pages.Misc
{
    public partial class SigningDoc
    {


        [Inject] private IDocumentManager DocumentManager { get; set; }
        [Parameter] public AddEditDocumentCommand AddEditDocumentModel { get; set; } = new();

        [Parameter] public List<string> User { get; set; } = new();
        private SignDocumentCommand signDocument { get; set; } = new();
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private ClaimsPrincipal _currentUser;
        private string CurrentUserName;
        private string CurrentUserNameL;

        //protected override async Task OnInitializedAsync()
        //{
        //    _currentUser = await _authenticationManager.CurrentUser();

            
        //    var state = await _stateProvider.GetAuthenticationStateAsync();
        //    var user = state.User;
        //    if (user == null) return;
        //    if (user.Identity?.IsAuthenticated == true)
        //    {
        //        CurrentUserName = user.();
        //    }
        //}
        private async Task HandleSubmit()
        {

            // Close the PDF document



            signDocument.nom = User[0];
            signDocument.prenom = User[1];
            signDocument.Id = AddEditDocumentModel.Id;
            var response = await DocumentManager.SignDocument(signDocument);
                if (response.Succeeded)
                {
                    _snackBar.Add("Document signed successfully!", Severity.Success);
                    MudDialog.Close();
                }
                else
                {
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }


            // Close the dialog

        }
    }
}
