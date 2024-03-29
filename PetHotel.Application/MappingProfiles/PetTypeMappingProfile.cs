using AutoMapper;
using PetHotel.Application.DTOs;
using PetHotel.Data.Entities;

namespace PetHotel.Application.MappingProfiles
{
    public class PetTypeMappingProfile : Profile
    {
        public PetTypeMappingProfile()
        {
            CreateMap<PetType, PetTypeDTO>().ReverseMap();
        }
    }
}