using AutoMapper;
using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Constants;
using PetHotel.Data.Entities;
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

        public async Task<List<ReturnUserDTO>> GetAllUsers()
        {
            var users = await _userService.GetAllUsers();

            return _mapper.Map<List<ReturnUserDTO>>(users);
        }

        public async Task<ReturnUserDTO> GetUserById(string id)
        {
            var user = await _userService.GetUserById(id);

            return await MapUserWithRole(user);
        }

        public async Task<ReturnUserDTO> GetCurrentUser()
        {
            var user = await _userService.GetCurrentUser();

            return await MapUserWithRole(user);
        }

        public async Task<ReturnUserDTO> UpdateUser(UpdateUserDTO requestUserDTO)
        {
            var requestUser = _mapper.Map<User>(requestUserDTO);
            var user = await _userService.UpdateUser(requestUser);

            return _mapper.Map<ReturnUserDTO>(user);
        }

        public async Task<ReturnUserDTO> SetUserRole(string id, string requestUserRole)
        {
            if(!requestUserRole.Equals(UserConstants.UserRoles.User) && !requestUserRole.Equals(UserConstants.UserRoles.Admin))
            {
                throw new Exception("Invalid user role"); // BadRequestException
            }
            var user = await _userService.SetUserRole(id, requestUserRole);

            return await MapUserWithRole(user);
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

        private async Task<ReturnUserDTO> MapUserWithRole(User user) 
        {
            var userDTO = _mapper.Map<ReturnUserDTO>(user);
            userDTO.Role = await _userService.GetUserRole(user);

            return userDTO;
        }
    }
}
