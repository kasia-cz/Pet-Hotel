using PetHotel.Data.Enums;

namespace PetHotel.Application.DTOs.UserDTOs
{
    public class UserDTO
    {
        public string Id { get; set; }
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public UserRole UserRole { get; set; }
    }
}
