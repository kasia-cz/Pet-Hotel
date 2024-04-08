using PetHotel.Application.DTOs.ReservationDTOs;

namespace PetHotel.Application.Interfaces
{
    public interface IReservationAppService
    {
        Task<List<ReservationDTO>> GetUserReservations();
        Task<ReservationDTO> GetReservationById(int id);
        Task<ReservationDTO> AddReservation(AddReservationDTO addReservationDTO);
        Task<ReservationDTO> CancelReservation(int id);
    }
}
