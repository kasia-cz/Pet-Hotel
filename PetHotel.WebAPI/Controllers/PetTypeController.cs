using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs;
using PetHotel.Application.Interfaces;

namespace PetHotel.WebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PetTypeController : ControllerBase
    {
        private readonly IPetTypeAppService _petTypeAppService;

        public PetTypeController(IPetTypeAppService petTypeAppService)
        {
            _petTypeAppService = petTypeAppService;
        }

        [HttpPost]
        public async Task<ActionResult<List<PetTypeDTO>>> AddPetType(PetTypeDTO petTypeDTO)
        {
            var result = await _petTypeAppService.AddPetType(petTypeDTO);
            return Ok(result);
        }

        [HttpDelete("{name}")]
        public async Task<ActionResult<List<PetTypeDTO>>> DeletePetType(string name)
        {
            var result = await _petTypeAppService.DeletePetType(name);
            return Ok(result);
        }

        [HttpGet]
        public async Task<ActionResult<List<PetTypeDTO>>> GetAllPetTypes()
        {
            var result = await _petTypeAppService.GetAllPetTypes();
            return Ok(result);
        }

        [HttpPut("{name}")]
        public async Task<ActionResult<List<PetTypeDTO>>> UpdatePetTypeLimit(string name, int requestLimit)
        {
            var result = await _petTypeAppService.UpdatePetTypeLimit(name, requestLimit);
            return Ok(result);
        }
    }
}
