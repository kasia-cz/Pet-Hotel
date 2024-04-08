using PetHotel.Application.DTOs.PetDTOs;

namespace PetHotel.Application.Interfaces
{
    public interface IPetAppService
    {
        Task<List<GetUserPetsDTO>> GetUserPets();
        Task<PetDTO> GetPetById(int id);
        Task<PetDTO> AddPet(AddPetDTO addPetDTO);
        Task DeletePet(int id);
        Task<PetDTO> UpdatePet(int id, AddPetDTO requestPetDTO);
    }
}
