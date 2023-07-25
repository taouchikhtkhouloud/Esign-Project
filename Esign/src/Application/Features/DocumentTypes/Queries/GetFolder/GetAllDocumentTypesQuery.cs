//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Linq.Expressions;
//using System.Threading;
//using System.Threading.Tasks;
//using AutoMapper;
//using Esign.Application.Extensions;
//using Esign.Application.Interfaces.Repositories;
//using Esign.Application.Interfaces.Services;
//using Esign.Application.Specifications.Misc;
//using Esign.Domain.Entities.Misc;
//using Esign.Shared.Constants.Application;
//using Esign.Shared.Wrapper;
//using LazyCache;
//using MediatR;

//namespace Esign.Application.Features.DocumentTypes.Queries.GetFolder
//{
//    public class GetAllDocumentTypesQuery : IRequest<Result<List<GetAllDocumentTypesResponse>>>
//    {
//        public GetAllDocumentTypesQuery()
//        {
//        }
//    }

//    internal class GetAllDocumentTypesQueryHandler : IRequestHandler<GetAllDocumentTypesQuery, Result<List<GetAllDocumentTypesResponse>>>
//    {
//        private readonly IUnitOfWork<int> _unitOfWork;
//        private readonly IMapper _mapper;
//        private readonly IAppCache _cache;
//        private readonly ICurrentUserService _currentUserService;
//        public GetAllDocumentTypesQueryHandler(IUnitOfWork<int> unitOfWork, IMapper mapper, IAppCache cache , ICurrentUserService currentUserService)
//        {
//            _unitOfWork = unitOfWork;
//            _mapper = mapper;
//            _cache = cache;
//            _currentUserService = currentUserService;
//        }

//        public async Task<Result<List<GetAllDocumentTypesResponse>>> Handle(GetAllDocumentTypesQuery request, CancellationToken cancellationToken)
//        {
//            Expression<Func<Document, GetAllDocumentTypesResponse>> expression = e => new GetAllDocumentTypesResponse
//            {
                
//                Name = e.Title,
//                CreatedBy = e.CreatedBy,
      
//                CreatedOn = e.CreatedOn,
//                Description = e.Description,
                
               
//            };
//            var docSpec = new DocumentFilterSpecification("", _currentUserService.UserId);
//            var data = await _unitOfWork.Repository<Document>().Entities
//               .Specify(docSpec)
//               .Select(expression);
//            Func<Task<List<DocumentType>>> getAllDocumentTypes = () => _unitOfWork.Repository<DocumentType>().GetAllAsync();
//            var documentTypeList = await _cache.GetOrAddAsync(ApplicationConstants.Cache.GetAllDocumentTypesCacheKey, getAllDocumentTypes);
//            var mappedDocumentTypes = _mapper.Map<List<GetAllDocumentTypesResponse>>(documentTypeList);
//            return await Result<List<GetAllDocumentTypesResponse>>.SuccessAsync(mappedDocumentTypes);
//        }
//    }
//}