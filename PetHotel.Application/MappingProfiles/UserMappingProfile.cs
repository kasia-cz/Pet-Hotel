using AutoMapper;
using PetHotel.Application.DTOs;
using PetHotel.Data.Entities;
using PetHotel.Domain.Models;

namespace PetHotel.Application.MappingProfiles
{
    public class UserMappingProfile : Profile
    {
        public UserMappingProfile() 
        {
            CreateMap<User, UserDTO>().ReverseMap();
            CreateMap<User, UpdateUserRoleDTO>();
            CreateMap<LoginDTO, LoginModel>();
            CreateMap<RegisterDTO, RegisterModel>();
        }
    }
}
