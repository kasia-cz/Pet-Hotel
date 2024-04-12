using Microsoft.AspNetCore.Identity;

namespace PetHotel.Data.Entities
{
    public class User : IdentityUser
    {
        public string FirstName { get; set; } 
        public string LastName { get; set; }

        public List<Pet> Pets { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
