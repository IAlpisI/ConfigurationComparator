using ConfigurationComparatorAPI.Interfaces;
using ConfigurationComparatorAPI.Manage.Cache.ConfigurationFile;
using ConfigurationComparatorAPI.Services;
using Microsoft.Extensions.DependencyInjection;

namespace ConfigurationComparatorAPI.Configuration
{
    public static class ConfigureAPIServices
    {
        public static IServiceCollection AddApiServices(this IServiceCollection services)
        {
            services.AddScoped<IConfigurationService, ConfigurationService>();
            services.AddScoped<IFileService, FileService>();
            services.AddSingleton<IConfFileCache, ConfFileCache>();

            return services;
        }
    }
}
