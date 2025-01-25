using Microsoft.Extensions.DependencyInjection;
using RapidPay.Services.Implementations;
using RapidPay.Services.Interfaces;
using RapidPay.Services.Mapping;

namespace RapidPay.Services
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddServiceLayer(this IServiceCollection services)
        {
            services.AddScoped<ICardService, CardService>();
            services.AddHostedService<HourlyTaskService>();
            services.AddAutoMapper(typeof(MappingProfile));
            
            return services;
        }
    }
}
