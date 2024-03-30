using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Data.Enums;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Domain.Services
{
    public class UserService : IUserService
    {
        private readonly PetHotelDbContext _context;

        public UserService(PetHotelDbContext context)
        {
            _context = context;
        }

        public async Task<User> AddUser(User user)
        {
            user.UserRole = UserRole.User;
            _context.Users.Add(user);
            await _context.SaveChangesAsync();

            return user;
        }

        public async Task DeleteUser(int id)
        {
            var user = await _context.Users.FindAsync(id);
            _context.Users.Remove(user);
            await _context.SaveChangesAsync();
        }

        public async Task<User> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public async Task<User> UpdateUser(int id, User requestUser)
        {
            var user = await _context.Users.FindAsync(id);

            user.Email = requestUser.Email;
            user.Login = requestUser.Login;
            user.Name = requestUser.Name;
            user.LastName = requestUser.LastName;
            user.PhoneNumber = requestUser.PhoneNumber;
            user.Password = requestUser.Password;

            await _context.SaveChangesAsync();

            return requestUser;
        }

        public async Task<User> UpdateUserRole(int id, UserRole requestUserRole)
        {
            var user = await _context.Users.FindAsync(id);
            user.UserRole = requestUserRole;
            await _context.SaveChangesAsync();

            return user;
        }
    }
}
