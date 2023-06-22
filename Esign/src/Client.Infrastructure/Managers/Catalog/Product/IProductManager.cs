using Esign.Application.Features.Products.Commands.AddEdit;
using Esign.Application.Features.Products.Queries.GetAllPaged;
using Esign.Application.Requests.Catalog;
using Esign.Shared.Wrapper;
using System.Threading.Tasks;

namespace Esign.Client.Infrastructure.Managers.Catalog.Product
{
    public interface IProductManager : IManager
    {
        Task<PaginatedResult<GetAllPagedProductsResponse>> GetProductsAsync(GetAllPagedProductsRequest request);

        Task<IResult<string>> GetProductImageAsync(int id);

        Task<IResult<int>> SaveAsync(AddEditProductCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}