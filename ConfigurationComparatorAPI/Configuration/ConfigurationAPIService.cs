using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurationComparatorAPI.Configuration
{
    public static class ConfigurationAPIService
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IFileService, FileService>();

            return services;
        }
    }
}
