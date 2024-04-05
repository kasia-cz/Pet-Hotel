using PetHotel.Data.Entities;

namespace PetHotel.Domain.Interfaces
{
    public interface IPetService
    {
        Task<List<Pet>> GetAllUsersPets();
        Task<Pet> GetPetById(int id);
        Task<Pet> AddPet(Pet pet);
        Task DeletePet(int id);
        Task<Pet> UpdatePet(int id, Pet requestPet);
    }
}
