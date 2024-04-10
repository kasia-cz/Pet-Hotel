using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Data.Enums;

namespace PetHotel.Application.DTOs.ReservationDTOs
{
    public class ReturnReservationForUserDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        public List<ReturnPetShortDTO> Pets { get; set; }
    }
}
