using Esign.Shared.Wrapper;
using System.Threading.Tasks;
using Esign.Application.Features.Dashboards.Queries.GetData;

namespace Esign.Client.Infrastructure.Managers.Dashboard
{
    public interface IDashboardManager : IManager
    {
        Task<IResult<DashboardDataResponse>> GetDataAsync();
    }
}