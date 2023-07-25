using Esign.Application.Features.Documents.Queries.GetAll;
using Esign.Application.Requests.Documents;
using Esign.Client.Extensions;
using MudBlazor;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Client.Infrastructure.Managers.Misc.Document;
using Esign.Domain.Entities.Misc;
using Esign.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.JSInterop;
using System.Net.Http;
using System.Text;


namespace Esign.Client.Pages.Misc
{
    public partial class DocumentStore
    {
        [Inject] private IDocumentManager DocumentManager { get; set; }
        [Inject] IJSRuntime JSRuntime { get; set; }


        private IEnumerable<GetAllDocumentsResponse> _pagedData;
        private MudTable<GetAllDocumentsResponse> _table;
        private readonly HttpClient httpClient = new HttpClient();
        private string CurrentUserId { get; set; }
        private int _totalItems;
        private int _currentPage;
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;
       

        private ClaimsPrincipal _currentUser;
        private bool _canCreateDocuments;
        private bool _canEditDocuments;
        private bool _canDeleteDocuments;
        private bool _canSearchDocuments;
        private bool _canViewDocumentExtendedAttributes;
        private bool _loaded;
        private bool IsSigned;
        private string CurrentUserEmail;
        private readonly SignDocumentRequest _CodeModel = new();


        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreateDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Create)).Succeeded;
            _canEditDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Edit)).Succeeded;
            _canDeleteDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Delete)).Succeeded;
            _canSearchDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Search)).Succeeded;
            _canViewDocumentExtendedAttributes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentExtendedAttributes.View)).Succeeded;
            IsSigned = false;
            _loaded = true;

            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            if (user == null) return;
            if (user.Identity?.IsAuthenticated == true)
            {
                CurrentUserId = user.GetUserId();
            }
        }

        private async Task<TableData<GetAllDocumentsResponse>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(_searchString))
            {
                state.Page = 0;
            }
            await LoadData(state.Page, state.PageSize, state);
            return new TableData<GetAllDocumentsResponse> { TotalItems = _totalItems, Items = _pagedData };
        }

        private async Task LoadData(int pageNumber, int pageSize, TableState state)
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
                switch (state.SortLabel)
                {
                    case "documentIdField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Id);
                        break;
                    case "documentTitleField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Title);
                        break;
                    case "documentDescriptionField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Description);
                        break;
                    case "documentDocumentTypeField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, p => p.DocumentType);
                        break;
                    case "documentIsPublicField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.IsPublic);
                        break;
                    case "documentDateCreatedField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedOn);
                        break;
                    case "documentOwnerField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedBy);
                        break;
                }
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

        private void OnSearch(string text)
        {
            _searchString = text;
            _table.ReloadServerData();
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                var doc = _pagedData.FirstOrDefault(c => c.Id == id);
                if (doc != null)
                {
                    parameters.Add(nameof(AddEditDocumentModal.AddEditDocumentModel), new AddEditDocumentCommand
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
                    status = doc.status
                });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditDocumentModal>(id == 0 ? _localizer["Create"] : _localizer["Edit"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }
        
    

        private async Task DownloadFile(string url)
        {
            var fileUrl = url; // Replace with your file URL
            var response = await httpClient.GetAsync(fileUrl);

            if (response.IsSuccessStatusCode)
            {
                var fileName = "file.png"; // Replace with the desired file name
                var content = await response.Content.ReadAsByteArrayAsync();

                // Trigger file download
                await JSRuntime.InvokeVoidAsync("BlazorDownloadFile", fileName, content);
            }
        }
    


    private async Task Delete(int id)
        {
            string deleteContent = _localizer["Delete Content"];
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), string.Format(deleteContent, id)}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>(_localizer["Delete"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var response = await DocumentManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    OnSearch("");
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    OnSearch("");
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }

        private void ManageExtendedAttributes(int documentId)
        {
            _navigationManager.NavigateTo($"/extended-attributes/{typeof(Document).Name}/{documentId}");
        }

        private async Task ViewDoc(int documentId)
        {
            var parameters = new DialogParameters();
           
                var doc = _pagedData.FirstOrDefault(c => c.Id == documentId);
                if (doc != null)
                {
                    parameters.Add(nameof(ViewDocument.AddEditDocumentModel), new AddEditDocumentCommand
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
                        status = doc.status
                    });
                }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };

            var dialog = _dialogService.Show<ViewDocument>(  _localizer["View Document"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }
        private const string Characters = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
        private const int CodeLength = 8;

        
        public  string GenerateCodeAsync()
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
        public async Task<string> CurrentUserE()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync().ConfigureAwait(false);
            var user = state.User;
            if (user.Identity?.IsAuthenticated == true)
            {
                CurrentUserEmail = user.GetEmail();
                Console.WriteLine("----------mail---------");
                Console.WriteLine(CurrentUserEmail);
            }
            return CurrentUserEmail;
        }
        private async Task SubmitAsync(int id)
        {
            //_CodeModel.Email = "fabracontrolea@gmail.com";
            //_CodeModel.Code = GenerateCodeAsync();
            //Console.WriteLine(_CodeModel.Email);
            //Console.WriteLine(_CodeModel.Code);
            //var result = await _userManager.SendCodeAsyn(_CodeModel);
            //if (result.Succeeded)
            //{
            //    _snackBar.Add(_localizer["Code is sent to your email!"], Severity.Success);
                var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
                var parameters = new DialogParameters();
                var doc = _pagedData.FirstOrDefault(c => c.Id == id);
                if (doc != null)
                {
                    parameters.Add(nameof(SendSigningCode.AddEditDocumentModel), new AddEditDocumentCommand
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
                        status = doc.status
                    });
                var dialog = _dialogService.Show<SendSigningCode>(_localizer["Signature Confirmation"], parameters, options);
                }
                //parameters.Add(nameof(SignDocument.code), _CodeModel.Code);
            //var result1 = await dialog.Result;
            
            else
            {
               
                    _snackBar.Add("document is null or dont exist", Severity.Error);
                
            }
        }


    }
}