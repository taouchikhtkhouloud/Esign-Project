using System.Collections.Generic;
using System.Threading.Tasks;
using Esign.Application.Requests.Identity;
using Esign.Application.Responses.Identity;
using Esign.Shared.Wrapper;

namespace Esign.Client.Infrastructure.Managers.Identity.RoleClaims
{
    public interface IRoleClaimManager : IManager
    {
        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsAsync();

        Task<IResult<List<RoleClaimResponse>>> GetRoleClaimsByRoleIdAsync(string roleId);

        Task<IResult<string>> SaveAsync(RoleClaimRequest role);

        Task<IResult<string>> DeleteAsync(string id);
    }
}