// *******************************************************************************
// Filename       : TaxCalculationRecord.cs
// Type           : Class
// Function       : Tax Calculation Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class TaxCalculationRecord
    {
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("AnnualIncome")]
        public decimal AnnualIncome { get; set; }

        [JsonProperty("CalculatedTaxValue")]
        public decimal CalculatedTaxValue { get; set; }
    }
}