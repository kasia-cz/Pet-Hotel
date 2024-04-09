using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Data.Enums;

namespace PetHotel.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<ReturnUserDTO> GetUserById(string id);
        Task<ReturnUserDTO> GetCurrentUser();
        Task<ReturnUserDTO> UpdateUser(UpdateUserDTO requestUserDTO);
        Task<ReturnUserDTO> UpdateUserRole(string id, UserRole requestUserRole);
        Task Register(RegisterDTO registerDTO);
        Task Login(LoginDTO loginDTO);
        Task Logout();
    }
}
