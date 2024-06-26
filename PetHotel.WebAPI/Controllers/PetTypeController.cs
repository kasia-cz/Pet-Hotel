﻿using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Constants;

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
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<List<PetTypeDTO>>> AddPetType(PetTypeDTO petTypeDTO)
        {
            var result = await _petTypeAppService.AddPetType(petTypeDTO);
            return Ok(result);
        }

        [HttpDelete("{name}")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<List<PetTypeDTO>>> DeletePetType(string name)
        {
            var result = await _petTypeAppService.DeletePetType(name);
            return Ok(result);
        }

        [HttpGet]
        [Authorize]
        public async Task<ActionResult<List<PetTypeDTO>>> GetAllPetTypes()
        {
            var result = await _petTypeAppService.GetAllPetTypes();
            return Ok(result);
        }

        [HttpGet("{name}")]
        [Authorize]
        public async Task<ActionResult<PetTypeDTO>> GetPetTypeByName(string name)
        {
            var result = await _petTypeAppService.GetPetTypeByName(name);
            return Ok(result);
        }

        [HttpPut("{name}")]
        [Authorize(Roles = UserConstants.UserRoles.Admin)]
        public async Task<ActionResult<List<PetTypeDTO>>> UpdatePetTypeLimit(string name, int requestLimit)
        {
            var result = await _petTypeAppService.UpdatePetTypeLimit(name, requestLimit);
            return Ok(result);
        }
    }
}
