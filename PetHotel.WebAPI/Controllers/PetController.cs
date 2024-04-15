using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Constants;

namespace PetHotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetController : ControllerBase
    {
        private readonly IPetAppService _petAppService;

        public PetController(IPetAppService petAppService)
        {
            _petAppService = petAppService;
        }

        [HttpPost]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult<ReturnPetDTO>> AddPet(AddPetDTO addPetDTO)
        {
            var result = await _petAppService.AddPet(addPetDTO);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult> DeletePet(int id)
        {
            await _petAppService.DeletePet(id);
            return NoContent();
        }

        [HttpGet]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult<List<ReturnPetShortDTO>>> GetUserPets()
        {
            var result = await _petAppService.GetUserPets();
            return Ok(result);
        }

        [HttpGet("{id}")]
        [Authorize]
        public async Task<ActionResult<ReturnPetDTO>> GetPetById(int id)
        {
            var result = await _petAppService.GetPetById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        [Authorize(Roles = UserConstants.UserRoles.User)]
        public async Task<ActionResult<ReturnPetDTO>> UpdatePet(int id, AddPetDTO requestPetDTO)
        {
            var result = await _petAppService.UpdatePet(id, requestPetDTO);
            return Ok(result);
        }
    }
}
