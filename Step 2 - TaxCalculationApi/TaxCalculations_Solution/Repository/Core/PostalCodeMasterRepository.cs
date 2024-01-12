// *******************************************************************************
// Filename       : PostalCodeMasterRepository.cs
// Type           : Class
// Function       : Postal Code Master - Repository Core
// *******************************************************************************

using DomainModels.DataModels;
using Repository.Contract;
using Dapper;
using System.Data.SqlClient;
using Microsoft.Extensions.Logging;

namespace Repository.Core
{
    public class PostalCodeMasterRepository : IPostalCodeMasterRepository
    {
        private readonly string _connectionString;
        private readonly ILogger<PostalCodeMasterRepository> _logger;
        public PostalCodeMasterRepository(string connectionString, ILogger<PostalCodeMasterRepository> logger)
        {
            _connectionString = connectionString;
            _logger = logger;
        }

        public async Task<PostalCodeMasterRecord> GetPostalCodeMasterByPostalCodeAsync(PostalCodeMasterRecord dto)
        {
            PostalCodeMasterRecord PostalCodeMasterDto = new PostalCodeMasterRecord();

            try
            {
                using (var connection = new SqlConnection(_connectionString))
                {
                    await connection.OpenAsync();

                    var SQL_Query = "SELECT [PostalCode], [TaxCalculationTypeID] FROM [GTXCalculations].[dbo].[PostalCodeMaster] WHERE [PostalCode] = @PostalCode";

                    PostalCodeMasterDto = (await connection.QueryAsync<PostalCodeMasterRecord>(SQL_Query, new { dto.PostalCode })).FirstOrDefault();
                }
            }
            catch (Exception ex)
            {
                _logger.LogError(ex, "Error occurred in - PostalCodeMasterRepository.");
                throw;
            }

            return PostalCodeMasterDto;
        }
    }
}
