
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
using Esign.Application.Features.DocumentTypes.Queries.GetFolder;
using Esign.Application.Features.Documents.Queries.GetByFolderId;

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
        private IEnumerable<GetAllDocumentOrFolderResponse> _pagedData;
        private MudTable<GetAllDocumentOrFolderResponse> _table;
        private GetAllPagedDocumentsRequest request1 = new();
        private List<GetAllDocumentTypesResponse> _documentTypeList = new();
        private List<GetAllDocumentTypesResponse> _documentTypeList2 = new();
        private List<GetDocumentByFolderIdResponse> _document = new();
        private GetAllDocumentTypesResponse _documentType = new();
        private GetAllDocumentTypesResponse _documentType2 = new();
        private List<GetAllDocumentOrFolderResponse> _documentOrFolderList = new();

        private string CurrentUserId { get; set; }
        private int _totalItems;
        private int _currentPage = 1;
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
        bool isOpen;

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

            await Reset();
            await GetDocumentsAndFoldersAsync(int.Parse(id1));
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
        private async Task Reset()
        {
            _documentOrFolderList = new List<GetAllDocumentOrFolderResponse>();
            await GetDocumentsAndFoldersAsync(int.Parse(id1));
        }
        private async Task GetDocumentsAndFoldersAsync(int id1)
        {
            // Get documents
            
            var documentResponse = await DocumentManager.GetByFolderAsync();
            var folderResponse = await DocumentTypeManager.GetAllAsync();
            Console.WriteLine("GetByFolderAsync", documentResponse);
            // Check if documentResponse and folderResponse are not null
            if (documentResponse != null && folderResponse != null)
            {
                Console.WriteLine("GetByFolderAsync", documentResponse);

               

                // Check if documentResponse.Data is not null
                if (documentResponse.Data != null)
                {
                    var documentItems = documentResponse.Data
                        .Where(dt => dt.DocumentTypeId == id1)
                        .Select(f => new GetAllDocumentOrFolderResponse
                        {
                            Id = f.Id,
                            Name = f.Title,
                            Description = f.Description,
                            CreatedOn = f.CreatedOn,
                            CreatedBy = f.CreatedBy,
                            IsDocument = true,
                            status = f.status
                        })
                        .ToList();
                    _document = documentResponse.Data.Where(dt => dt.DocumentTypeId == id1).ToList();

                    var folderItems = folderResponse.Data
                        .Where(dt => dt.Parent ==id1)
                        .Select(f => new GetAllDocumentOrFolderResponse
                        {
                            Id = f.Id,
                            Name = f.Name,
                            Description = f.Description,
                            CreatedOn = f.CreatedOn,
                            CreatedBy = f.CreatedBy,
                            IsDocument = false
                        })
                        .ToList();

                    var combinedList = documentItems.Concat(folderItems).ToList();
                    _documentOrFolderList = combinedList;
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


        private async Task<TableData<GetAllDocumentOrFolderResponse>> ServerReload(TableState state)
        {
            if (!string.IsNullOrWhiteSpace(_searchString))
            {
                state.Page = 0;
            }
            number = int.Parse(id1);
            await LoadData(number, state.Page, state.PageSize, state);
            return new TableData<GetAllDocumentOrFolderResponse> { TotalItems = _totalItems, Items = _pagedData };
        }
        private async Task GetDocumentTypesAsync()
        {
            var response = await DocumentTypeManager.GetAllAsync();
            if (response.Succeeded)
            {
                _documentTypeList2 = response.Data.ToList();
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

            var doc = _document.FirstOrDefault(c => c.Id == documentId);
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
                    status = doc.status,
                    NomSignateur = doc.NomSignateur,
                    PrenomSignateur = doc.PrenomSignateur,
                    FileUrlsSigne = doc.FileUrlsSigne,
                    DateSignature = doc.DateSignature
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
        private async Task GoBack(int id1)
        {
            //number = int.Parse(id1);
            Console.WriteLine("number:", id1);
            var f = _documentTypeList2.FirstOrDefault(c => c.Id == id1);
            if (f != null)
            {

            if (f.Parent == 0)
            {
                
                NavigationManager.NavigateTo($"/document-types");
            }
            else
            {
                await GetDocumentsAndFoldersAsync(f.Parent);
                NavigationManager.NavigateTo($"/files/{f.Parent}");
            }
            }
        }

        private async Task LoadData(int i, int pageNumber, int pageSize, TableState state)
        {
            var request = new GetAllPagedDocumentsRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString };
            var response = await DocumentManager.GetAllAsync(request);
            var request2 = new GetAllPagedDocumentsRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString };
            var folderResponse = await DocumentTypeManager.GetAllAsync2(request2);
            if (response.Succeeded && folderResponse.Succeeded)
            {
                _totalItems = response.TotalCount + folderResponse.TotalCount;
                _currentPage = response.CurrentPage;
                var data = response.Data;
                var loadedData = data.Where(d => d.DocumentTypeId == i).Where(element =>
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
                var folderData = folderResponse.Data.Where(f => f.Parent == i).Where(element =>
                {
                    if (string.IsNullOrWhiteSpace(_searchString))
                        return true;
                    if (element.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    if (element.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
                        return true;
                    return false;
                }); ;
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
                var mergedData = new List<GetAllDocumentOrFolderResponse>();

                foreach (var document in loadedData)
                {
                    mergedData.Add(new GetAllDocumentOrFolderResponse
                    {
                        Id = document.Id,
                        Name = document.Title,
                        Description = document.Description,
                        CreatedOn = document.CreatedOn,
                        CreatedBy = document.CreatedBy,
                        IsDocument = true,
                        status = document.status
                    });
                }
                foreach (var folder in folderData)
                {
                    mergedData.Add(new GetAllDocumentOrFolderResponse
                    {
                        Id = folder.Id,
                        Name = folder.Name,
                        Description = folder.Description,
                        CreatedOn = folder.CreatedOn,
                        CreatedBy = folder.CreatedBy,
                        IsDocument = false
                    });
                }
                data = loadedData.ToList();
               // _document = data;
                _totalItems = loadedData.Count() + folderData.Count();
                _pagedData = mergedData.ToList();
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
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
            var doc = _document.FirstOrDefault(c => c.Id == id);
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
        //private async Task LoadData(int i, int pageNumber, int pageSize, TableState state)
        //{
        //    var request = new GetAllPagedDocumentsRequest { PageSize = pageSize, PageNumber = pageNumber + 2, SearchString = _searchString };
        //    var response = await DocumentManager.GetAllAsync(request);
        //    var folderResponse = await DocumentTypeManager.GetAllAsync2(request);
        //    if (response.Succeeded && folderResponse.Succeeded)
        //    {
        //        _currentPage = response.CurrentPage + folderResponse.CurrentPage;
        //        var data = response.Data;

        //        // Filter documents by parent folder ID
        //        var loadedData = data.Where(d => d.DocumentTypeId == i).Where(element =>
        //                {
        //                    if (string.IsNullOrWhiteSpace(_searchString))
        //                        return true;
        //                    if (element.Title.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        //                        return true;
        //                    if (element.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        //                        return true;
        //                    if (element.DocumentType.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        //                        return true;
        //                    return false;
        //                });
        //        switch (state.SortLabel)
        //        {
        //            case "documentIdField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Id);
        //                break;
        //            case "documentTitleField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Title);
        //                break;
        //            case "documentDescriptionField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Description);
        //                break;
        //            case "documentDateCreatedField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedOn);
        //                break;
        //            case "documentOwnerField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedBy);
        //                break;
        //        }

        //        // Filter folders by parent folder ID
        //        var folderData = folderResponse.Data.Where(f => f.Parent == i).Where(element =>
        //        {
        //            if (string.IsNullOrWhiteSpace(_searchString))
        //                return true;
        //            if (element.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        //                return true;
        //            if (element.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        //                return true;
        //            return false;
        //        }); ;

        //        // Merge folders and documents into a single list
        //        var mergedData = new List<GetAllDocumentOrFolderResponse>();

        //        foreach (var document in loadedData)
        //        {
        //            mergedData.Add(new GetAllDocumentOrFolderResponse
        //            {
        //                Id = document.Id,
        //                Name = document.Title,
        //                Description = document.Description,
        //                CreatedOn = document.CreatedOn,
        //                CreatedBy = document.CreatedBy,
        //                IsDocument = true
        //            });
        //        }

        //        foreach (var folder in folderData)
        //        {
        //            mergedData.Add(new GetAllDocumentOrFolderResponse
        //            {
        //                Id = folder.Id,
        //                Name = folder.Name,
        //                Description = folder.Description,
        //                CreatedOn = folder.CreatedOn,
        //                CreatedBy = folder.CreatedBy,
        //                IsDocument = false
        //            });
        //        }

        //        // Sorting based on the chosen state.SortLabel, similar to your original code

        //        // Update the _totalItems and _pagedData variables
        //        _totalItems = mergedData.Count;
        //        //_pagedData = mergedData.ToList();
        //        var startIndex = (pageNumber - 1) * pageSize;
        //        _pagedData = mergedData.ToList();
        //    }
        //    else
        //    {
        //        foreach (var message in response.Messages)
        //        {
        //            _snackBar.Add(message, Severity.Error);
        //        }
        //    }
        //}

        //private async Task LoadData(int i, int pageNumber, int pageSize, TableState state)
        //{
        //    var request = new GetAllPagedDocumentsRequest { PageSize = pageSize, PageNumber = pageNumber + 1, SearchString = _searchString };
        //    var response = await DocumentManager.GetAllAsync(request);
        //    var folderResponse = await DocumentTypeManager.GetAllAsync();
        //    if (response.Succeeded && folderResponse.Succeeded)
        //    {


        //        var data = response.Data;
        //        var loadedData = data.Where(element => element.DocumentTypeId == i);
        //        switch (state.SortLabel)
        //        {
        //            case "documentIdField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Id);
        //                break;
        //            case "documentTitleField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Title);
        //                break;
        //            case "documentDescriptionField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Description);
        //                break;
        //            case "documentDateCreatedField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedOn);
        //                break;
        //            case "documentOwnerField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedBy);
        //                break;
        //        }


        //        var folderData = folderResponse.Data.Where(element =>
        //            {
        //                if (string.IsNullOrWhiteSpace(_searchString))
        //                    return true;
        //                if (element.Name.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        //                    return true;
        //                if (element.Description.Contains(_searchString, StringComparison.OrdinalIgnoreCase))
        //                    return true;
        //                return false;
        //            }).Where(element => element.Parent == i); ;
        //        switch (state.SortLabel)
        //        {
        //            case "documentIdField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Id);
        //                break;
        //            case "documentTitleField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Title);
        //                break;
        //            case "documentDescriptionField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.Description);
        //                break;
        //            case "documentDateCreatedField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedOn);
        //                break;
        //            case "documentOwnerField":
        //                loadedData = loadedData.OrderByDirection(state.SortDirection, d => d.CreatedBy);
        //                break;
        //        }
        //        // Merge folders and documents into a single list
        //        var mergedData = new List<GetAllDocumentOrFolderResponse>();
        //        foreach (var document in data)
        //        {
        //            mergedData.Add(new GetAllDocumentOrFolderResponse
        //            {
        //                Id = document.Id,
        //                Name = document.Title,
        //                Description = document.Description,
        //                CreatedOn = document.CreatedOn,
        //                CreatedBy = document.CreatedBy,
        //                IsDocument = true
        //            });
        //        }

        //        foreach (var folder in folderData)
        //        {
        //            mergedData.Add(new GetAllDocumentOrFolderResponse
        //            {
        //                Id = folder.Id,
        //                Name = folder.Name,
        //                Description = folder.Description,
        //                CreatedOn = folder.CreatedOn,
        //                CreatedBy = folder.CreatedBy,
        //                IsDocument = false
        //            });
        //        }
        //        //_currentPage = mergedData.CurrentPage;
        //        _totalItems = mergedData.Count;
        //        _document = loadedData.ToList();
        //        _pagedData = mergedData.ToList();
        //    }
        //    else
        //    {
        //        foreach (var message in response.Messages)
        //        {
        //            _snackBar.Add(message, Severity.Error);
        //        }
        //    }
        //}


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
                var doc = _document.FirstOrDefault(c => c.Id == id);
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
                await Reset();
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
        private async Task ViewAsync(int id1)
        {
            // Redirect to the File page
            await GetDocumentsAndFoldersAsync(id1);
            NavigationManager.NavigateTo($"/files/{id1}");
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

    }
}