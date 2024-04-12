using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using PetHotel.Data.Entities;
using Microsoft.AspNetCore.Identity;
using PetHotel.Data.Constants;

namespace PetHotel.Data.Context
{
    public class PetHotelDbContext : IdentityDbContext<User>
    {
        public DbSet<Pet> Pets { get; set; }
        public DbSet<PetType> PetTypes { get; set; }
        public DbSet<Reservation> Reservations { get; set; }
        public DbSet<User> Users { get; set; }

        public PetHotelDbContext(DbContextOptions<PetHotelDbContext> options) : base(options) { }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            SetRoles(modelBuilder);

            modelBuilder.Entity<Pet>()
                .HasMany(p => p.Reservations)
                .WithMany(r => r.Pets)
                .UsingEntity<Dictionary<string, object>>(
                    "PetsReservations",
                    x => x.HasOne<Reservation>().WithMany().OnDelete(DeleteBehavior.Cascade),
                    x => x.HasOne<Pet>().WithMany().OnDelete(DeleteBehavior.Restrict)
                );

            modelBuilder.Entity<Reservation>()
                .HasMany(r => r.Pets)
                .WithMany(p => p.Reservations);

            modelBuilder.Entity<Pet>()
                .HasOne(p => p.User)
                .WithMany(u => u.Pets)
                .HasForeignKey(p => p.UserId);

            modelBuilder.Entity<Reservation>()
                .HasOne(r => r.User)
                .WithMany(u => u.Reservations)
                .HasForeignKey(r => r.UserId);
        }

        private void SetRoles(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<IdentityRole>().HasData(
            new IdentityRole() { 
                Name = UserConstants.UserRoles.Admin, 
                NormalizedName = UserConstants.UserRoles.Admin.ToUpper(), 
                ConcurrencyStamp = "1" },
            new IdentityRole() { 
                Name = UserConstants.UserRoles.User, 
                NormalizedName = UserConstants.UserRoles.User.ToUpper(), 
                ConcurrencyStamp = "2" });
        }
    }
}
