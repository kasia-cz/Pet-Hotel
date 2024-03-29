using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Domain.Services
{
    public class PetTypeService : IPetTypeService
    {
        private readonly PetHotelDbContext _context;

        public PetTypeService(PetHotelDbContext context)
        {
            _context = context;
        }

        public async Task<List<PetType>> AddPetType(PetType petType)
        {
            _context.PetTypes.Add(petType);
            await _context.SaveChangesAsync();

            return await _context.PetTypes.ToListAsync();
        }

        public async Task<List<PetType>> DeletePetType(string name)
        {
            var petType = await _context.PetTypes.FindAsync(name);
            _context.PetTypes.Remove(petType);
            await _context.SaveChangesAsync();

            return await _context.PetTypes.ToListAsync();
        }

        public async Task<List<PetType>> GetAllPetTypes()
        {
            return await _context.PetTypes.ToListAsync();
        }

        public async Task<List<PetType>> UpdatePetTypeLimit(string name, int requestLimit)
        {
            var petType = await _context.PetTypes.FindAsync(name);
            petType.LimitOfPlaces = requestLimit;
            await _context.SaveChangesAsync();

            return await _context.PetTypes.ToListAsync();
        }
    }
}
