using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Constants;

namespace PetHotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserAppService _userAppService;

        public UserController(IUserAppService userAppService)
        {
            _userAppService = userAppService;
        }

        [HttpGet]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<List<ReturnUserShortDTO>>> GetAllUsers()
        {
            var result = await _userAppService.GetAllUsers();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<ReturnUserDTO>> GetUserById(string id)
        {
            var result = await _userAppService.GetUserById(id);
            return Ok(result);
        }

        [HttpGet("currentUser")]
        [Authorize]
        public async Task<ActionResult<ReturnUserDTO>> GetCurrentUser()
        {
            var result = await _userAppService.GetCurrentUser();
            return Ok(result);
        }

        [HttpPut]
        [Authorize]
        public async Task<ActionResult<ReturnUserDTO>> UpdateUser(UpdateUserDTO requestUserDTO)
        {
            var result = await _userAppService.UpdateUser(requestUserDTO);
            return Ok(result);
        }

        [HttpPut("userRole/{id}")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<ReturnUserDTO>> SetUserRole(string id, string requestUserRole)
        {
            var result = await _userAppService.SetUserRole(id, requestUserRole);
            return Ok(result);
        }

        [HttpPost("register")]
        public async Task<ActionResult> Register(RegisterDTO model)
        {
            await _userAppService.Register(model);
            return NoContent();
        }

        [HttpPost("login")]
        public async Task<ActionResult> Login(LoginDTO model)
        {
            await _userAppService.Login(model);
            return NoContent();
        }

        [HttpPost("logout")]
        [Authorize]
        public async Task<ActionResult> Logout()
        {
            await _userAppService.Logout();
            return NoContent();
        }
    }
}