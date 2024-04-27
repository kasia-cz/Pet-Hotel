using AutoMapper;
using PetHotel.Application.DTOs.ReservationDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Application.Validation.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Application.Services
{
    public class ReservationAppService : IReservationAppService
    {
        private readonly IReservationService _reservationService;
        private readonly IReservationValidationService _reservationValidationService;
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public ReservationAppService(IReservationService reservationService, IReservationValidationService reservationValidationService, IPetService petService, IMapper mapper)
        {
            _reservationService = reservationService;
            _reservationValidationService = reservationValidationService;
            _petService = petService;
            _mapper = mapper;
        }

        public async Task<ReturnReservationForUserDTO> AddReservation(AddReservationDTO addReservationDTO)
        {
            var requestReservation = _mapper.Map<Reservation>(addReservationDTO);
            requestReservation.Pets = new List<Pet>();

            foreach (int petId in addReservationDTO.PetsId)
            {
                var pet = await _petService.GetPetById(petId);
                requestReservation.Pets.Add(pet);
            }
            await _reservationValidationService.ValidateReservation(requestReservation);
            var reservation = await _reservationService.AddReservation(requestReservation);

            return _mapper.Map<ReturnReservationForUserDTO>(reservation);
        }
        
        public async Task<ReturnReservationForUserDTO> CancelReservation(int id)
        {
            var reservation = await _reservationService.CancelReservation(id);

            return _mapper.Map<ReturnReservationForUserDTO>(reservation);
        }

        public async Task<ReturnReservationForAdminDTO> ConfirmReservation(int id)
        {
            var reservation = await _reservationService.ConfirmReservation(id);

            return _mapper.Map<ReturnReservationForAdminDTO>(reservation);
        }

        public async Task<ReturnReservationForAdminDTO> DeclineReservation(int id)
        {
            var reservation = await _reservationService.DeclineReservation(id);

            return _mapper.Map<ReturnReservationForAdminDTO>(reservation);
        }

        public async Task<List<ReturnReservationForUserDTO>> GetUserReservations()
        {
            var userReservations = await _reservationService.GetUserReservations();

            return _mapper.Map<List<ReturnReservationForUserDTO>>(userReservations);
        }

        public async Task<ReturnReservationForUserDTO> GetReservationByIdForUser(int id)
        {
            var reservation = await _reservationService.GetReservationByIdForUser(id);

            return _mapper.Map<ReturnReservationForUserDTO>(reservation);
        }

        public async Task<ReturnReservationForAdminDTO> GetReservationByIdForAdmin(int id)
        {
            var reservation = await _reservationService.GetReservationByIdForAdmin(id);

            return _mapper.Map<ReturnReservationForAdminDTO>(reservation);
        }

        public async Task<List<ReturnReservationForAdminDTO>> GetAllReservations(string? reservationStatus, DateTime startDate, DateTime endDate)
        {
            var reservations = await _reservationService.GetAllReservations(reservationStatus, startDate, endDate);

            return _mapper.Map<List<ReturnReservationForAdminDTO>>(reservations);
        }
    }
}
