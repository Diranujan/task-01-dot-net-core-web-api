using AutoMapper;
using Backend.Dtos.Subcategory;
using Backend.Models;

namespace Backend.Mappers
{
    public class SubcategoryMappingProfile:Profile
    {
        public SubcategoryMappingProfile()
        {
            CreateMap<Subcategory, SubcategoryDto>();
            CreateMap<SubcategoryCreateDto, Subcategory>();
            CreateMap<SubCategoryUpdateDto, Subcategory>();
        }
    }
}
