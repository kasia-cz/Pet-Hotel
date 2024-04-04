using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly PetHotelDbContext _context;

        public PetService(PetHotelDbContext context)
        {
            _context = context;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task DeletePet(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pet>> GetAllUsersPets(string userId)
        {
            var usersPets = await _context.Pets.Where(p => p.UserId == userId).ToListAsync();
            return usersPets;
        }

        public async Task<Pet> GetPetById(int id)
        {
            return await _context.Pets.FindAsync(id);
        }

        public async Task<Pet> UpdatePet(int id, Pet requestPet)
        {
            var pet = await _context.Pets.FindAsync(id);

            pet.Name = requestPet.Name;
            pet.Type = requestPet.Type;
            pet.Breed = requestPet.Breed;
            pet.DateOfBirth = requestPet.DateOfBirth;
            pet.Weight = requestPet.Weight;
            pet.Diseases = requestPet.Diseases;
            pet.NutritionalRequirements = requestPet.NutritionalRequirements;
            pet.AnotherInformations = requestPet.AnotherInformations;

            await _context.SaveChangesAsync();

            return requestPet;
        }
    }
}
