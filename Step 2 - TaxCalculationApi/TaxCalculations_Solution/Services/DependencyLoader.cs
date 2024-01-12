using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Services.Contract;
using Services.Core;

namespace Services
{
    public static class DependencyLoader
    {
        public static void RegisterServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<ICalculatedTaxService, CalculatedTaxService>();
            services.AddScoped<ICalculatedTaxHistoryService, CalculatedTaxHistoryService>();

            Repository.DependencyLoader.RegisterRepository(services, configuration);
        }
    }
}