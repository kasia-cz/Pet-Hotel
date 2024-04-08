using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs.ReservationDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Enums;

namespace PetHotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationAppService _reservationAppService;

        public ReservationController(IReservationAppService reservationAppService)
        {
            _reservationAppService = reservationAppService;
        }

        [HttpPost]
        public async Task<ActionResult<ReservationDTO>> AddReservation(AddReservationDTO addReservationDTO)
        {
            var result = await _reservationAppService.AddReservation(addReservationDTO);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<ReservationDTO>> CancelReservation(int id)
        {
            var result = await _reservationAppService.CancelReservation(id);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<ReservationDTO>>> GetUserReservations()
        {
            var result = await _reservationAppService.GetUserReservations();
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<ReservationDTO>> GetReservationById(int id)
        {
            var result = await _reservationAppService.GetReservationById(id);
            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<ActionResult<List<ReservationForAdminDTO>>> GetAllReservations(string? reservationStatus, DateTime dateFrom, DateTime dateTo)
        {
            var result = await _reservationAppService.GetAllReservations(reservationStatus, dateFrom, dateTo);
            return Ok(result);
        }
    }
}
