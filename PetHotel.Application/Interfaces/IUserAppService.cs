using PetHotel.Application.DTOs.UserDTOs;

namespace PetHotel.Application.Interfaces
{
    public interface IUserAppService
    {
        Task<List<ReturnUserShortDTO>> GetAllUsers();
        Task<ReturnUserDTO> GetUserById(string id);
        Task<ReturnUserDTO> GetCurrentUser();
        Task<ReturnUserDTO> UpdateUser(UpdateUserDTO requestUserDTO);
        Task<ReturnUserDTO> SetUserRole(string id, string requestUserRole);
        Task Register(RegisterDTO registerDTO);
        Task Login(LoginDTO loginDTO);
        Task Logout();
    }
}
