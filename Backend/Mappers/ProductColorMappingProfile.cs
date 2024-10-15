using AutoMapper;
using Backend.Dtos.ProductColor;
using Backend.Models;

namespace Backend.Mappers
{
    public class ProductColorMappingProfile:Profile
    {
        public ProductColorMappingProfile()
        {
            CreateMap<ProductColor, ProductColorDto>();
            CreateMap<ProductColorCreateDto, ProductColor>();
        }
    }
}
