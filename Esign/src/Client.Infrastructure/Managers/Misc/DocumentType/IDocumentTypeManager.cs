using System.Collections.Generic;
using System.Threading.Tasks;
using Esign.Application.Features.DocumentTypes.Commands.AddEdit;
using Esign.Application.Features.DocumentTypes.Queries.GetAll;
using Esign.Application.Requests.Documents;
using Esign.Shared.Wrapper;

namespace Esign.Client.Infrastructure.Managers.Misc.DocumentType
{
    public interface IDocumentTypeManager : IManager
    {
        Task<IResult<List<GetAllDocumentTypesResponse>>> GetAllAsync();
        Task<PaginatedResult<GetAllDocumentTypesResponse>> GetAllAsync2(GetAllPagedDocumentsRequest request);

        Task<IResult<int>> SaveAsync(AddEditDocumentTypeCommand request);

        Task<IResult<int>> DeleteAsync(int id);

        Task<IResult<string>> ExportToExcelAsync(string searchString = "");
    }
}