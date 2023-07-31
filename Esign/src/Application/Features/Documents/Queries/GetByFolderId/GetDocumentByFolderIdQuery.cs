using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using AutoMapper;
using Esign.Application.Features.Documents.Queries.GetAll;
using Esign.Application.Interfaces.Repositories;
using Esign.Domain.Entities.Misc;
using Esign.Shared.Constants.Application;
using Esign.Shared.Wrapper;
using LazyCache;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Esign.Application.Features.Documents.Queries.GetByFolderId
{

    public class GetDocumentByFolderIdQuery : IRequest<Result<List<GetDocumentByFolderIdResponse>>>
    {
        // Add any necessary properties for the query if required
    }

    internal class GetDocumentByFolderIdQueryHandler : IRequestHandler<GetDocumentByFolderIdQuery, Result<List<GetDocumentByFolderIdResponse>>>
    {
        private readonly IUnitOfWork<int> _unitOfWork;
        private readonly IMapper _mapper;
        private readonly ILogger<GetDocumentByFolderIdQueryHandler> _logger;
        private readonly IAppCache _cache;

        public static IMapper Mapper { get; }

        public GetDocumentByFolderIdQueryHandler(IUnitOfWork<int> unitOfWork, ILogger<GetDocumentByFolderIdQueryHandler> logger)
        {
            _unitOfWork = unitOfWork;
           
            _logger = logger;
            // _cache = cache;
        }
        static GetDocumentByFolderIdQueryHandler()
        {
            Mapper = new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<Document, GetDocumentByFolderIdResponse>()
                    .ForMember(dest => dest.Id, opt => opt.MapFrom(src => src.Id))
                    .ForMember(dest => dest.Title, opt => opt.MapFrom(src => src.Title))
                    .ForMember(dest => dest.Description, opt => opt.MapFrom(src => src.Description))
                    .ForMember(dest => dest.status, opt => opt.MapFrom(src => src.status))
                    .ForMember(dest => dest.keywords, opt => opt.MapFrom(src => src.keywords))
                .ForMember(dest => dest.IsPublic, opt => opt.MapFrom(src => src.IsPublic))
                .ForMember(dest => dest.URL, opt => opt.MapFrom(src => src.URL))
                .ForMember(dest => dest.Value, opt => opt.MapFrom(src => src.Value))
                .ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client))
                .ForMember(dest => dest.CreatedOn, opt => opt.MapFrom(src => src.CreatedOn))
                .ForMember(dest => dest.DocumentType, opt => opt.MapFrom(src => src.DocumentType))
                .ForMember(dest => dest.DocumentTypeId, opt => opt.MapFrom(src => src.DocumentTypeId))
                .ForMember(dest => dest.fileType, opt => opt.MapFrom(src => src.fileType))
                .ForMember(dest => dest.CreatedBy, opt => opt.MapFrom(src => src.CreatedBy));
                // Add other property mappings if necessary
            }).CreateMapper();
        }

        public async Task<Result<List<GetDocumentByFolderIdResponse>>> Handle(GetDocumentByFolderIdQuery request, CancellationToken cancellationToken)
        {
            try
            {
                var getAllDocumentTypes = await _unitOfWork.Repository<Document>().GetAllAsync();
                var mappedDocumentTypes = Mapper.Map<List<GetDocumentByFolderIdResponse>>(getAllDocumentTypes);
                List<GetDocumentByFolderIdResponse> test = new();
                GetDocumentByFolderIdResponse a = new();
                _logger.LogInformation("Documents fetched from the repository:");
                foreach (var document in mappedDocumentTypes)
                {
                    _logger.LogInformation($"Document Id: {document.Id}, Name: {document.Title}, Description: {document.Description}");
                    a = document;
                    test.Add(a);
                    
                }

                return await Result<List<GetDocumentByFolderIdResponse>>.SuccessAsync(mappedDocumentTypes);
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "An error occurred while fetching documents.");
                throw; // Rethrow the exception to bubble it up to the caller.
            }
        }
    }
}