// *******************************************************************************
// Filename       : TaxCalculationRecord.cs
// Type           : Class
// Function       : Tax Calculation Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxCalculationRecord
    {
        public string PostalCode { get; set; }
        public decimal AnnualIncome { get; set; }
        public decimal CalculatedTaxValue { get; set; }
    }
}