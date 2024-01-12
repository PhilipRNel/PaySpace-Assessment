// *******************************************************************************
// Filename       : ICalculationTypesRepository.cs
// Type           : Class
// Function       : Calculation Types - Repository Contract
// *******************************************************************************

using DomainModels.DataModels;

namespace Repository.Contract
{
    public interface ICalculationTypesRepository
    {
        Task<CalculationTypesRecord> GetCalculationTypesByIDAsync(CalculationTypesRecord dto);
    }
}
