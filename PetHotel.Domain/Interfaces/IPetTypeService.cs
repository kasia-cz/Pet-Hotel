using PetHotel.Data.Entities;

namespace PetHotel.Domain.Interfaces
{
    public interface IPetTypeService
    {
        Task<List<PetType>> GetAllPetTypes();
        Task<PetType> GetPetTypeByName(string name);
        Task<List<PetType>> AddPetType(PetType petType);
        Task<List<PetType>> DeletePetType(string name);
        Task<List<PetType>> UpdatePetTypeLimit(string name, int requestLimit);
    }
}
