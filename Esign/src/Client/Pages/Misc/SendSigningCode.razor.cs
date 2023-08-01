using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Application.Requests.Documents;
using Microsoft.AspNetCore.Components;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Esign.Client.Pages.Misc
{
    public partial class SendSigningCode
    {
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }
        private readonly SignDocumentRequest _CodeModel = new();
        void Cancel() => MudDialog.Cancel();
        [Parameter] public AddEditDocumentCommand AddEditDocumentModel { get; set; } = new();
        [Parameter] public List<string> User { get; set; } = new();
        private void OpenSecondDialog()
        {
            DialogService.Show<SignDocument>("enter the code sent to your email to sign the document");
        }
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int CodeLength = 8;


        public string GenerateCodeAsync()
        {
            var random = new Random();
            var codeBuilder = new StringBuilder();


            for (int i = 0; i < CodeLength; i++)
            {
                int index = random.Next(Characters.Length);
                char character = Characters[index];
                codeBuilder.Append(character);
                Console.WriteLine("----------code---------");
                Console.WriteLine(codeBuilder.ToString());
            }
            return codeBuilder.ToString();
        }
        private async Task SubmitAsync()
        {
            _CodeModel.Email = "fabracontrolea@gmail.com";
            _CodeModel.Code = GenerateCodeAsync();
            Console.WriteLine(_CodeModel.Email);
            Console.WriteLine(_CodeModel.Code);
            var result = await _userManager.SendCodeAsyn(_CodeModel);
            if (result.Succeeded)
            {
                _snackBar.Add(_localizer["Code is sent to your email!"], Severity.Success);
                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
                var parameters = new DialogParameters();
                parameters.Add(nameof(SignDocument.AddEditDocumentModel), AddEditDocumentModel);           
                parameters.Add(nameof(SignDocument.code), _CodeModel.Code);
                parameters.Add(nameof(SignDocument.User), User);
                var dialog = _dialogService.Show<SignDocument>(_localizer["enter the code sent to your email to sign the document"], parameters, options);
                var result1 = await dialog.Result;
                MudDialog.Close();
            }
            else
            {
                foreach (var message in result.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                    MudDialog.Close();
                }
            }
            MudDialog.Close();
        }
    }
}
