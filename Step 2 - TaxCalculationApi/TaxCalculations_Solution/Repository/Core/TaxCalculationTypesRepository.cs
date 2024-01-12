// *******************************************************************************
// Filename       : TaxCalculationTypesRepository.cs
// Type           : Class
// Function       : Tax Calculation Types - Repository Core
// *******************************************************************************

using DomainModels.DataModels;
using Repository.Contract;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Repository.Core
{
    public class TaxCalculationTypesRepository : ITaxCalculationTypesRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<TaxCalculationTypesRepository> _logger;

        public TaxCalculationTypesRepository(string connectionSting, ILogger<TaxCalculationTypesRepository> logger)
        {
            _connectionString = connectionSting;
            _logger = logger;
        }

        public async Task<TaxCalculationTypesRecord> GetTaxCalculationTypesByIDAsync(TaxCalculationTypesRecord dto)
        {
            TaxCalculationTypesRecord TaxCalculationTypesDto = new TaxCalculationTypesRecord();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var SQL_Query = "SELECT [ID], [Description] FROM [GTXCalculations].[dbo].[TaxCalculationTypes] WHERE [ID] = @ID";

                    TaxCalculationTypesDto = (await connection.QueryAsync<TaxCalculationTypesRecord>(SQL_Query, new { dto.ID })).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in - TaxCalculationTypesRepository.");
                throw;
            }

            return TaxCalculationTypesDto;
        }
    }
}
