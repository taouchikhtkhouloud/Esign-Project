using Esign.Application.Interfaces.Common;

namespace Esign.Application.Interfaces.Services
{
    public interface ICurrentUserService : IService
    {
        string UserId { get; }
    }
}