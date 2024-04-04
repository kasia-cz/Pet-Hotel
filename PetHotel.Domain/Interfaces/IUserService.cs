using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
using PetHotel.Domain.Models;

namespace PetHotel.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(string id);
        Task DeleteUser(string id);
        Task<User> UpdateUser(string id, User requestUser);
        Task<User> UpdateUserRole(string id, UserRole requestUserRole);
        Task Register(RegisterModel model);
        Task Login(LoginModel model);
        Task Logout();
    }
}
