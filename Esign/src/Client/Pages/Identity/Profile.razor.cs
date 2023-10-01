using Esign.Application.Requests.Identity;
using Esign.Client.Extensions;
using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.Forms;
using MudBlazor;
using System;
using System.IO;
using System.Threading.Tasks;
using Blazored.FluentValidation;
using Esign.Shared.Constants.Storage;
using System.IO;
using Esign.Client.Extensions;
using System;
using iText.Kernel.Pdf;
using iText.Layout;
using iText.Layout.Element;
using iText.Layout.Properties;
using Microsoft.JSInterop;

namespace Esign.Client.Pages.Identity
{
    public partial class Profile
    {
        private FluentValidationValidator _fluentValidationValidator;
        private bool Validated => _fluentValidationValidator.Validate(options => { options.IncludeAllRuleSets(); });
        private char _firstLetterOfName;
        private readonly UpdateProfileRequest _profileModel = new();
        [Inject] IJSRuntime JSRuntime { get; set; }

        public string UserId { get; set; }

        private async Task UpdateProfileAsync()
        {
            var response = await _accountManager.UpdateProfileAsync(_profileModel);
            if (response.Succeeded)
            {
                await _authenticationManager.Logout();
                _snackBar.Add(_localizer["Your Profile has been updated. Please Login to Continue."], Severity.Success);
                _navigationManager.NavigateTo("/");
            }
            else
            {
                foreach (var message in response.Messages)
                {
                    _snackBar.Add(message, Severity.Error);
                }
            }
        }

        public const string pdfPath = "../../test.pdf";

        //private async Task EditDocument()
        //{
        //    string documentPath = "../test.pdf";
        //    byte[] pdfBytes = await JSRuntime.InvokeAsync<byte[]>("editDocument", documentPath);

        //    // Check if the pdfBytes is not null before saving
        //    if (pdfBytes != null)
        //    {
        //        // Save the PDF bytes as a file on the client-side
        //        await Profile.SaveAs(JSRuntime, pdfPath, pdfBytes);
        //    }
        //    else
        //    {
        //        // Handle the case where pdfBytes is null (e.g., show an error message)
        //        Console.WriteLine("PDF generation failed.");
        //    }
        //}


        //public static async Task SaveAs(IJSRuntime jsRuntime, string filePath, byte[] fileBytes)
        //{
        //    // Convert the file bytes to a Base64 string
        //    var base64File = Convert.ToBase64String(fileBytes);

        //    // Invoke the JavaScript function to save the file
        //    await jsRuntime.InvokeVoidAsync("saveAsFile", filePath, base64File);
        //}
        public void ModifyPdf(string filePath)
        {
            try
            {
                // Open the existing PDF file
                PdfDocument pdfDoc = new PdfDocument(new PdfReader(filePath), new PdfWriter("modified.pdf"));
                // Initialize document to write modifications
                using (var document = new Document(pdfDoc))
                {
                    // Modify the PDF content here

                    // For example, let's add a new paragraph to the first page
                    document.Add(new Paragraph("This is a modified PDF"));

                    // Close the document
                    document.Close();
                }

                Console.WriteLine("PDF modified successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while modifying the PDF: " + ex.Message);
            }
        }

        private void GenerateModifiedPdf()
        {
            try
            {
                FileInfo file = new FileInfo(pdfPath);
                if (file.Exists)
                {
                    new Profile().ModifyPdf(pdfPath);
                }
                else
                {
                    Console.WriteLine("The specified PDF file does not exist.");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the modified PDF: " + ex.Message);
            }
        }
        public void CreatePdf(string dest)
        {
            try
            {
                // Initialize PDF writer
                PdfWriter writer = new PdfWriter(dest);
                // Initialize PDF document
                PdfDocument pdf = new PdfDocument(writer);
                // Initialize document
                Document document = new Document(pdf);
                // Add paragraph to the document
                document.Add(new Paragraph("Hello World!"));
                Console.WriteLine("-----------------------");
                Console.WriteLine(document);
                // Close document
                document.Close();
                Console.WriteLine("PDF created successfully.");
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while creating the PDF: " + ex.Message);
            }
        }

        private void GeneratePdf()
        {
            try
            {
                //FileInfo file = new FileInfo(pdfPath);
                //Console.WriteLine("---------------------->", file);
                //Directory.CreateDirectory(Path.GetDirectoryName(pdfPath));
                new Profile().CreatePdf(pdfPath);
            }
            catch (Exception ex)
            {
                Console.WriteLine("An error occurred while generating the PDF: " + ex.Message);
            }
        }
        protected override async Task OnInitializedAsync()
        {
            await LoadDataAsync();
            PdfWriter writer = new PdfWriter("C:\\Users\\KHOULOUD TAOUCHIKHT\\Downloads\\zft.pdf");
            PdfDocument pdf = new PdfDocument(writer);
            Document document = new Document(pdf);
            Paragraph header = new Paragraph("HEADER")
               .SetTextAlignment(TextAlignment.CENTER)
               .SetFontSize(20);

            document.Add(header);
            document.Close();
        }

        private async Task LoadDataAsync()
        {
            var state = await _stateProvider.GetAuthenticationStateAsync();
            var user = state.User;
            _profileModel.Email = user.GetEmail();
            _profileModel.FirstName = user.GetFirstName();
            _profileModel.LastName = user.GetLastName();
            _profileModel.PhoneNumber = user.GetPhoneNumber();
            UserId = user.GetUserId();
            var data = await _accountManager.GetProfilePictureAsync(UserId);
            if (data.Succeeded)
            {
                ImageDataUrl = data.Data;
            }
            if (_profileModel.FirstName.Length > 0)
            {
                _firstLetterOfName = _profileModel.FirstName[0];
            }
        }

        private IBrowserFile _file;

        [Parameter]
        public string ImageDataUrl { get; set; }

        private async Task UploadFiles(InputFileChangeEventArgs e)
        {
            _file = e.File;
            if (_file != null)
            {
                var extension = Path.GetExtension(_file.Name);
                var fileName = $"{UserId}-{Guid.NewGuid()}{extension}";
                var format = "image/png";
                var imageFile = await e.File.RequestImageFileAsync(format, 400, 400);
                var buffer = new byte[imageFile.Size];
                await imageFile.OpenReadStream().ReadAsync(buffer);
                var request = new UpdateProfilePictureRequest { Data = buffer, FileName = fileName, Extension = extension, UploadType = Application.Enums.UploadType.ProfilePicture };
                var result = await _accountManager.UpdateProfilePictureAsync(request, UserId);
                if (result.Succeeded)
                {
                    await _localStorage.SetItemAsync(StorageConstants.Local.UserImageURL, result.Data);
                    _snackBar.Add(_localizer["Profile picture added."], Severity.Success);
                    _navigationManager.NavigateTo("/", true);
                }
                else
                {
                    foreach (var error in result.Messages)
                    {
                        _snackBar.Add(error, Severity.Error);
                    }
                }
            }
        }

        private async Task DeleteAsync()
        {
            var parameters = new DialogParameters
            {
                {nameof(Shared.Dialogs.DeleteConfirmation.ContentText), $"{string.Format(_localizer["Do you want to delete the profile picture of {0}"], _profileModel.Email)}?"}
            };
            var options = new DialogOptions { CloseButton = true, MaxWidth = MaxWidth.Small, FullWidth = true, DisableBackdropClick = true };
            var dialog = _dialogService.Show<Shared.Dialogs.DeleteConfirmation>(_localizer["Delete"], parameters, options);
            var result = await dialog.Result;
            if (!result.Cancelled)
            {
                var request = new UpdateProfilePictureRequest { Data = null, FileName = string.Empty, UploadType = Application.Enums.UploadType.ProfilePicture };
                var data = await _accountManager.UpdateProfilePictureAsync(request, UserId);
                if (data.Succeeded)
                {
                    await _localStorage.RemoveItemAsync(StorageConstants.Local.UserImageURL);
                    ImageDataUrl = string.Empty;
                    _snackBar.Add(_localizer["Profile picture deleted."], Severity.Success);
                    _navigationManager.NavigateTo("/account", true);
                }
                else
                {
                    foreach (var error in data.Messages)
                    {
                        _snackBar.Add(error, Severity.Error);
                    }
                }
            }
        }
    }
}