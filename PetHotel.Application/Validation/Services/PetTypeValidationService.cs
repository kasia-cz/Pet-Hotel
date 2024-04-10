﻿using PetHotel.Application.Validation.Interfaces;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Application.Validation.Services
{
    public class PetTypeValidationService : IPetTypeValidationService
    {
        private readonly IPetTypeService _petTypeService;

        public PetTypeValidationService(IPetTypeService petTypeService)
        {
            _petTypeService = petTypeService;
        }

        public async Task ValidatePetType(string petType)
        {
            var petTypeList = await _petTypeService.GetAllPetTypes();
            var isValid = petTypeList.Any(type => type.Name == petType);

            if (!isValid)
            {
                throw new Exception("Pet type must be selected from PetType list"); // TODO: BadRequestExceptions
            }
        }
    }
}
