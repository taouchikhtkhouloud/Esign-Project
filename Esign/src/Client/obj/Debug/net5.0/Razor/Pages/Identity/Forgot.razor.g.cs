#pragma checksum "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "7bac0de4927373fee7d5e1b41f1b80aae0c0eedd"
// <auto-generated/>
#pragma warning disable 1591
namespace Esign.Client.Pages.Identity
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
#line 49 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
#nullable restore
#line 3 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
           [AllowAnonymous]

#line default
#line hidden
#nullable disable
    [Microsoft.AspNetCore.Components.LayoutAttribute(typeof(MainLayout))]
    [Microsoft.AspNetCore.Components.RouteAttribute("/account/forgot-password")]
    public partial class Forgot : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 6 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                  _emailModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 6 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                              SubmitAsync

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Blazored.FluentValidation.FluentValidationValidator>(4);
                __builder2.AddComponentReferenceCapture(5, (__value) => {
#nullable restore
#line 7 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                     _fluentValidationValidator = (Blazored.FluentValidation.FluentValidationValidator)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudGrid>(7);
                __builder2.AddAttribute(8, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudItem>(9);
                    __builder3.AddAttribute(10, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 9 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddMarkupContent(12, "<div class=\"d-flex justify-center mt-4\"><img src=\"/logo.png\" alt=\"Logo\" style=\"width: 250px; height: 250px;\"></div>");
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(13, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(14);
                    __builder3.AddAttribute(15, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 14 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(16, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(17, "div");
                        __builder4.AddAttribute(18, "class", "d-flex justify-center");
                        __builder4.OpenComponent<MudBlazor.MudText>(19);
                        __builder4.AddAttribute(20, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 16 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                               Typo.h4

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(21, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(22, 
#nullable restore
#line 16 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                         _localizer["Forgot password?"]

#line default
#line hidden
#nullable disable
                            );
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(23, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(24);
                    __builder3.AddAttribute(25, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 19 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(26, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenElement(27, "div");
                        __builder4.AddAttribute(28, "class", "d-flex justify-center");
                        __builder4.OpenComponent<MudBlazor.MudText>(29);
                        __builder4.AddAttribute(30, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 21 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                               Typo.subtitle2

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(31, "Class", "mb-n4");
                        __builder4.AddAttribute(32, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(33, 
#nullable restore
#line 21 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                              _localizer["Enter email for password reset"]

#line default
#line hidden
#nullable disable
                            );
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.CloseElement();
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(34, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(35);
                    __builder3.AddAttribute(36, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 24 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(37, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __Blazor.Esign.Client.Pages.Identity.Forgot.TypeInference.CreateMudTextField_0(__builder4, 38, 39, 
#nullable restore
#line 25 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                  _localizer["E-mail"]

#line default
#line hidden
#nullable disable
                        , 40, 
#nullable restore
#line 25 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                                               () => _emailModel.Email

#line default
#line hidden
#nullable disable
                        , 41, 
#nullable restore
#line 25 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                                                                                  Variant.Outlined

#line default
#line hidden
#nullable disable
                        , 42, 
#nullable restore
#line 25 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                     _emailModel.Email

#line default
#line hidden
#nullable disable
                        , 43, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => _emailModel.Email = __value, _emailModel.Email)));
                    }
                    ));
                    __builder3.CloseComponent();
                    __builder3.AddMarkupContent(44, "\r\n        ");
                    __builder3.OpenComponent<MudBlazor.MudItem>(45);
                    __builder3.AddAttribute(46, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 27 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                     12

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(47, "Class", "d-flex justify-center");
                    __builder3.AddAttribute(48, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudButton>(49);
                        __builder4.AddAttribute(50, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                Variant.Filled

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(51, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                            !Validated

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(52, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                                Color.Primary

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(53, "Size", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Size>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                                                     Size.Large

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(54, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.ButtonType>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                                                                             ButtonType.Submit

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(55, "FullWidth", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                                                                                                           true

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(56, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.AddContent(57, 
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Identity\Forgot.razor"
                                                                                                                                                                  _localizer["Reset Password"]

#line default
#line hidden
#nullable disable
                            );
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<Forgot> _localizer { get; set; }
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
namespace __Blazor.Esign.Client.Pages.Identity.Forgot
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateMudTextField_0<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.String __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<T>> __arg1, int __seq2, global::MudBlazor.Variant __arg2, int __seq3, T __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg4)
        {
        __builder.OpenComponent<global::MudBlazor.MudTextField<T>>(seq);
        __builder.AddAttribute(__seq0, "Label", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.AddAttribute(__seq2, "Variant", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
