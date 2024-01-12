// *******************************************************************************
// Filename       : TaxRulesRecord.cs
// Type           : Class
// Function       : Tax Rules Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class TaxRulesRecord
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("TaxCalculationTypeID")]
        public int TaxCalculationTypeID { get; set; }

        [JsonProperty("FromAmount")]
        public decimal FromAmount { get; set; }

        [JsonProperty("ToAmount")]
        public decimal ToAmount { get; set; }

        [JsonProperty("CalculationTypeID")]
        public int CalculationTypeID { get; set; }

        [JsonProperty("CalculationValue")]
        public decimal CalculationValue { get; set; }
    }
}