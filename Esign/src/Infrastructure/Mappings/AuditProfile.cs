using AutoMapper;
using Esign.Infrastructure.Models.Audit;
using Esign.Application.Responses.Audit;

namespace Esign.Infrastructure.Mappings
{
    public class AuditProfile : Profile
    {
        public AuditProfile()
        {
            CreateMap<AuditResponse, Audit>().ReverseMap();
        }
    }
}