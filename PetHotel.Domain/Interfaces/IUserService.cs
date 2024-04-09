using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
using PetHotel.Domain.Models;

namespace PetHotel.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task<User> GetCurrentUser();
        Task<User> UpdateUser(User requestUser);
        Task<User> UpdateUserRole(string id, UserRole requestUserRole);
        Task Register(RegisterModel model);
        Task Login(LoginModel model);
        Task Logout();
        string GetCurrentUserId();
    }
}
