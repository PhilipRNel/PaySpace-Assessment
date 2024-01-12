// *******************************************************************************
// Filename       : ICalculatedTaxService.cs
// Type           : Class
// Function       : Calculated Tax - Services Contract
// *******************************************************************************

using DomainModels.DataModels;

namespace Services.Contract
{
    public interface ICalculatedTaxService
    {
        Task<TaxCalculation_Item_ResponseRecord> GetCalculatedTaxValueAsync(TaxCalculationRecord dto);
    }
}