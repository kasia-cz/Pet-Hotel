using PetHotel.Application.DTOs;
using PetHotel.Data.Entities;

namespace PetHotel.Application.Interfaces
{
    public interface IPetAppService
    {
        Task<List<GetUsersPetsDTO>> GetAllUsersPets(int userId);
        Task<PetDTO> GetPetById(int id);
        Task<PetDTO> AddPet(PetDTO petDTO);
        Task DeletePet(int id);
        Task<PetDTO> UpdatePet(int id, PetDTO requestPetDTO);
    }
}
