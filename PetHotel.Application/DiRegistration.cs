using FluentValidation;
using Microsoft.Extensions.DependencyInjection;
using PetHotel.Application.Interfaces;
using PetHotel.Application.Services;
using System.Reflection;

namespace PetHotel.Application
{
    public static class DiRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection collection)
        {
            collection.AddScoped<IPetTypeAppService, PetTypeAppService>();
            collection.AddScoped<IUserAppService, UserAppService>();
            collection.AddScoped<IPetAppService, PetAppService>();
            collection.AddScoped<IReservationAppService, ReservationAppService>();
            collection.AddValidatorsFromAssembly(Assembly.GetExecutingAssembly());

            return collection;
        }
    }
}
