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

        public async Task<ReturnUserDTO> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            return _mapper.Map<ReturnUserDTO>(user);
        }

        public async Task<ReturnUserDTO> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUser();

            return _mapper.Map<ReturnUserDTO>(user);

        }

        public async Task<ReturnUserDTO> UpdateUser(UpdateUserDTO requestUserDTO)
        {
            var requestUser = _mapper.Map<User>(requestUserDTO);
            var user = await _userService.UpdateUser(requestUser);

            return _mapper.Map<ReturnUserDTO>(user);
        }

        public async Task<ReturnUserDTO> UpdateUserRole(string id, UserRole requestUserRole)
        {
            var user = await _userService.UpdateUserRole(id, requestUserRole);

            return _mapper.Map<ReturnUserDTO>(user);
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
