using AutoMapper;
using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Data.Entities;

namespace PetHotel.Application.MappingProfiles
{
    public class PetMappingProfile : Profile
    {
        public PetMappingProfile()
        {
            CreateMap<Pet, PetDTO>().ReverseMap();
            CreateMap<Pet, GetUsersPetsDTO>();
        }
    }
}
