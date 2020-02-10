using Microsoft.Extensions.Configuration;
using RestSharp.Deserializers;
using SearchFight.ConsoleProgram;
using SearchFight.IServices;
using SearchFight.Services;
using SearchFight.Services.ApiClients;
using SearchFight.Services.ApiClients.Interfaces;
using SearchFight.Services.ServiceMappers;
using SearchFight.Services.ServiceMappers.Interfaces;
using System.IO;

namespace Microsoft.Extensions.DependencyInjection
{
    public static class IServiceCollectionExtension
    {
        public static IServiceCollection AddCustomServices(this IServiceCollection services)
        {
            services.AddTransient<ISearchEngineService, SearchEngineService>();
            services.AddTransient<ISearchEngineResultService, SearchEngineResultService>();
            services.AddTransient<ISearchEngineFight, SearchEngineFight>();

            services.AddTransient<ConsoleApplication>();

            return services;
        }

        public static IServiceCollection AddCustomApiClients(this IServiceCollection services)
        {            
            services.AddSingleton<IDeserializer, JsonSerializer>();
            services.AddSingleton<ICacheService, InMemoryCache>();

            services.AddSingleton<IBingSearchEngineClient, BingSearchEngineClient>();
            services.AddSingleton<IGoogleSearchEngineClient, GoogleSearchEngineClient>();
            

            return services;
        }

        public static IServiceCollection AddCustomServiceMappers(this IServiceCollection services)
        {
            services.AddSingleton<ISearchEngineResultServiceMapper, SearchEngineMatchResultServiceMapper>();

            return services;
        }

        public static IServiceCollection AddCustomConfig(this IServiceCollection services)
        {
            var config = LoadConfiguration(); 
            services.AddSingleton(config);

            return services;
        }

        public static IConfiguration LoadConfiguration()
        {
            var builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: true,
                             reloadOnChange: true); return builder.Build();
        }
    }
}
