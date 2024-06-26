﻿using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Domain.Exceptions;
using PetHotel.Domain.Interfaces;

namespace PetHotel.Domain.Services
{
    public class PetService : IPetService
    {
        private readonly PetHotelDbContext _context;
        private readonly IUserService _userService;

        public PetService(PetHotelDbContext context, IUserService userService)
        {
            _context = context;
            _userService = userService;
        }

        public async Task<Pet> AddPet(Pet pet)
        {
            pet.UserId = _userService.GetCurrentUserId();
            _context.Pets.Add(pet);
            await _context.SaveChangesAsync();

            return pet;
        }

        public async Task DeletePet(int id)
        {
            var pet = await GetPetById(id);
            _context.Pets.Remove(pet);
            await _context.SaveChangesAsync();
        }

        public async Task<List<Pet>> GetUserPets()
        {
            var currentUserId = _userService.GetCurrentUserId();
            var userPets = await _context.Pets.Where(p => p.UserId == currentUserId).ToListAsync();
            
            return userPets;
        }

        public async Task<Pet> GetPetById(int id)
        {
            var pet = await _context.Pets.FindAsync(id);
            if (pet == null)
            {
                throw new BadRequestException("Invalid pet ID");
            }
            return pet;
        }

        public async Task<Pet> UpdatePet(int id, Pet requestPet)
        {
            var pet = await GetPetById(id);

            pet.Name = requestPet.Name;
            pet.Type = requestPet.Type;
            pet.Breed = requestPet.Breed;
            pet.DateOfBirth = requestPet.DateOfBirth;
            pet.Weight = requestPet.Weight;
            pet.Diseases = requestPet.Diseases;
            pet.NutritionalRequirements = requestPet.NutritionalRequirements;
            pet.AnotherInformations = requestPet.AnotherInformations;

            await _context.SaveChangesAsync();

            return pet;
        }
    }
}
