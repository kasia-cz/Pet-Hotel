using AutoMapper;
using PetHotel.Application.DTOs.ReservationDTOs;
using PetHotel.Data.Entities;

namespace PetHotel.Application.MappingProfiles
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile() 
        {
            CreateMap<AddReservationDTO, Reservation>();
            CreateMap<Reservation, ReturnReservationForUserDTO>();
            CreateMap<Reservation, ReturnReservationForAdminDTO>();
        }
    }
}
