// *******************************************************************************
// Filename       : CalculatedTaxHistoryRepository.cs
// Type           : Class
// Function       : Calculated Tax History - Repository Core
// *******************************************************************************

using DomainModels.DataModels;
using Repository.Contract;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Repository.Core
{
    public class CalculatedTaxHistoryRepository : ICalculatedTaxHistoryRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<CalculatedTaxHistoryRepository> _logger;

        public CalculatedTaxHistoryRepository(string connectionString, ILogger<CalculatedTaxHistoryRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<List<CalculatedTaxHistoryRecord>> GetCalculatedTaxHistoryByPostalCodeAsync(CalculatedTaxHistoryRecord dto)
        {
            List<CalculatedTaxHistoryRecord> CalculatedTaxHistory_ListDto = new List<CalculatedTaxHistoryRecord>();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var SQL_Query = "SELECT [ID], [PostalCode], [AnnualIncome], [CalculatedTax], [CalculatedDateTime] FROM [GTXCalculations].[dbo].[CalculatedTaxHistory] WHERE [PostalCode] = @PostalCode";

                    CalculatedTaxHistory_ListDto = (await connection.QueryAsync<CalculatedTaxHistoryRecord>(SQL_Query, new { dto.PostalCode })).ToList();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in - CalculatedTaxHistoryRepository.");
                throw;
            }

            return CalculatedTaxHistory_ListDto;
        }

        public async Task<CalculatedTaxHistoryRecord> InsertCalculatedTaxHistoryAsync(CalculatedTaxHistoryRecord dto)
        {
            CalculatedTaxHistoryRecord CalculatedTaxHistoryDto = new CalculatedTaxHistoryRecord();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var SQL_Query = @"INSERT INTO [GTXCalculations].[dbo].[CalculatedTaxHistory] ([PostalCode], [AnnualIncome], [CalculatedTax])
                                      VALUES (@PostalCode, @AnnualIncome, @CalculatedTax);
                                      SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    var CalculatedTaxHistory_ID = await connection.QuerySingleAsync<int>(SQL_Query, new
                    {
                        dto.PostalCode,
                        dto.AnnualIncome,
                        dto.CalculatedTax
                    });

                    CalculatedTaxHistoryDto = dto;
                    CalculatedTaxHistoryDto.ID = CalculatedTaxHistory_ID;
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in - CalculatedTaxHistoryRepository.");
                throw;
            }

            return CalculatedTaxHistoryDto;
        }

    }
}
