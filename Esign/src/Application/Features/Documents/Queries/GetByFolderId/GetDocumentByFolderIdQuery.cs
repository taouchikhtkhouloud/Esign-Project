//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using Esign.Application.Interfaces.Repositories;
//using Esign.Domain.Entities.Misc;
//using Esign.Shared.Wrapper;
//using MediatR;

//namespace Esign.Application.Features.Documents.Queries.GetByFolderId
//{
//    public class GetDocumentByFolderIdQuery : IRequest<Result<GetDocumentByFolderIdResponse>>
//    {
//        public int DocumentTypeId { get; set; }
//    }

//    internal class GetDocumentByFolderIdQueryHandler : IRequestHandler<GetDocumentByFolderIdQuery, Result<GetDocumentByFolderIdResponse>>
//    {
//        private readonly IUnitOfWork<int> _unitOfWork;
//        private readonly IMapper _mapper;

//        public GetDocumentByFolderIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//        }

//        public async Task<Result<GetDocumentByFolderIdResponse>> Handle(GetDocumentByFolderIdQuery query, CancellationToken cancellationToken)
//        {
//            var documents = await _unitOfWork.Repository<Document>()
//        .GetFilesByIdAsync(d => d.DocumentTypeId == query.DocumentTypeId);
//            var mappedDocument = _mapper.Map<GetDocumentByFolderIdResponse>(documents);
//            return await Result<GetDocumentByFolderIdResponse>.SuccessAsync(mappedDocument);
//        }
//    }
//}