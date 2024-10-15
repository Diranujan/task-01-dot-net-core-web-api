using AutoMapper;
using Backend.Dtos.Product;
using Backend.Models;

namespace Backend.Mappers
{
    public class ProductMappingProfile:Profile
    {
        public ProductMappingProfile()
        {
            CreateMap<Product, ProductDto>();
            CreateMap<ProductCreateDto, Product>();
            CreateMap<ProductUpdateDto, Product>();
        }
    }
}
