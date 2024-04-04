using PetHotel.Data.Enums;

namespace PetHotel.Data.Entities
{
    public class Reservation
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
        public List<Pet> Pets { get; set; }
    }
}
