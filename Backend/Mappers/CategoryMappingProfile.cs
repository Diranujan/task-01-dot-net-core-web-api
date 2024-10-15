using AutoMapper;
using Backend.Dtos.Category;
using Backend.Models;

namespace Backend.Mappers
{
    public class CategoryMappingProfile: Profile
    {
       public CategoryMappingProfile()
        { 
            CreateMap<Category, CategoryDto>();
            CreateMap<CategoryCreateDto, Category>();
            CreateMap<CategoryUpdatedto,  Category>();
        }
    }
}
