using AutoMapper;
using PetHotel.Application.DTOs.ReservationDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Application.Services
{
    public class ReservationAppService : IReservationAppService
    {
        private readonly IReservationService _reservationService;
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public ReservationAppService(IReservationService reservationService, IPetService petService, IMapper mapper)
        {
            _reservationService = reservationService;
            _petService = petService;
            _mapper = mapper;
        }

        public async Task<ReservationDTO> AddReservation(AddReservationDTO addReservationDTO)
        {
            var mappedReservation = _mapper.Map<Reservation>(addReservationDTO);
            mappedReservation.Pets = new List<Pet>();

            foreach (int petId in addReservationDTO.PetsId)
            {
                var pet = await _petService.GetPetById(petId);
                mappedReservation.Pets.Add(pet);
            }
            var response = await _reservationService.AddReservation(mappedReservation);

            return _mapper.Map<ReservationDTO>(response);
        }
        
        public async Task<ReservationDTO> CancelReservation(int id)
        {
            var reservation = await _reservationService.CancelReservation(id);

            return _mapper.Map<ReservationDTO>(reservation);
        }

        public async Task<List<ReservationDTO>> GetUserReservations()
        {
            var usersReservations = await _reservationService.GetUserReservations();

            return _mapper.Map<List<ReservationDTO>>(usersReservations);
        }

        public async Task<ReservationDTO> GetReservationById(int id)
        {
            var reservation = await _reservationService.GetReservationById(id);

            return _mapper.Map<ReservationDTO>(reservation);
        }
    }
}
