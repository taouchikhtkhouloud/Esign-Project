using Esign.Application.Interfaces.Common;
using Esign.Application.Requests.Identity;
using Esign.Application.Responses.Identity;
using Esign.Shared.Wrapper;
using System.Threading.Tasks;

namespace Esign.Application.Interfaces.Services.Identity
{
    public interface ITokenService : IService
    {
        Task<Result<TokenResponse>> LoginAsync(TokenRequest model);

        Task<Result<TokenResponse>> GetRefreshTokenAsync(RefreshTokenRequest model);
    }
}