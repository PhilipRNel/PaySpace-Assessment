// *******************************************************************************
// Filename       : ITaxCalculationTypesRepository.cs
// Type           : Class
// Function       : Tax Calculation Types - Repository Contract
// *******************************************************************************

using DomainModels.DataModels;

namespace Repository.Contract
{
    public interface ITaxCalculationTypesRepository
    {
        Task<TaxCalculationTypesRecord> GetTaxCalculationTypesByIDAsync(TaxCalculationTypesRecord dto);
    }
}
