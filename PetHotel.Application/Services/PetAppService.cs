using AutoMapper;
using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Application.Services
{
    public class PetAppService : IPetAppService
    {
        private readonly IPetService _petService;
        private readonly IMapper _mapper;

        public PetAppService(IPetService petService, IMapper mapper)
        {
            _petService = petService;
            _mapper = mapper;
        }

        public async Task<PetDTO> AddPet(AddPetDTO addPetDTO)
        {
            var mappedPet = _mapper.Map<Pet>(addPetDTO);
            var pet = await _petService.AddPet(mappedPet);

            return _mapper.Map<PetDTO>(pet);
        }

        public async Task DeletePet(int id)
        {
            await _petService.DeletePet(id);
        }

        public async Task<List<GetUserPetsDTO>> GetUserPets()
        {
            var userPets = await _petService.GetUserPets();

            return _mapper.Map<List<GetUserPetsDTO>>(userPets);
        }

        public async Task<PetDTO> GetPetById(int id)
        {
            var pet = await _petService.GetPetById(id);

            return _mapper.Map<PetDTO>(pet);
        }

        public async Task<PetDTO> UpdatePet(int id, AddPetDTO requestPetDTO)
        {
            var mappedRequestPet = _mapper.Map<Pet>(requestPetDTO);
            var pet = await _petService.UpdatePet(id, mappedRequestPet);

            return _mapper.Map<PetDTO>(pet);
        }
    }
}
