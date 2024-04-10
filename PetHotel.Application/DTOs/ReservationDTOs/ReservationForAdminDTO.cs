using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Data.Enums;

namespace PetHotel.Application.DTOs.ReservationDTOs
{
    public class ReservationForAdminDTO
    {
        public int Id { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public ReservationStatus ReservationStatus { get; set; }

        public ReturnUserDTO User { get; set; }
        public List<ReturnPetDTO> Pets { get; set; }
    }
}
