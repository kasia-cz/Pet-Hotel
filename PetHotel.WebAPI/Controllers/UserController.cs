using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs.UserDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Enums;

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

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(string id)
        {
            await _userAppService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(string id)
        {
            var result = await _userAppService.GetUserById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(string id, UserDTO requestUserDTO)
        {
            var result = await _userAppService.UpdateUser(id, requestUserDTO);
            return Ok(result);
        }

        [HttpPut("userRole/{id}")]
        public async Task<ActionResult<UpdateUserRoleDTO>> UpdateUserRole(string id, UserRole requestUserRole)
        {
            var result = await _userAppService.UpdateUserRole(id, requestUserRole);
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
        public async Task<ActionResult> Logout()
        {
            await _userAppService.Logout();
            return NoContent();
        }
    }
}