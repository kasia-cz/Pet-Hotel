using AutoMapper;
using PetHotel.Application.DTOs.PetDTOs;
using PetHotel.Application.Interfaces;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Application.Services
{
    public class PetTypeAppService : IPetTypeAppService
    {
        private readonly IPetTypeService _petTypeService;
        private readonly IMapper _mapper;

        public PetTypeAppService(IPetTypeService petTypeService, IMapper mapper)
        {
            _petTypeService = petTypeService;
            _mapper = mapper;
        }

        public async Task<List<PetTypeDTO>> AddPetType(PetTypeDTO petTypeDTO)
        {
            var mappedPetType = _mapper.Map<PetType>(petTypeDTO);
            var petTypeList = await _petTypeService.AddPetType(mappedPetType);

            return _mapper.Map<List<PetTypeDTO>>(petTypeList);
        }

        public async Task<List<PetTypeDTO>> DeletePetType(string name)
        {
            var petTypeList = await _petTypeService.DeletePetType(name);

            return _mapper.Map<List<PetTypeDTO>>(petTypeList);
        }

        public async Task<List<PetTypeDTO>> GetAllPetTypes()
        {
            var petTypeList = await _petTypeService.GetAllPetTypes(); 

            return _mapper.Map<List<PetTypeDTO>>(petTypeList);
        }

        public async Task<PetTypeDTO> GetPetTypeByName(string name)
        {
            var petType = await _petTypeService.GetPetTypeByName(name);

            return _mapper.Map<PetTypeDTO>(petType);
        }

        public async Task<List<PetTypeDTO>> UpdatePetTypeLimit(string name, int requestLimit)
        {
            var petTypeList = await _petTypeService.UpdatePetTypeLimit(name, requestLimit);

            return _mapper.Map<List<PetTypeDTO>>(petTypeList);
        }
    }
}
