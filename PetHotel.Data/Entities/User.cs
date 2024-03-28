using PetHotel.Data.Enums;

namespace PetHotel.Data.Entities
{
    public class User
    {
        public int Id { get; set; }
        public string Email { get; set; }
        public string Login { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public int PhoneNumber { get; set; }
        public string Password { get; set; }
        public UserRole UserRole { get; set; }

        public List<Pet> Pets { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
