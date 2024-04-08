using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Data.Enums;

namespace PetHotel.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<UserDTO> GetUserById(string id);
        Task DeleteUser();
        Task<UserDTO> UpdateUser(UserDTO requestUserDTO);
        Task<UserDTO> UpdateUserRole(string id, UserRole requestUserRole);
        Task Register(RegisterDTO registerDTO);
        Task Login(LoginDTO loginDTO);
        Task Logout();
    }
}
