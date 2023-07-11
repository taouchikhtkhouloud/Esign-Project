using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Application.Features.Documents.Queries.GetAll;
using Esign.Application.Requests.Documents;
using Esign.Shared.Wrapper;
using System.Threading.Tasks;
using Esign.Application.Features.Documents.Queries.GetById;

namespace Esign.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);
       

        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<PaginatedResult<GetAllDocumentsResponse>> GetFillesByFolderISAsync(GetAllPagedDocumentsRequest request ,int id);

        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}