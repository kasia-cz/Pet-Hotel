using AutoMapper;
using PetHotel.Application.DTOs;
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

        public async Task<PetDTO> AddPet(PetDTO petDTO, int userId)
        {
            // TO DO: connect Pet with current User (after adding logging)
            var mappedPet = _mapper.Map<Pet>(petDTO);
            mappedPet.UserId = userId; // temporary solution
            await _petService.AddPet(mappedPet);

            return petDTO;
        }

        public async Task DeletePet(int id)
        {
            await _petService.DeletePet(id);
        }

        public async Task<List<GetUsersPetsDTO>> GetAllUsersPets(int userId)
        {
            var usersPets = await _petService.GetAllUsersPets(userId);

            return _mapper.Map<List<GetUsersPetsDTO>>(usersPets);
        }

        public async Task<PetDTO> GetPetById(int id)
        {
            var pet = await _petService.GetPetById(id);

            return _mapper.Map<PetDTO>(pet);
        }

        public async Task<PetDTO> UpdatePet(int id, PetDTO requestPetDTO)
        {
            var mappedRequestPet = _mapper.Map<Pet>(requestPetDTO);
            await _petService.UpdatePet(id, mappedRequestPet);

            return requestPetDTO;
        }
    }
}
