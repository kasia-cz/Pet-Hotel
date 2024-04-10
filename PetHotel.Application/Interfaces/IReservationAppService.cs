using PetHotel.Application.DTOs.ReservationDTOs;

namespace PetHotel.Application.Interfaces
{
    public interface IReservationAppService
    {
        Task<List<ReturnReservationForAdminDTO>> GetAllReservations(string? reservationStatus, DateTime dateFrom, DateTime dateTo);
        Task<List<ReturnReservationForUserDTO>> GetUserReservations();
        Task<ReturnReservationForUserDTO> GetReservationByIdForUser(int id);
        Task<ReturnReservationForAdminDTO> GetReservationByIdForAdmin(int id);
        Task<ReturnReservationForUserDTO> AddReservation(AddReservationDTO addReservationDTO);
        Task<ReturnReservationForUserDTO> CancelReservation(int id);
        Task<ReturnReservationForAdminDTO> ConfirmReservation(int id);
        Task<ReturnReservationForAdminDTO> DeclineReservation(int id);
    }
}
