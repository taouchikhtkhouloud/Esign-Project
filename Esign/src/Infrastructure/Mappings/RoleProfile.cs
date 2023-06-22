using AutoMapper;
using Esign.Infrastructure.Models.Identity;
using Esign.Application.Responses.Identity;

namespace Esign.Infrastructure.Mappings
{
    public class RoleProfile : Profile
    {
        public RoleProfile()
        {
            CreateMap<RoleResponse, BlazorHeroRole>().ReverseMap();
        }
    }
}