using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Entities;

namespace PetHotel.Data.Context
{
    internal class PetHotelDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        public PetHotelDbContext(DbContextOptions<PetHotelDbContext> options) : base(options) { }
    }
}
