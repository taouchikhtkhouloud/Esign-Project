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
using Esign.Application.Features.DocumentTypes.Queries.GetAll;
using Esign.Client.Infrastructure.Managers.Misc.DocumentType;
using Esign.Application.Features.DocumentTypes.Commands.AddEdit;
using Microsoft.AspNetCore.SignalR.Client;
using Esign.Shared.Constants.Application;

namespace Esign.Client.Pages.Misc
{
    public partial class ViewFolder
    {
        [Inject] private IDocumentManager DocumentManager { get; set; }
        [Inject] private IDocumentTypeManager DocumentTypeManager { get; set; }

        [Parameter]
        public string id1 { get; set; }

        [CascadingParameter] private HubConnection HubConnection { get; set; }



      
        public int number;
        private IEnumerable<GetAllDocumentsResponse> _pagedData;
        private MudTable<GetAllDocumentsResponse> _table;

        private List<GetAllDocumentTypesResponse> _documentTypeList = new();
        private GetAllDocumentTypesResponse _documentType = new();
        private GetAllDocumentTypesResponse _documentType2 = new();
        private string CurrentUserId { get; set; }
        private int _totalItems;
        private int _currentPage;
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreateDocuments;
        private bool _canCreateDocumentTypes;
        private bool _canEditDocuments;
        private bool _canDeleteDocuments;
        private bool _canSearchDocuments;
        private bool _canViewDocumentExtendedAttributes;
        private bool _loaded;
        
        private bool _canEditDocumentTypes;
        private bool _canDeleteDocumentTypes;
        private bool _canExportDocumentTypes;
        private bool _canSearchDocumentTypes;

        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreateDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Create)).Succeeded;
            _canCreateDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Create)).Succeeded;
            _canEditDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Edit)).Succeeded;
            _canDeleteDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Delete)).Succeeded;
            _canExportDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Export)).Succeeded;
            _canSearchDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Search)).Succeeded;

            _canEditDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Edit)).Succeeded;
            _canDeleteDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Delete)).Succeeded;
            _canSearchDocuments = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.Documents.Search)).Succeeded;
            _canViewDocumentExtendedAttributes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentExtendedAttributes.View)).Succeeded;

            _loaded = true;
            
            await GetDocumentTypesAsync();
            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            if (user == null) return;
            if (user.Identity?.IsAuthenticated == true)
            {
                CurrentUserId = user.GetUserId();
            }
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }

        private async Task<TableData<GetAllDocumentsResponse>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(_searchString))
            {
                state.Page = 0;
            }
            number = int.Parse(id1);
            await LoadData(number, state.Page, state.PageSize, state);
            return new TableData<GetAllDocumentsResponse> { TotalItems = _totalItems, Items = _pagedData };
        }
        private async Task GetDocumentTypesAsync()
        {
            var response = await DocumentTypeManager.GetAllAsync();
            if (response.Succeeded)
            {
                _documentTypeList = response.Data.Where(dt => dt.Parent == int.Parse(id1)).ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
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

            var dialog = _dialogService.Show<ViewDocument>(_localizer["View Document"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }
        private async Task LoadData(int i ,int pageNumber, int pageSize, TableState state)
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
                }).Where(element => element.DocumentTypeId == i); ;
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
                    parameters.Add(nameof(AddFolderDocument.AddEditDocumentModel), new AddEditDocumentCommand
                    {
                        Id = doc.Id,
                        Title = doc.Title,
                        Description = doc.Description,
                        URL = doc.URL,
                        IsPublic = doc.IsPublic,
                        DocumentTypeId = int.Parse(id1),
                        Client = doc.Client,
                        Value = doc.Value,
                        fileType = doc.fileType,
                        keywords = doc.keywords,
                        status = doc.status
                });
                }
            }
            parameters.Add(nameof(AddFolderDocument.DocumentFolderId), int.Parse(id1));
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Medium, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddFolderDocument>(id == 0 ? _localizer["Create"] : _localizer["Edit"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }
        private async Task InvokeModalFolder(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                _documentType = _documentTypeList.FirstOrDefault(c => c.Id == id);
                if (_documentType != null)
                {
                    parameters.Add(nameof(AddFolderInFolder.AddEditDocumentTypeModel), new AddEditDocumentTypeCommand
                    {
                        Id = _documentType.Id,
                        Name = _documentType.Name,
                        Description = _documentType.Description
                        
                    });
                }
            }
            parameters.Add(nameof(AddFolderInFolder.DocumentFolderId), int.Parse(id1));
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddFolderInFolder>(id == 0 ? _localizer["Create"] : _localizer["Edit"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                await Reset();
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
        private bool Search(GetAllDocumentTypesResponse brand)
        {
            if (string.IsNullOrWhiteSpace(_searchString)) return true;
            if (brand.Name?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            if (brand.Description?.Contains(_searchString, StringComparison.OrdinalIgnoreCase) == true)
            {
                return true;
            }
            return false;
        }
        private void View(int id1)
        {
            // Redirect to the File page
            NavigationManager.NavigateTo($"/files/{id1}", forceLoad: true);
        }
        private async Task Reset()
        {
            _documentType = new GetAllDocumentTypesResponse();
            await GetDocumentTypesAsync();
        }
        private async Task DeleteFolder(int id)
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
                var response = await DocumentTypeManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    await Reset();
                    await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
                    _snackBar.Add(response.Messages[0], Severity.Success);
                }
                else
                {
                    await Reset();
                    foreach (var message in response.Messages)
                    {
                        _snackBar.Add(message, Severity.Error);
                    }
                }
            }
        }

    }
}