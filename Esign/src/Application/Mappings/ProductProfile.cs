using AutoMapper;
using Esign.Application.Features.Products.Commands.AddEdit;
using Esign.Domain.Entities.Catalog;

namespace Esign.Application.Mappings
{
    public class ProductProfile : Profile
    {
        public ProductProfile()
        {
            CreateMap<AddEditProductCommand, Product>().ReverseMap();
        }
    }
}