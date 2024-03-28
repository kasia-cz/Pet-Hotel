using Microsoft.EntityFrameworkCore;
using PetHotel.Data.Entities;

namespace PetHotel.Data.Context
{
    public class PetHotelDbContext : DbContext
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        public PetHotelDbContext(DbContextOptions<PetHotelDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Pet>()
                .HasMany(t => t.Reservations)
                .WithMany(s => s.Pets)
                .UsingEntity<Dictionary<string, object>>(
                    "PetsReservations",
                    x => x.HasOne<Reservation>().WithMany().OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne<Pet>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );

            modelBuilder.Entity<Reservation>()
                .HasMany(p => p.Pets)
                .WithMany(r => r.Reservations);
        }
    }
}
