// *******************************************************************************
// Filename       : ITaxRulesRepository.cs
// Type           : Class
// Function       : Tax Calculation - Repository Contract
// *******************************************************************************

using DomainModels.DataModels;

namespace Repository.Contract
{
    public interface ITaxRulesRepository
    {
        Task<List<TaxRulesRecord>> GetTaxRulesByTaxCalculationTypeAsync(TaxRulesRecord dto);
    }
}
