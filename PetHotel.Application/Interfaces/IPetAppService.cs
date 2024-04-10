using PetHotel.Application.DTOs.PetDTOs;

namespace PetHotel.Application.Interfaces
{
    public interface IPetAppService
    {
        Task<List<ReturnPetShortDTO>> GetUserPets();
        Task<ReturnPetDTO> GetPetById(int id);
        Task<ReturnPetDTO> AddPet(AddPetDTO addPetDTO);
        Task DeletePet(int id);
        Task<ReturnPetDTO> UpdatePet(int id, AddPetDTO requestPetDTO);
    }
}
