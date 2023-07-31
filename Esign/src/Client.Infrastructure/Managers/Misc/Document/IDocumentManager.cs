using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Application.Features.Documents.Queries.GetAll;
using Esign.Application.Requests.Documents;
using Esign.Shared.Wrapper;
using System.Threading.Tasks;
using Esign.Application.Features.Documents.Queries.GetById;
using System.Collections.Generic;
using Esign.Application.Features.Documents.Queries.GetByFolderId;
using Esign.Application.Features.Documents.Commands.Sign;

namespace Esign.Client.Infrastructure.Managers.Misc.Document
{
    public interface IDocumentManager : IManager
    {
        Task<PaginatedResult<GetAllDocumentsResponse>> GetAllAsync(GetAllPagedDocumentsRequest request);

        Task<IResult<List<GetDocumentByFolderIdResponse>>> GetByFolderAsync();
        Task<IResult<GetDocumentByIdResponse>> GetByIdAsync(GetDocumentByIdQuery request);

        Task<PaginatedResult<GetAllDocumentsResponse>> GetFillesByFolderISAsync(GetAllPagedDocumentsRequest request ,int id);

        Task<IResult<string>> SignDocument(SignDocumentCommand request);
        Task<IResult<int>> SaveAsync(AddEditDocumentCommand request);

        Task<IResult<int>> DeleteAsync(int id);
    }
}