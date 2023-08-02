using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Esign.Application.Features.DocumentTypes.Commands.AddEdit;
using Esign.Application.Features.DocumentTypes.Queries.GetAll;
using Esign.Application.Requests.Documents;
using Esign.Client.Extensions;
using Esign.Client.Infrastructure.Managers.Misc.DocumentType;
using Esign.Shared.Constants.Application;
using Esign.Shared.Constants.Permission;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.SignalR.Client;
using Microsoft.JSInterop;
using MudBlazor;


namespace Esign.Client.Pages.Misc
{
    public partial class DocumentTypes
    {
        [Inject] private IDocumentTypeManager DocumentTypeManager { get; set; }

        

        [CascadingParameter] private HubConnection HubConnection { get; set; }

        private List<GetAllDocumentTypesResponse> _documentTypeList = new();
        private GetAllDocumentTypesResponse _documentType = new();
        private MudTable<GetAllDocumentTypesResponse> _table;
        private string _searchString = "";
        private bool _dense = false;
        private bool _striped = true;
        private bool _bordered = false;

        private ClaimsPrincipal _currentUser;
        private bool _canCreateDocumentTypes;
        private bool _canViewDocumentTypes;
        private bool _canEditDocumentTypes;
        private bool _canDeleteDocumentTypes;
        private bool _canExportDocumentTypes;
        private bool _canSearchDocumentTypes;
        private bool _loaded;
        private int _totalItems;
        private int _currentPage = 1;
        private IEnumerable<GetAllDocumentTypesResponse> _pagedData;
        protected override async Task OnInitializedAsync()
        {
            _currentUser = await _authenticationManager.CurrentUser();
            _canCreateDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Create)).Succeeded;
            _canViewDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.View)).Succeeded;

            _canEditDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Edit)).Succeeded;
            _canDeleteDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Delete)).Succeeded;
            _canExportDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Export)).Succeeded;
            _canSearchDocumentTypes = (await _authorizationService.AuthorizeAsync(_currentUser, Permissions.DocumentTypes.Search)).Succeeded;
            await Reset();
            await GetDocumentTypesAsync();
            _loaded = true;
            HubConnection = HubConnection.TryInitialize(_navigationManager);
            if (HubConnection.State == HubConnectionState.Disconnected)
            {
                await HubConnection.StartAsync();
            }
        }
        private async Task<TableData<GetAllDocumentTypesResponse>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(_searchString))
            {
                state.Page = 0;
            }
            await LoadData(state.Page, state.PageSize, state);
            return new TableData<GetAllDocumentTypesResponse> { TotalItems = _totalItems, Items = _pagedData };
        }

        private async Task LoadData(int pageNumber, int pageSize, TableState state)
        {
            var request2 = new GetAllPagedDocumentsRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString };
            var response = await DocumentTypeManager.GetAllAsync2(request2);
            if (response.Succeeded)
            {
                _totalItems = response.TotalCount;
                _currentPage = response.CurrentPage;
                var data = response.Data;
                var loadedData = data.Where(element =>
                {
                    if (string.IsNullOrWhiteSpace(_searchString))
                        return true;
                    if (element.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (element.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    return false;
                });
                switch (state.SortLabel)
                {
                    case "documentIdField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Id);
                        break;
                    case "documentTitleField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Name);
                        break;
                    case "documentDescriptionField":
                        loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Description);
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
        private async Task GetDocumentTypesAsync()
        {
            var response = await DocumentTypeManager.GetAllAsync();
            if (response.Succeeded)
            {
                _documentTypeList = response.Data.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }
        private  void View(int id1 )
        {
            // Redirect to the File page
            NavigationManager.NavigateTo($"/files/{id1}");
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
                var response = await DocumentTypeManager.DeleteAsync(id);
                if (response.Succeeded)
                {
                    OnSearch("");
                    await HubConnection.SendAsync(ApplicationConstants.SignalR.SendUpdateDashboard);
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
        private void OnSearch(string text)
        {
            _searchString = text;
            _table.ReloadServerData();
        }
        private async Task ExportToExcel()
        {
            var response = await DocumentTypeManager.ExportToExcelAsync(_searchString);
            if (response.Succeeded)
            {
                await _jsRuntime.InvokeVoidAsync("Download", new
                {
                    ByteArray = response.Data,
                    FileName = $"{nameof(DocumentTypes).ToLower()}_{DateTime.Now:ddMMyyyyHHmmss}.xlsx",
                    MimeType = ApplicationConstants.MimeTypes.OpenXml
                });
                _snackBar.Add(string.IsNullOrWhiteSpace(_searchString)
                    ? _localizer["Document Types exported"]
                    : _localizer["Filtered Document Types exported"], Severity.Success);
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        private async Task InvokeModal(int id = 0)
        {
            var parameters = new DialogParameters();
            if (id != 0)
            {
                _documentType = _pagedData.FirstOrDefault(c => c.Id == id);
                if (_documentType != null)
                {
                    parameters.Add(nameof(AddEditDocumentTypeModal.AddEditDocumentTypeModel), new AddEditDocumentTypeCommand
                    {
                        Id = _documentType.Id,
                        Name = _documentType.Name,
                        Description = _documentType.Description
                    });
                }
            }
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<AddEditDocumentTypeModal>(id == 0 ? _localizer["Create"] : _localizer["Edit"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                OnSearch("");
            }
        }

        private async Task Reset()
        {
            _documentType = new GetAllDocumentTypesResponse();
            await GetDocumentTypesAsync();
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
    }
}
