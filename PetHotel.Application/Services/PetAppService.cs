﻿using AutoMapper;
using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Application.Validation.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Application.Services
{
    public class PetAppService : IPetAppService
    {
        private readonly IPetService _petService;
        private readonly IPetTypeValidationService _petTypeValidationService;
        private readonly IMapper _mapper;

        public PetAppService(IPetService petService, IPetTypeValidationService petTypeValidationService, IMapper mapper)
        {
            _petService = petService;
            _petTypeValidationService = petTypeValidationService;
            _mapper = mapper;
        }

        public async Task<ReturnPetDTO> AddPet(AddPetDTO addPetDTO)
        {
            await _petTypeValidationService.ValidatePetType(addPetDTO.Type);
            var requestPet = _mapper.Map<Pet>(addPetDTO);
            var pet = await _petService.AddPet(requestPet);

            return _mapper.Map<ReturnPetDTO>(pet);
        }

        public async Task DeletePet(int id)
        {
            await _petService.DeletePet(id);
        }

        public async Task<List<ReturnPetShortDTO>> GetUserPets()
        {
            var userPets = await _petService.GetUserPets();

            return _mapper.Map<List<ReturnPetShortDTO>>(userPets);
        }

        public async Task<ReturnPetDTO> GetPetById(int id)
        {
            var pet = await _petService.GetPetById(id);

            return _mapper.Map<ReturnPetDTO>(pet);
        }

        public async Task<ReturnPetDTO> UpdatePet(int id, AddPetDTO requestPetDTO)
        {
            await _petTypeValidationService.ValidatePetType(requestPetDTO.Type);
            var requestPet = _mapper.Map<Pet>(requestPetDTO);
            var pet = await _petService.UpdatePet(id, requestPet);

            return _mapper.Map<ReturnPetDTO>(pet);
        }
    }
}
