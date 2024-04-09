using Microsoft.AspNetCore.Identity;
using PetHotel.Data.Enums;

namespace PetHotel.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }
        public UserRole UserRole { get; set; }

        public List<Pet> Pets { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
