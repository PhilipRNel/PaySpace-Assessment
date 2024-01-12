// *******************************************************************************
// Filename       : TaxCalculationTypes_Item_ResponseRecord.cs
// Type           : Class
// Function       : Tax Calculation Types API Request Response Item Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class TaxCalculationTypes_Item_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public TaxCalculationTypesRecord ResponseData { get; set; }
    }
}