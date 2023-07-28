
using System;
using System.Collections.Generic;
using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Application.Requests;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Blazored.FluentValidation;
using Esign.Application.Features.DocumentTypes.Queries.GetAll;
using Esign.Client.Infrastructure.Managers.Misc.Document;
using Esign.Client.Infrastructure.Managers.Misc.DocumentType;

namespace Esign.Client.Pages.Misc
{
    public partial class AddFolderDocument
    {
        [Inject] private IDocumentManager DocumentManager { get; set; }
        [Inject] private IDocumentTypeManager DocumentTypeManager { get; set; }

        [Parameter] public AddEditDocumentCommand AddEditDocumentModel { get; set; } = new();
        [Parameter] public int DocumentFolderId { get; set; } = new();
        [CascadingParameter] private MudDialogInstance MudDialog { get; set; }

        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        private List<GetAllDocumentTypesResponse> _documentTypes = new();
        private bool arrows = false;
        private bool bullets = false;
        private bool enableSwipeGesture = false;
        private bool autocycle = false;
        private Transition transition = Transition.Slide;
        private static string DefaultDragClass = "relative rounded-lg border-2 border-dashed pa-4 mt-4 mud-width-full mud-height-full z-10";
        private string DragClass = DefaultDragClass;
        private List<string> fileNames = new List<string>();

        private void OnInputFileChanged(InputFileChangeEventArgs e)
        {
            ClearDragClass();
            var files = e.GetMultipleFiles();
            foreach (var file in files)
            {
                fileNames.Add(file.Name);
            }
        }

        private async Task Clear()
        {
            fileNames.Clear();
            ClearDragClass();
            await Task.Delay(100);
        }
        private void Upload()
        {
            //Upload the files here
            Snackbar.Configuration.PositionClass = Defaults.Classes.Position.TopCenter;
            Snackbar.Add("TODO: Upload your files!", Severity.Normal);
        }

        private void SetDragClass()
        {
            DragClass = $"{DefaultDragClass} mud-border-primary";
        }

        private void ClearDragClass()
        {
            DragClass = DefaultDragClass;
        }
        public void Cancel()
        {
            MudDialog.Cancel();
        }

        private async Task SaveAsync()
        {
            var response = await DocumentManager.SaveAsync(AddEditDocumentModel);
            if (response.Succeeded)
            {
                _snackBar.Add(response.Messages[0], Severity.Success);
                MudDialog.Close();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
        }

        private async Task LoadDataAsync()
        {
            await LoadDocumentTypesAsync();
        }

        private async Task LoadDocumentTypesAsync()
        {
            var data = await DocumentTypeManager.GetAllAsync();
            if (data.Succeeded)
            {
                _documentTypes = data.Data;
            }
        }


        private IBrowserFile _file;

        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            _file = e.File;
            if (_file != null)
            {
                var buffer = new byte[_file.Size];
                var extension = Path.GetExtension(_file.Name);
                var format = "application/octet-stream";
                await _file.OpenReadStream(_file.Size).ReadAsync(buffer);
                AddEditDocumentModel.URL = $"data:{format};base64,{Convert.ToBase64String(buffer)}";
                AddEditDocumentModel.UploadRequest = new UploadRequest { Data = buffer, UploadType = Application.Enums.UploadType.Document, Extension = extension };
                bullets = true;
            }
        }

        private async Task<IEnumerable<int>> SearchDocumentTypes(string value)
        {
            // In real life use an asynchronous function for fetching data from an api.
            await Task.Delay(5);

            // if text is null or empty, show complete list
            if (string.IsNullOrEmpty(value))
                return _documentTypes.Select(x => x.Id);

            return _documentTypes.Where(x => x.Name.Contains(value, StringComparison.InvariantCultureIgnoreCase))
                .Select(x => x.Id);
        }
    }
}