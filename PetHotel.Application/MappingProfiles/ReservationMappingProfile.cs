using AutoMapper;
using PetHotel.Application.DTOs.ReservationDTOs;
using PetHotel.Data.Entities;

namespace PetHotel.Application.MappingProfiles
{
    public class ReservationMappingProfile : Profile
    {
        public ReservationMappingProfile() 
        {
            CreateMap<Reservation, ReservationDTO>();
            CreateMap<AddReservationDTO, Reservation>();
        }
    }
}
