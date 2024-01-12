// *******************************************************************************
// Filename       : CalculatedTaxHistoryRecord.cs
// Type           : Class
// Function       : Calculated Tax History Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class CalculatedTaxHistoryRecord
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("AnnualIncome")]
        public decimal AnnualIncome { get; set; }

        [JsonProperty("CalculatedTax")]
        public decimal CalculatedTax { get; set; }

        [JsonProperty("CalculatedDateTime")]
        public DateTime CalculatedDateTime { get; set; }
    }
}