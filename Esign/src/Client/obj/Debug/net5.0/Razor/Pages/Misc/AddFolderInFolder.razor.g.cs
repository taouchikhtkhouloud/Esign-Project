#pragma checksum "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "831474edc1a3bcd41f883d06f96b177c0f323cd9"
// <auto-generated/>
#pragma warning disable 1591
namespace Esign.Client.Pages.Misc
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
#line 19 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Account;

#line default
#line hidden
#nullable disable
#nullable restore
#line 20 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 21 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Roles;

#line default
#line hidden
#nullable disable
#nullable restore
#line 22 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.RoleClaims;

#line default
#line hidden
#nullable disable
#nullable restore
#line 23 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Identity.Users;

#line default
#line hidden
#nullable disable
#nullable restore
#line 24 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Preferences;

#line default
#line hidden
#nullable disable
#nullable restore
#line 25 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Interceptors;

#line default
#line hidden
#nullable disable
#nullable restore
#line 26 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Catalog.Product;

#line default
#line hidden
#nullable disable
#nullable restore
#line 27 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Catalog.Brand;

#line default
#line hidden
#nullable disable
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Dashboard;

#line default
#line hidden
#nullable disable
#nullable restore
#line 29 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Communication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 30 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Audit;

#line default
#line hidden
#nullable disable
#nullable restore
#line 31 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Misc.Document;

#line default
#line hidden
#nullable disable
#nullable restore
#line 32 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Managers.Misc.DocumentType;

#line default
#line hidden
#nullable disable
#nullable restore
#line 35 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Shared.Constants.Permission;

#line default
#line hidden
#nullable disable
#nullable restore
#line 36 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Shared.Components;

#line default
#line hidden
#nullable disable
#nullable restore
#line 38 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client;

#line default
#line hidden
#nullable disable
#nullable restore
#line 39 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Shared;

#line default
#line hidden
#nullable disable
#nullable restore
#line 40 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Shared.Dialogs;

#line default
#line hidden
#nullable disable
#nullable restore
#line 41 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Settings;

#line default
#line hidden
#nullable disable
#nullable restore
#line 43 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Application.Requests.Identity;

#line default
#line hidden
#nullable disable
#nullable restore
#line 45 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Pages.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 47 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Infrastructure.Authentication;

#line default
#line hidden
#nullable disable
#nullable restore
#line 48 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
using Esign.Client.Extensions;

#line default
#line hidden
#nullable disable
#nullable restore
#line 50 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\_Imports.razor"
[Authorize]

#line default
#line hidden
#nullable disable
    public partial class AddFolderInFolder : Microsoft.AspNetCore.Components.ComponentBase
    {
        #pragma warning disable 1998
        protected override void BuildRenderTree(Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder)
        {
            __builder.OpenComponent<Microsoft.AspNetCore.Components.Forms.EditForm>(0);
            __builder.AddAttribute(1, "Model", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Object>(
#nullable restore
#line 3 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                  AddEditDocumentTypeModel

#line default
#line hidden
#nullable disable
            ));
            __builder.AddAttribute(2, "OnValidSubmit", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Forms.EditContext>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Forms.EditContext>(this, 
#nullable restore
#line 3 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                           SaveAsync

#line default
#line hidden
#nullable disable
            )));
            __builder.AddAttribute(3, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment<Microsoft.AspNetCore.Components.Forms.EditContext>)((context) => (__builder2) => {
                __builder2.OpenComponent<Blazored.FluentValidation.FluentValidationValidator>(4);
                __builder2.AddComponentReferenceCapture(5, (__value) => {
#nullable restore
#line 4 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                     _fluentValidationValidator = (Blazored.FluentValidation.FluentValidationValidator)__value;

#line default
#line hidden
#nullable disable
                }
                );
                __builder2.CloseComponent();
                __builder2.AddMarkupContent(6, "\r\n    ");
                __builder2.OpenComponent<MudBlazor.MudDialog>(7);
                __builder2.AddAttribute(8, "TitleContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
#nullable restore
#line 7 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
              
                if (AddEditDocumentTypeModel.Id == 0)
                {

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<MudBlazor.MudText>(9);
                    __builder3.AddAttribute(10, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 10 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                   Typo.h6

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(11, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudIcon>(12);
                        __builder4.AddAttribute(13, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 11 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                        Icons.Material.Filled.Add

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(14, "Class", "mr-3 mb-n1");
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(15, "\r\n                        ");
                        __builder4.AddContent(16, 
#nullable restore
#line 12 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                         _localizer["Add Folder"]

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
#nullable restore
#line 14 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                }
                else
                {

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<MudBlazor.MudText>(17);
                    __builder3.AddAttribute(18, "Typo", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Typo>(
#nullable restore
#line 17 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                   Typo.h6

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(19, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.OpenComponent<MudBlazor.MudIcon>(20);
                        __builder4.AddAttribute(21, "Icon", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 18 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                        Icons.Material.Filled.Update

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(22, "Class", "mr-3 mb-n1");
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(23, "\r\n                        ");
                        __builder4.AddContent(24, 
#nullable restore
#line 19 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                         _localizer["Update Folder"]

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
#nullable restore
#line 21 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                }
            

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.AddAttribute(25, "DialogContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudGrid>(26);
                    __builder3.AddAttribute(27, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
#nullable restore
#line 26 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                 if (AddEditDocumentTypeModel.Id != 0)
                {

#line default
#line hidden
#nullable disable
                        __builder4.OpenComponent<MudBlazor.MudItem>(28);
                        __builder4.AddAttribute(29, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                 12

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(30, "md", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 28 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                         6

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(31, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __Blazor.Esign.Client.Pages.Misc.AddFolderInFolder.TypeInference.CreateMudTextField_0(__builder5, 32, 33, true, 34, 
#nullable restore
#line 29 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                      () => AddEditDocumentTypeModel.Id

#line default
#line hidden
#nullable disable
                            , 35, 
#nullable restore
#line 29 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                                                            _localizer["Id"]

#line default
#line hidden
#nullable disable
                            , 36, 
#nullable restore
#line 29 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                       AddEditDocumentTypeModel.Id

#line default
#line hidden
#nullable disable
                            , 37, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => AddEditDocumentTypeModel.Id = __value, AddEditDocumentTypeModel.Id)));
                        }
                        ));
                        __builder4.CloseComponent();
#nullable restore
#line 31 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                }

#line default
#line hidden
#nullable disable
                        __builder4.OpenComponent<MudBlazor.MudItem>(38);
                        __builder4.AddAttribute(39, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 32 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                             12

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(40, "md", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 32 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                     6

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(41, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __builder5.OpenComponent<MudBlazor.MudTextField<string>>(42);
                            __builder5.AddAttribute(43, "For", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Linq.Expressions.Expression<System.Func<string>>>(
#nullable restore
#line 33 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                    () => AddEditDocumentTypeModel.Name

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(44, "Label", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.String>(
#nullable restore
#line 33 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                                                              _localizer["Name"]

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(45, "Value", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<string>(
#nullable restore
#line 33 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                       AddEditDocumentTypeModel.Name

#line default
#line hidden
#nullable disable
                            ));
                            __builder5.AddAttribute(46, "ValueChanged", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<string>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<string>(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => AddEditDocumentTypeModel.Name = __value, AddEditDocumentTypeModel.Name))));
                            __builder5.CloseComponent();
                        }
                        ));
                        __builder4.CloseComponent();
                        __builder4.AddMarkupContent(47, "\r\n                ");
                        __builder4.OpenComponent<MudBlazor.MudItem>(48);
                        __builder4.AddAttribute(49, "xs", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 35 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                             12

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(50, "md", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Int32>(
#nullable restore
#line 35 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                     6

#line default
#line hidden
#nullable disable
                        ));
                        __builder4.AddAttribute(51, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder5) => {
                            __Blazor.Esign.Client.Pages.Misc.AddFolderInFolder.TypeInference.CreateMudTextField_1(__builder5, 52, 53, 
#nullable restore
#line 36 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                         () => AddEditDocumentTypeModel.Description

#line default
#line hidden
#nullable disable
                            , 54, 
#nullable restore
#line 36 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                                                                 _localizer["Description"]

#line default
#line hidden
#nullable disable
                            , 55, 
#nullable restore
#line 36 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                   AddEditDocumentTypeModel.Description

#line default
#line hidden
#nullable disable
                            , 56, Microsoft.AspNetCore.Components.EventCallback.Factory.Create(this, Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.CreateInferredEventCallback(this, __value => AddEditDocumentTypeModel.Description = __value, AddEditDocumentTypeModel.Description)));
                        }
                        ));
                        __builder4.CloseComponent();
                    }
                    ));
                    __builder3.CloseComponent();
                }
                ));
                __builder2.AddAttribute(57, "DialogActions", (Microsoft.AspNetCore.Components.RenderFragment)((__builder3) => {
                    __builder3.OpenComponent<MudBlazor.MudButton>(58);
                    __builder3.AddAttribute(59, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 41 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                Variant.Filled

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(60, "OnClick", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<Microsoft.AspNetCore.Components.EventCallback<Microsoft.AspNetCore.Components.Web.MouseEventArgs>>(Microsoft.AspNetCore.Components.EventCallback.Factory.Create<Microsoft.AspNetCore.Components.Web.MouseEventArgs>(this, 
#nullable restore
#line 41 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                         Cancel

#line default
#line hidden
#nullable disable
                    )));
                    __builder3.AddAttribute(61, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(62, 
#nullable restore
#line 41 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                  _localizer["Cancel"]

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
#nullable restore
#line 42 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
             if (AddEditDocumentTypeModel.Id != 0)
            {

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<MudBlazor.MudButton>(63);
                    __builder3.AddAttribute(64, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 44 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                    Variant.Filled

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(65, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.ButtonType>(
#nullable restore
#line 44 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(66, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 44 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                               !Validated

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(67, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 44 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                                   Color.Secondary

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(68, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(69, 
#nullable restore
#line 44 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                                                     _localizer["Update"]

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
#nullable restore
#line 45 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
            }
            else
            {

#line default
#line hidden
#nullable disable
                    __builder3.OpenComponent<MudBlazor.MudButton>(70);
                    __builder3.AddAttribute(71, "Variant", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Variant>(
#nullable restore
#line 48 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                    Variant.Filled

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(72, "ButtonType", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.ButtonType>(
#nullable restore
#line 48 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                ButtonType.Submit

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(73, "Disabled", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<System.Boolean>(
#nullable restore
#line 48 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                               !Validated

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(74, "Color", Microsoft.AspNetCore.Components.CompilerServices.RuntimeHelpers.TypeCheck<MudBlazor.Color>(
#nullable restore
#line 48 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                                   Color.Success

#line default
#line hidden
#nullable disable
                    ));
                    __builder3.AddAttribute(75, "ChildContent", (Microsoft.AspNetCore.Components.RenderFragment)((__builder4) => {
                        __builder4.AddContent(76, 
#nullable restore
#line 48 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
                                                                                                                                   _localizer["Save"]

#line default
#line hidden
#nullable disable
                        );
                    }
                    ));
                    __builder3.CloseComponent();
#nullable restore
#line 49 "C:\Users\KHOULOUD TAOUCHIKHT\Desktop\Files\Coding\WarehouseManger\Esign\src\Client\Pages\Misc\AddFolderInFolder.razor"
            }

#line default
#line hidden
#nullable disable
                }
                ));
                __builder2.CloseComponent();
            }
            ));
            __builder.CloseComponent();
        }
        #pragma warning restore 1998
        [global::Microsoft.AspNetCore.Components.InjectAttribute] private Microsoft.Extensions.Localization.IStringLocalizer<AddEditDocumentTypeModal> _localizer { get; set; }
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
namespace __Blazor.Esign.Client.Pages.Misc.AddFolderInFolder
{
    #line hidden
    internal static class TypeInference
    {
        public static void CreateMudTextField_0<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Boolean __arg0, int __seq1, global::System.Linq.Expressions.Expression<global::System.Func<T>> __arg1, int __seq2, global::System.String __arg2, int __seq3, T __arg3, int __seq4, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg4)
        {
        __builder.OpenComponent<global::MudBlazor.MudTextField<T>>(seq);
        __builder.AddAttribute(__seq0, "Disabled", __arg0);
        __builder.AddAttribute(__seq1, "For", __arg1);
        __builder.AddAttribute(__seq2, "Label", __arg2);
        __builder.AddAttribute(__seq3, "Value", __arg3);
        __builder.AddAttribute(__seq4, "ValueChanged", __arg4);
        __builder.CloseComponent();
        }
        public static void CreateMudTextField_1<T>(global::Microsoft.AspNetCore.Components.Rendering.RenderTreeBuilder __builder, int seq, int __seq0, global::System.Linq.Expressions.Expression<global::System.Func<T>> __arg0, int __seq1, global::System.String __arg1, int __seq2, T __arg2, int __seq3, global::Microsoft.AspNetCore.Components.EventCallback<T> __arg3)
        {
        __builder.OpenComponent<global::MudBlazor.MudTextField<T>>(seq);
        __builder.AddAttribute(__seq0, "For", __arg0);
        __builder.AddAttribute(__seq1, "Label", __arg1);
        __builder.AddAttribute(__seq2, "Value", __arg2);
        __builder.AddAttribute(__seq3, "ValueChanged", __arg3);
        __builder.CloseComponent();
        }
    }
}
#pragma warning restore 1591
