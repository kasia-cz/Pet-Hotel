using AutoMapper;
using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Data.Entities;
using PetHotel.Domain.Models;

namespace PetHotel.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<LoginDTO, LoginModel>();
            CreateMap<RegisterDTO, RegisterModel>();
        }
    }
}
