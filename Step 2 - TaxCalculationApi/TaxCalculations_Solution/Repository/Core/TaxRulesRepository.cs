// *******************************************************************************
// Filename       : TaxRulesRepository.cs
// Type           : Class
// Function       : Tax Rules - Repository Core
// *******************************************************************************

using DomainModels.DataModels;
using Repository.Contract;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Repository.Core
{
    public class TaxRulesRepository : ITaxRulesRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<TaxRulesRepository> _logger;

        public TaxRulesRepository(string connectionString, ILogger<TaxRulesRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<List<TaxRulesRecord>> GetTaxRulesByTaxCalculationTypeAsync(TaxRulesRecord dto)
        {
            List<TaxRulesRecord> TaxRules_ListDto = new List<TaxRulesRecord>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var SQL_Query = "SELECT [ID], [TaxCalculationTypeID], [FromAmount], [ToAmount], [CalculationTypeID], [CalculationValue] FROM [GTXCalculations].[dbo].[TaxRules] WHERE [TaxCalculationTypeID] = @TaxCalculationTypeID ORDER BY [FromAmount]";

                    TaxRules_ListDto = (await connection.QueryAsync<TaxRulesRecord>(SQL_Query, new { dto.TaxCalculationTypeID })).ToList();                
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in - TaxRulesRepository.");
                throw;
            }

            return TaxRules_ListDto;
        }
    }
}
