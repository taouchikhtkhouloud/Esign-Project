using AutoMapper;
using Esign.Application.Features.Brands.Commands.AddEdit;
using Esign.Application.Features.Brands.Queries.GetAll;
using Esign.Application.Features.Brands.Queries.GetById;
using Esign.Domain.Entities.Catalog;

namespace Esign.Application.Mappings
{
    public class BrandProfile : Profile
    {
        public BrandProfile()
        {
            CreateMap<AddEditBrandCommand, Brand>().ReverseMap();
            CreateMap<GetBrandByIdResponse, Brand>().ReverseMap();
            CreateMap<GetAllBrandsResponse, Brand>().ReverseMap();
        }
    }
}