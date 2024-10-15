using AutoMapper;
using Backend.Dtos.Brand;
using Backend.Dtos.Category;
using Backend.Models;

namespace Backend.Mappers
{
    public class BrandMappingProfile:Profile
    {
        public BrandMappingProfile()
        {
            CreateMap<Brand, BrandDto>();
            CreateMap<BrandCreateDto, Brand>();
            CreateMap<BrandUpdateDto, Brand>();
        }
    }
}
