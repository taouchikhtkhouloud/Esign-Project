using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Esign.Application.Features.DocumentTypes.Queries.GetByParentId;
using Esign.Application.Interfaces.Repositories;
using Esign.Domain.Entities.Misc;
using Esign.Shared.Wrapper;
using MediatR;

namespace Esign.Application.Features.DocumentTypes.Queries.GetFolderByParentId
{
    public class GetFolderByParentIdQuery : IRequest<Result<GetFolderByParentIdResponse>>
    {
        public int ParentId { get; set; }
    }

    internal class GetFolderByParentIdQueryHandler : IRequestHandler<GetFolderByParentIdQuery, Result<GetFolderByParentIdResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;

        public GetFolderByParentIdQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Result<GetFolderByParentIdResponse>> Handle(GetFolderByParentIdQuery query, CancellationToken cancellationToken)
        {
            var documentType = await _unitOfWork.Repository<DocumentType>().GetByIdAsync(query.ParentId);
            var mappedDocumentType = _mapper.Map<GetFolderByParentIdResponse>(documentType);
            return await Result<GetFolderByParentIdResponse>.SuccessAsync(mappedDocumentType);
        }
    }
}