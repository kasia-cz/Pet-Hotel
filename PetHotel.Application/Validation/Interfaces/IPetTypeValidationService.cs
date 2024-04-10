namespace PetHotel.Application.Validation.Interfaces
{
    public interface IPetTypeValidationService
    {
        Task ValidatePetType(string petType);
    }
}
