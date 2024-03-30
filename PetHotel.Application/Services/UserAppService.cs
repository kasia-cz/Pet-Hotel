using AutoMapper;
using PetHotel.Application.DTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
using PetHotel.Domain.Interfaces;

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

        public async Task DeleteUser(int id)
        {
            await _userService.DeleteUser(id);
        }

        public async Task<UserDTO> AddUser(UserDTO userDTO)
        {
            var mappedUser = _mapper.Map<User>(userDTO);
            await _userService.AddUser(mappedUser);

            return userDTO;
        }

        public async Task<UserDTO> GetUserById(int id)
        {
            var user = await _userService.GetUserById(id);

            return _mapper.Map<UserDTO>(user);
        }

        public async Task<UserDTO> UpdateUser(int id, UserDTO requestUserDTO)
        {
            var mappedRequestUser = _mapper.Map<User>(requestUserDTO);
            await _userService.UpdateUser(id, mappedRequestUser);

            return requestUserDTO;
        }

        public async Task<UpdateUserRoleDTO> UpdateUserRole(int id, UserRole requestUserRole)
        {
            var user = await _userService.UpdateUserRole(id, requestUserRole);

            return _mapper.Map<UpdateUserRoleDTO>(user);
        }
    }
}
