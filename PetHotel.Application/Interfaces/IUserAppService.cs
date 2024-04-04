using PetHotel.Application.DTOs;
using PetHotel.Data.Enums;

namespace PetHotel.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDTO> GetUserById(string id);
        Task DeleteUser(string id);
        Task<UserDTO> UpdateUser(string id, UserDTO requestUserDTO);
        Task<UpdateUserRoleDTO> UpdateUserRole(string id, UserRole requestUserRole);
        Task Register(RegisterDTO registerDTO);
        Task Login(LoginDTO loginDTO);
        Task Logout();
    }
}
