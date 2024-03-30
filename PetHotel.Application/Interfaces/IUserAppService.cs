using PetHotel.Application.DTOs;
using PetHotel.Data.Enums;

namespace PetHotel.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDTO> GetUserById(int id);
        Task<UserDTO> AddUser(UserDTO userDTO);
        Task DeleteUser(int id);
        Task<UserDTO> UpdateUser(int id, UserDTO requestUserDTO);
        Task<UpdateUserRoleDTO> UpdateUserRole(int id, UserRole requestUserRole);
    }
}
