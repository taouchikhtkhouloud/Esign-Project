// <auto-generated/>
#pragma warning disable 1591
#pragma warning disable 0414
#pragma warning disable 0649
#pragma warning disable 0169

namespace Esign.Client.Shared.Pages
{
    #line hidden
    using System;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;
    using Microsoft.AspNetCore.Components;
#nullable restore
#line 2 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using System.Net.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using System.Net.Http.Json;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 5 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Authorization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 6 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Forms;

#line default
#line hidden
#nullable disable
#nullable restore
#line 7 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Routing;

#line default
#line hidden
#nullable disable
#nullable restore
#line 8 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web;

#line default
#line hidden
#nullable disable
#nullable restore
#line 9 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.Web.Virtualization;

#line default
#line hidden
#nullable disable
#nullable restore
#line 10 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Components.WebAssembly.Http;

#line default
#line hidden
#nullable disable
#nullable restore
#line 11 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.JSInterop;

#line default
#line hidden
#nullable disable
#nullable restore
#line 12 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Microsoft.AspNetCore.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 13 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using MudBlazor;

#line default
#line hidden
#nullable disable
#nullable restore
#line 14 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Blazored.LocalStorage;

#line default
#line hidden
#nullable disable
#nullable restore
#line 15 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Blazored.FluentValidation;

#line default
#line hidden
#nullable disable
#nullable restore
#line 18 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 19 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.RoleClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Preferences;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Interceptors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Catalog.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Catalog.Brand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Dashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Communication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Audit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Misc.Document;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Misc.DocumentType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 34 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Shared.Constants.Permission;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 37 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Shared.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Settings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 42 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Application.Requests.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 44 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Pages.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 46 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Shared\Pages\ZipViewer.razor"
using Syncfusion.Blazor.FileManager;

#line default
#line hidden
#nullable disable
#nullable restore
#line 4 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Shared\Pages\ZipViewer.razor"
using System.Text;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/zip-viewer")]
    public partial class ZipViewer : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 34 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Shared\Pages\ZipViewer.razor"
       
    public string ZipPath { get; set; } = null;
    public string ViewerPath { get; set; }
    public string RootName { get; set; }
    private string PreviewPath { get; set; }
    private string FileName { get; set; }
    private string SubPath { get; set; }
    private string Path { get; set; }
    public string OverlayStyle { get; set; } = "overlayHide";
    private SfFileManager _zipManager;
    private TopToolbar _topToolbar;
    private string SpinnerTarget { get; set; } = "#zipContainer";
    public bool isRootNameChange = true;
    protected override void OnInitialized()
    {
        ViewerPath = "/";
        if (QueryHelpers.ParseQuery(NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query).TryGetValue("path", out var pathparam))
        {
            Path = pathparam.First();
        }
        if (QueryHelpers.ParseQuery(NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query).TryGetValue("preview", out var param))
        {
            FileName = param.First();
            PreviewPath = Path + FileName;
        }
        if (QueryHelpers.ParseQuery(NavigationManager.ToAbsoluteUri(NavigationManager.Uri).Query).TryGetValue("subpath", out var subPathparam))
        {
            SubPath = subPathparam.First();
        }
    }
    private async void AfterCreated()
    {
        ZipPath = PreviewPath;
        string Name = IO.Path.GetFileName(PreviewPath);
        if (_topToolbar.RootName != Name)
        {
            _topToolbar.RootName = RootName = Name;
            isRootNameChange = true;
        }
        string url = NavigationManager.BaseUri + "api/ZipViewer/ExtractZip";
        HttpRequestMessage request = new HttpRequestMessage(HttpMethod.Post, url);
        request.Content = new StringContent(JsonConvert.SerializeObject(new { Path = PreviewPath }), Encoding.UTF8, "application/json");
        HttpResponseMessage response = await Http.SendAsync(request);
        if (response.IsSuccessStatusCode)
        {
            _zipManager.Refresh();
        }
    }
    private void BackClickHandler()
    {
        if (SubPath != null)
        {
            Dictionary<string, string> query = new Dictionary<string, string> { { "preview", PreviewPath } };
            NavigationManager.NavigateTo(QueryHelpers.AddQueryString(NavigationManager.BaseUri + "zip-viewer/", query));
        }
        else
        {
            Dictionary<string, string> query = new Dictionary<string, string> { { "preview", FileName }, { "path", Path } };
            NavigationManager.NavigateTo(QueryHelpers.AddQueryString(NavigationManager.BaseUri, query));
        }
    }
    private void BeforeSend(BeforeSendEventArgs args)
    {
        if (isRootNameChange) { args.Cancel = true; isRootNameChange = false; return; }
        OverlayStyle = "overlayHide";
        if (args.Action == "read")
        {
            string AjaxSettingsString = JsonConvert.SerializeObject(args.AjaxSettings);
            Dictionary<string, dynamic> AjaxSettings = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(AjaxSettingsString);
            string dataString = AjaxSettings["data"];
            Dictionary<string, dynamic> data = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dataString);
            data.Add("ZipPath", ZipPath);
            string modifiedDataString = JsonConvert.SerializeObject(data);
            AjaxSettings["data"] = modifiedDataString;
            string returnString = JsonConvert.SerializeObject(AjaxSettings);
            args.AjaxSettings = JsonConvert.DeserializeObject<object>(returnString);
        }
    }
    private void FileOpen(FileOpenEventArgs args)
    {
        string dataString = JsonConvert.SerializeObject(args.FileDetails);
        Dictionary<string, dynamic> fileDetails = JsonConvert.DeserializeObject<Dictionary<string, dynamic>>(dataString);
        if ((fileDetails["type"] == Constants.Bmp) || (fileDetails["type"] == Constants.Dib) || (fileDetails["type"] == Constants.Jpg) || (fileDetails["type"] == Constants.Jpeg)
            || (fileDetails["type"] == Constants.Jpe) || (fileDetails["type"] == Constants.Jfif) || (fileDetails["type"] == Constants.Gif) || (fileDetails["type"] == Constants.Tif)
            || (fileDetails["type"] == Constants.Tiff) || (fileDetails["type"] == Constants.Png) || (fileDetails["type"] == Constants.Ico))
        {
            args.Cancel = true;
        }
        string filePath = (fileDetails["filterPath"] + fileDetails["name"]);
        Dictionary<string, string> query = new Dictionary<string, string> { { "preview", PreviewPath }, { "subpath", filePath } };
        if (fileDetails["type"] == Constants.Zip)
        {
            NavigationManager.NavigateTo(QueryHelpers.AddQueryString(NavigationManager.BaseUri + "zip-viewer/", query));
        }
        if (fileDetails["type"] == Constants.Pptx)
        {
            NavigationManager.NavigateTo(QueryHelpers.AddQueryString(NavigationManager.BaseUri + "presentation-viewer/", query));
        }
        if (fileDetails["type"] == Constants.Pdf)
        {
            NavigationManager.NavigateTo(QueryHelpers.AddQueryString(NavigationManager.BaseUri + "pdf-viewer/", query));
        }
        if (fileDetails["type"] == Constants.Docx || fileDetails["type"] == Constants.Doc || fileDetails["type"] == Constants.Rtf || fileDetails["type"] == Constants.Txt)
        {
            NavigationManager.NavigateTo(QueryHelpers.AddQueryString(NavigationManager.BaseUri + "word-viewer/", query));
        }
    }

#line default
#line hidden
#nullable disable
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IJSRuntime _jsRuntime { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ILocalStorageService _localStorage { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IUserManager _userManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ClientPreferenceManager _clientPreferenceManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IHttpInterceptorManager _interceptor { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private HttpClient _httpClient { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IDialogService _dialogService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private ISnackbar _snackBar { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthorizationService _authorizationService { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private BlazorHeroStateProvider _stateProvider { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private NavigationManager _navigationManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAccountManager _accountManager { get; set; }
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private IAuthenticationManager _authenticationManager { get; set; }
    }
}
#pragma warning restore 1591