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
#line 3 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Shared\Pages\Thumbnail.razor"
using DocumentExplorer.Models;

#line default
#line hidden
#nullable disable
#nullable restore
#line 49 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.RouteAttribute("/thumbnail")]
    public partial class Thumbnail : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
        }
        #pragma warning restore 1998
#nullable restore
#line 21 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Shared\Pages\Thumbnail.razor"
      
    private List<ThumbnailImage> ThumbnailImages { get; set; }
    private int _previousImageIndex = 1;
    private int _selectedPage = 1;
    public bool ShowThumbnail { get; set; } = true;
    protected override void OnInitialized()
    {
        ThumbnailImages = new List<ThumbnailImage>();
    }
    private string UpdateSelectionClass(int pageNumber)
    {
        if (pageNumber == _selectedPage)
        {
            return "e-de-thumbnail-active-selection";
        }
        else
        {
            return "";
        }
    }
    public void RenderThumbnail(string[] images)
    {
        ThumbnailImages = new List<ThumbnailImage>();
        for (int i = 1; i <= images.Length; i++)
        {
            ThumbnailImages.Add(new ThumbnailImage(i, images[(i - 1)]));
        }
        StateHasChanged();
    }
    public void GotoPage(int pageNumber)
    {
        _previousImageIndex = pageNumber;
        _selectedPage = pageNumber;
    }
    private async void Select(int pageNumber)
    {
        _selectedPage = pageNumber;
        _previousImageIndex = pageNumber;
        StateHasChanged();
        await GotoSelectedThumbnailPage.InvokeAsync(pageNumber);
    }
    public void SelectFirstPage()
    {
        _selectedPage = 1;
        StateHasChanged();
    }
    [Parameter]
    public EventCallback<int> GotoSelectedThumbnailPage { get; set; }

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