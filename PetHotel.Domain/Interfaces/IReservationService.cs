using PetHotel.Data.Entities;

namespace PetHotel.Domain.Interfaces
{
    public interface IReservationService
    {
        Task<List<Reservation>> GetAllReservations(string? reservationStatus, DateTime dateFrom, DateTime dateTo);
        Task<List<Reservation>> GetUserReservations();
        Task<Reservation> GetReservationByIdForUser(int id);
        Task<Reservation> GetReservationByIdForAdmin(int id);
        Task<Reservation> AddReservation(Reservation reservation);
        Task<Reservation> CancelReservation(int id);
        Task<Reservation> ConfirmReservation(int id);
        Task<Reservation> DeclineReservation(int id);
    }
}
