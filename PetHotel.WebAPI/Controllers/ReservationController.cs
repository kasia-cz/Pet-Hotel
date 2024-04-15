using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs.ReservationDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Constants;

namespace PetHotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReservationController : ControllerBase
    {
        private readonly IReservationAppService _reservationAppService;

        public ReservationController(IReservationAppService reservationAppService)
        {
            _reservationAppService = reservationAppService;
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult<ReturnReservationForUserDTO>> AddReservation(AddReservationDTO addReservationDTO)
        {
            var result = await _reservationAppService.AddReservation(addReservationDTO);
            return Ok(result);
        }

        [HttpPut("cancel/{id}")]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult<ReturnReservationForUserDTO>> CancelReservation(int id)
        {
            var result = await _reservationAppService.CancelReservation(id);
            return Ok(result);
        }

        [HttpPut("confirm/{id}")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<ReturnReservationForAdminDTO>> ConfirmReservation(int id)
        {
            var result = await _reservationAppService.ConfirmReservation(id);
            return Ok(result);
        }

        [HttpPut("decline/{id}")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<ReturnReservationForAdminDTO>> DeclineReservation(int id)
        {
            var result = await _reservationAppService.DeclineReservation(id);
            return Ok(result);
        }

        [HttpGet]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult<List<ReturnReservationForUserDTO>>> GetUserReservations()
        {
            var result = await _reservationAppService.GetUserReservations();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult<ReturnReservationForUserDTO>> GetReservationByIdForUser(int id)
        {
            var result = await _reservationAppService.GetReservationByIdForUser(id);
            return Ok(result);
        }

        [HttpGet("detailed/{id}")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<ReturnReservationForAdminDTO>> GetReservationByIdForAdmin(int id)
        {
            var result = await _reservationAppService.GetReservationByIdForAdmin(id);
            return Ok(result);
        }

        [HttpGet("all")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<List<ReturnReservationForAdminDTO>>> GetAllReservations(string? reservationStatus, DateTime dateFrom, DateTime dateTo)
        {
            var result = await _reservationAppService.GetAllReservations(reservationStatus, dateFrom, dateTo);
            return Ok(result);
        }
    }
}
