using AutoMapper;
using Backend.Dtos.Color;
using Backend.Models;

namespace Backend.Mappers
{
    public class ColorMappingProfile:Profile
    {
        public ColorMappingProfile()
        {
            CreateMap<Color, ColorDto>();
            CreateMap<ColorCreateDto, Color>();
            CreateMap<ColorUpdateDto, Color>();

        }
    }
}
