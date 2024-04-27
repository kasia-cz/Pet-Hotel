using PetHotel.Data.Entities;

namespace PetHotel.Application.Validation.Interfaces
{
    public interface IReservationValidationService
    {
        Task ValidateReservation(Reservation requestReservation);
    }
}
