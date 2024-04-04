namespace PetHotel.Data.Entities
{
    public class Pet
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public string Diseases { get; set; }
        public string NutritionalRequirements { get; set; }
        public string AnotherInformations { get; set; }

        public User User { get; set; }
        public string UserId { get; set; }
        public List<Reservation> Reservations { get; set; }
    }
}
