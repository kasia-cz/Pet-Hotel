namespace PetHotel.Application.DTOs.PetDTOs
{
    public class AddPetDTO
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Breed { get; set; }
        public DateTime DateOfBirth { get; set; }
        public double Weight { get; set; }
        public string Diseases { get; set; }
        public string NutritionalRequirements { get; set; }
        public string AnotherInformations { get; set; }
    }
}
