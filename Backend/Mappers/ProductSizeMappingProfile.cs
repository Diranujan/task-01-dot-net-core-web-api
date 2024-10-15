using AutoMapper;
using Backend.Dtos.ProductSize;
using Backend.Models;

namespace Backend.Mappers
{
    public class ProductSizeMappingProfile:Profile
    {
        public ProductSizeMappingProfile()
        {
           CreateMap<ProductSize, ProductSizeDto>();
        }
    }
}
