using PetHotel.Data.Entities;
using PetHotel.Data.Enums;

namespace PetHotel.Domain.Interfaces
{
    public interface IUserService
    {
        Task<User> GetUserById(int id);
        Task<User> AddUser(User user);
        Task DeleteUser(int id);
        Task<User> UpdateUser(int id, User requestUser);
        Task<User> UpdateUserRole(int id, UserRole requestUserRole);
    }
}
