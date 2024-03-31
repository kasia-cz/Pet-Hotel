using AutoMapper;
using PetHotel.Application.DTOs;
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
