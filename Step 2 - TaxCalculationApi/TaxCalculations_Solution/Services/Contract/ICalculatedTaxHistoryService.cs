// *******************************************************************************
// Filename       : ICalculatedTaxHistoryService.cs
// Type           : Class
// Function       : Calculated Tax History - Services Contract
// *******************************************************************************

using DomainModels.DataModels;

namespace Services.Contract
{
    public interface ICalculatedTaxHistoryService
    {
        Task<CalculatedTaxHistory_List_ResponseRecord> GetCalculatedTaxHistoryByPostalCodeAsync(CalculatedTaxHistoryRecord dto);
        Task<CalculatedTaxHistory_Item_ResponseRecord> InsertCalculatedTaxHistoryAsync(CalculatedTaxHistoryRecord dto);
    }
}