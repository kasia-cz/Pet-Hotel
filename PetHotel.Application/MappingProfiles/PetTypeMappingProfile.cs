using AutoMapper;
using PetHotel.Application.DTOs.PetDTOs;
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