using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using PetHotel.Application;
using PetHotel.Application.MappingProfiles;
using PetHotel.Data.Context;
using PetHotel.Data.Entities;
using PetHotel.Domain;

namespace PetHotel.WebAPI
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            builder.Services.RegisterApplicationServices();
            builder.Services.RegisterDomainServices();

            builder.Services.AddDbContext<PetHotelDbContext>(options =>
            {
                options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
            });

            builder.Services.AddAuthorization();

            builder.Services.AddIdentity<User, IdentityRole>(options =>
            {
                options.Password.RequiredUniqueChars = 0;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequiredLength = 8;

            }).AddEntityFrameworkStores<PetHotelDbContext>().AddDefaultTokenProviders();

            builder.Services.AddAutoMapper(typeof(PetTypeMappingProfile), typeof(UserMappingProfile),
                typeof(PetMappingProfile), typeof(ReservationMappingProfile));

            builder.Services.AddHttpContextAccessor();

            var app = builder.Build();

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseHttpsRedirection();

            app.UseAuthorization();

            app.MapControllers();

            app.Run();
        }
    }
}
