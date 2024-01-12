using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using Repository.Contract;
using Repository.Core;

namespace Repository
{
    public static class DependencyLoader
    {
        public static void RegisterRepository(this IServiceCollection services, IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("GTAXCALCULATIONS_Connection") ?? string.Empty;

            services.AddScoped<ICalculatedTaxHistoryRepository>(provider => new CalculatedTaxHistoryRepository(connectionString, provider.GetRequiredService<ILogger<CalculatedTaxHistoryRepository>>()));
            services.AddScoped<ICalculationTypesRepository>(provider => new CalculationTypesRepository(connectionString, provider.GetRequiredService<ILogger<CalculationTypesRepository>>()));
            services.AddScoped<IPostalCodeMasterRepository>(provider => new PostalCodeMasterRepository(connectionString, provider.GetRequiredService<ILogger<PostalCodeMasterRepository>>()));
            services.AddScoped<ITaxCalculationTypesRepository>(provider => new TaxCalculationTypesRepository(connectionString, provider.GetRequiredService<ILogger<TaxCalculationTypesRepository>>()));
            services.AddScoped<ITaxRulesRepository>(provider => new TaxRulesRepository(connectionString, provider.GetRequiredService<ILogger<TaxRulesRepository>>()));
        }
    }
}