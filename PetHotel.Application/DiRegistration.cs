using Microsoft.Extensions.DependencyInjection;
using PetHotel.Application.Interfaces;
using PetHotel.Application.Services;

namespace PetHotel.Application
{
    public static class DiRegistration
    {
        public static IServiceCollection RegisterApplicationServices(this IServiceCollection collection)
        {
            collection.AddScoped<IPetTypeAppService, PetTypeAppService>();
            return collection;
        }
    }
}
