using AutoMapper;
using Backend.Dtos.Color;
using Backend.Dtos.Size;
using Backend.Models;

namespace Backend.Mappers
{
    public class SizeMappingProfie:Profile
    {
        public SizeMappingProfie()
        {
            CreateMap<Size, SizeDto>();
            CreateMap<SizeCreateDto, Size>();
            CreateMap<SizeUpdateDto, Size>();
        }
    }
}
