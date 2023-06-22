using System.Collections.Generic;
using System.Threading.Tasks;
using Esign.Application.Interfaces.Common;
using Esign.Application.Requests.Identity;
using Esign.Application.Responses.Identity;
using Esign.Shared.Wrapper;

namespace Esign.Application.Interfaces.Services.Identity
{
    public interface IRoleClaimService : IService
    {
        Task<Result<List<RoleClaimResponse>>> GetAllAsync();

        Task<int> GetCountAsync();

        Task<Result<RoleClaimResponse>> GetByIdAsync(int id);

        Task<Result<List<RoleClaimResponse>>> GetAllByRoleIdAsync(string roleId);

        Task<Result<string>> SaveAsync(RoleClaimRequest request);

        Task<Result<string>> DeleteAsync(int id);
    }
}