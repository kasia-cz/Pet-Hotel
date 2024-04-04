namespace PetHotel.Application.DTOs
{
    public class RegisterDTO
    {
        public string Email { get; set; }
        public string UserName { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }
    }
}
