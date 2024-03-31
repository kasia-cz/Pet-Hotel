using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs;
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

        [HttpPost]
        public async Task<ActionResult<UserDTO>> AddUser(UserDTO userDTO)
        {
            var result = await _userAppService.AddUser(userDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeleteUser(int id)
        {
            await _userAppService.DeleteUser(id);
            return NoContent();
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<UserDTO>> GetUserById(int id)
        {
            var result = await _userAppService.GetUserById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<UserDTO>> UpdateUser(int id, UserDTO requestUserDTO)
        {
            var result = await _userAppService.UpdateUser(id, requestUserDTO);
            return Ok(result);
        }

        [HttpPut("userRole/{id}")]
        public async Task<ActionResult<UpdateUserRoleDTO>> UpdateUserRole(int id, UserRole requestUserRole)
        {
            var result = await _userAppService.UpdateUserRole(id, requestUserRole);
            return Ok(result);
        }
    }
}