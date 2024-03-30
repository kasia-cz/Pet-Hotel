using AutoMapper;
using PetHotel.Application.DTOs;
using PetHotel.Data.Entities;

namespace PetHotel.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UpdateUserRoleDTO>();
        }
    }
}
