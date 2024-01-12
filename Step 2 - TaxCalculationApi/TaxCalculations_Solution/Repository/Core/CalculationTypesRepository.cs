// *******************************************************************************
// Filename       : CalculationTypesRepository.cs
// Type           : Class
// Function       : Calculation Types - Repository Core
// *******************************************************************************

using DomainModels.DataModels;
using Repository.Contract;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Repository.Core
{
    public class CalculationTypesRepository : ICalculationTypesRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<CalculationTypesRepository> _logger;

        public CalculationTypesRepository(string connectionString, ILogger<CalculationTypesRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<CalculationTypesRecord> GetCalculationTypesByIDAsync(CalculationTypesRecord dto)
        {
            CalculationTypesRecord CalculationTypesDto = new CalculationTypesRecord();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var SQL_Query = "SELECT [ID], [Description] FROM [GTXCalculations].[dbo].[CalculationTypes] WHERE [ID] = @ID";

                    CalculationTypesDto = (await connection.QueryAsync<CalculationTypesRecord>(SQL_Query, new { dto.ID })).FirstOrDefault();

                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in - CalculationTypesRepository.");
                throw;
            }

            return CalculationTypesDto;
        }
    }
}
