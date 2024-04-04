using AutoMapper;
using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
using PetHotel.Domain.Interfaces;
using PetHotel.Domain.Models;

namespace PetHotel.Application.Services
{
    public class UserAppService : IUserAppService
    {
        private readonly IUserService _userService;
        private readonly IMapper _mapper;

        public UserAppService(IUserService userService, IMapper mapper)
        {
            _userService = userService;
            _mapper = mapper;
        }

        public async Task DeleteUser(string id)
        {
            await _userService.DeleteUser(id);
        }

        public async Task<UserDTO> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUser(string id, UserDTO requestUserDTO)
        {
            var mappedRequestUser = _mapper.Map<User>(requestUserDTO);
            await _userService.UpdateUser(id, mappedRequestUser);

            return requestUserDTO;
        }

        public async Task<UpdateUserRoleDTO> UpdateUserRole(string id, UserRole requestUserRole)
        {
            var user = await _userService.UpdateUserRole(id, requestUserRole);

            return _mapper.Map<UpdateUserRoleDTO>(user);
        }

        public async Task Register(RegisterDTO registerDTO)
        {
            var registerModel = _mapper.Map<RegisterModel>(registerDTO);
            await _userService.Register(registerModel);
        }

        public async Task Login(LoginDTO loginDTO)
        {
            var loginModel = _mapper.Map<LoginModel>(loginDTO);
            await _userService.Login(loginModel);
        }
        public async Task Logout()
        { 
            await _userService.Logout();
        }
    }
}
