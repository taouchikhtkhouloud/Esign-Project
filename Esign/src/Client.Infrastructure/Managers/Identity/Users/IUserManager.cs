﻿using Esign.Application.Requests.Identity;
using Esign.Application.Requests.Documents;
using Esign.Application.Responses.Identity;
using Esign.Shared.Wrapper;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Esign.Client.Infrastructure.Managers.Identity.Users
{
    public interface IUserManager : IManager
    {
        Task<IResult<List<UserResponse>>> GetAllAsync();

        Task<IResult> ForgotPasswordAsync(ForgotPasswordRequest request);

        Task<IResult> SendCodeAsyn(SignDocumentRequest request);

        Task<IResult> ResetPasswordAsync(ResetPasswordRequest request);

        Task<IResult<UserResponse>> GetAsync(string userId);

        Task<IResult<UserRolesResponse>> GetRolesAsync(string userId);

        //Task<IResult> SendCodeEmail(string recipientEmail, string code);
        Task<IResult> RegisterUserAsync(RegisterRequest request);

        Task<IResult> ToggleUserStatusAsync(ToggleUserStatusRequest request);

        Task<IResult> UpdateRolesAsync(UpdateUserRolesRequest request);

        Task<string> ExportToExcelAsync(string searchString = "");
    }
}