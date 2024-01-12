// *******************************************************************************
// Filename       : TaxCalculationTypesRecord.cs
// Type           : Class
// Function       : Tax Calculation Types Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class TaxCalculationTypesRecord
    {
        [JsonProperty("ID")]
        public int ID { get; set; }

        [JsonProperty("Description")]
        public string Description { get; set; }
    }
}