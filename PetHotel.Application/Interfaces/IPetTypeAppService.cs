using PetHotel.Application.DTOs;
using PetHotel.Data.Entities;

namespace PetHotel.Application.Interfaces
{
    public interface IPetTypeAppService
    {
        Task<List<PetTypeDTO>> GetAllPetTypes();
        Task<PetTypeDTO> GetPetTypeByName(string name);
        Task<List<PetTypeDTO>> AddPetType(PetTypeDTO petTypeDTO);
        Task<List<PetTypeDTO>> DeletePetType(string name);
        Task<List<PetTypeDTO>> UpdatePetTypeLimit(string name, int requestLimit);
    }
}
