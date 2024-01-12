// *******************************************************************************
// Filename       : ICalculatedTaxHistoryRepository.cs
// Type           : Class
// Function       : Calculated Tax History - Repository Contract
// *******************************************************************************

using DomainModels.DataModels;

namespace Repository.Contract
{
    public interface ICalculatedTaxHistoryRepository
    {
        Task<List<CalculatedTaxHistoryRecord>> GetCalculatedTaxHistoryByPostalCodeAsync(CalculatedTaxHistoryRecord dto);
        Task<CalculatedTaxHistoryRecord> InsertCalculatedTaxHistoryAsync(CalculatedTaxHistoryRecord dto);
    }
}
