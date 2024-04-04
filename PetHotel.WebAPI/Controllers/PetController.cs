using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs;
using PetHotel.Application.Interfaces;

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
        public async Task<ActionResult<PetDTO>> AddPet(PetDTO petDTO, string userId)
        {
            var result = await _petAppService.AddPet(petDTO, userId);
            return Ok(result);
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> DeletePet(int id)
        {
            await _petAppService.DeletePet(id);
            return NoContent();
        }

        [HttpGet("usersPets/{userId}")]
        public async Task<ActionResult<List<GetUsersPetsDTO>>> GetAllUsersPets(string userId)
        {
            var result = await _petAppService.GetAllUsersPets(userId);
            return Ok(result);
        }

        [HttpGet("{id}")]
        public async Task<ActionResult<PetDTO>> GetPetById(int id)
        {
            var result = await _petAppService.GetPetById(id);
            return Ok(result);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult<PetDTO>> UpdatePet(int id, PetDTO requestPetDTO)
        {
            var result = await _petAppService.UpdatePet(id, requestPetDTO);
            return Ok(result);
        }
    }
}
