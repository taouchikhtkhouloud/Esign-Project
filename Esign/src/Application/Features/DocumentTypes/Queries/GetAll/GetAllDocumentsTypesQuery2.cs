using Esign.Application.Extensions;
using Esign.Application.Features.DocumentTypes.Queries.GetAll;
using Esign.Application.Interfaces.Repositories;
using Esign.Application.Interfaces.Services;
using Esign.Application.Specifications.Misc;
using Esign.Domain.Entities.Misc;
using Esign.Shared.Wrapper;
using MediatR;
using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading;
using System.Threading.Tasks;

namespace Esign.Application.Features.Documents.Queries.GetAll
{
    public class GetAllDocumentsTypesQuery2 : IRequest<PaginatedResult<GetAllDocumentTypesResponse>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public string SearchString { get; set; }

        public GetAllDocumentsTypesQuery2(int pageNumber, int pageSize, string searchString)
        {
            PageNumber = pageNumber;
            PageSize = pageSize;
            SearchString = searchString;
        }
    }

    internal class GetAllDocumentsTypesQuery2Handler : IRequestHandler<GetAllDocumentsTypesQuery2, PaginatedResult<GetAllDocumentTypesResponse>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;

        private readonly ICurrentUserService _currentUserService;

        public GetAllDocumentsTypesQuery2Handler(IUnitOfWork<int> unitOfWork, ICurrentUserService currentUserService)
        {
            _unitOfWork = unitOfWork;
            _currentUserService = currentUserService;
        }

        public async Task<PaginatedResult<GetAllDocumentTypesResponse>> Handle(GetAllDocumentsTypesQuery2 request, CancellationToken cancellationToken)
        {
            Expression<Func<DocumentType, GetAllDocumentTypesResponse>> expression = e => new GetAllDocumentTypesResponse
            {
                Id = e.Id,
                Name = e.Name,
                CreatedBy = e.CreatedBy,
                CreatedOn = e.CreatedOn,
                Description = e.Description,
                Parent= e.Parent
            
        };
            var docSpec = new DocumentTypeFilterSpecification(request.SearchString);
            var data = await _unitOfWork.Repository<DocumentType>().Entities
               .Specify(docSpec)
               .Select(expression)
               .ToPaginatedListAsync(request.PageNumber, request.PageSize);
            return data;
        }
    }
}