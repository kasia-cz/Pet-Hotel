using PetHotel.Data.Entities;

namespace PetHotel.Domain.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetUserReservations();
        Task<Reservation> GetReservationById(int id);
        Task<Reservation> AddReservation(Reservation reservation);
        Task<Reservation> CancelReservation(int id);
    }
}
