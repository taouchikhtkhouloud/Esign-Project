using AutoMapper;
using Esign.Application.Features.DocumentTypes.Commands.AddEdit;
using Esign.Application.Features.DocumentTypes.Queries.GetAll;
using Esign.Application.Features.DocumentTypes.Queries.GetById;
using Esign.Domain.Entities.Misc;

namespace Esign.Application.Mappings
{
    public class DocumentTypeProfile : Profile
    {
        public DocumentTypeProfile()
        {
            CreateMap<AddEditDocumentTypeCommand, DocumentType>().ReverseMap();
            CreateMap<GetDocumentTypeByIdResponse, DocumentType>().ReverseMap();
            CreateMap<GetAllDocumentTypesResponse, DocumentType>().ReverseMap();
        }
    }
}