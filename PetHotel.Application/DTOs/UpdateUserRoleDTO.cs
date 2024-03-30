using PetHotel.Data.Enums;

namespace PetHotel.Application.DTOs
{
    public class UpdateUserRoleDTO
    {
        public string Email { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }
    }
}
