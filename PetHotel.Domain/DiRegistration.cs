﻿using Microsoft.Extensions.DependencyInjection;
using PetHotel.Domain.Interfaces;
using PetHotel.Domain.Services;

namespace PetHotel.Domain
{
    public static class DiRegistration
    {
        public static IServiceCollection RegisterDomainServices(this IServiceCollection collection)
        {
            collection.AddScoped<IPetTypeService, PetTypeService>();
            return collection;
        }
    }
}
