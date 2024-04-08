namespace PetHotel.Application.DTOs.ReservationDTOs
{
    public class AddReservationDTO
    {
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }

        public List<int> PetsId { get; set; }
    }
}
