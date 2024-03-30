using PetHotel.Application.DTOs;

namespace PetHotel.Application.Interfaces
{
    public interface IPetTypeAppService
    {
        Task<List<PetTypeDTO>> GetAllPetTypes(); 
        Task<List<PetTypeDTO>> AddPetType(PetTypeDTO petTypeDTO);
        Task<List<PetTypeDTO>> DeletePetType(string name);
        Task<List<PetTypeDTO>> UpdatePetTypeLimit(string name, int requestLimit);
    }
}
