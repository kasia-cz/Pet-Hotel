using PetHotel.Data.Entities;
using PetHotel.Domain.Models;

namespace PetHotel.Domain.Interfaces
{
    public interface IUserService
    {
        Task<List<User>> GetAllUsers();
        Task<User> GetUserById(string id);
        Task<User> GetCurrentUser();
        Task<User> UpdateUser(User requestUser);
        Task<User> SetUserRole(string id, string requestUserRole);
        Task Register(RegisterModel model);
        Task Login(LoginModel model);
        Task Logout();
        string GetCurrentUserId();
    }
}
