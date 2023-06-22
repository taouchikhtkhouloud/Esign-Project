using AutoMapper;
using Esign.Application.Features.Documents.Commands.AddEdit;
using Esign.Application.Features.Documents.Queries.GetById;
using Esign.Domain.Entities.Misc;

namespace Esign.Application.Mappings
{
    public class DocumentProfile : Profile
    {
        public DocumentProfile()
        {
            CreateMap<AddEditDocumentCommand, Document>().ReverseMap();
            CreateMap<GetDocumentByIdResponse, Document>().ReverseMap();
        }
    }
}