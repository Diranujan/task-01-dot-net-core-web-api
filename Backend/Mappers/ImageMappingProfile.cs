using AutoMapper;
using Backend.Dtos.Image;
using Backend.Models;

namespace Backend.Mappers
{
    public class ImageMappingProfile:Profile
    {
        public ImageMappingProfile()
        {
            CreateMap<Image, ImageDto>();
            CreateMap<ImageCreateDto, Image>();
            CreateMap<ImageUpdateDto, Image>();
        }
    }
}
