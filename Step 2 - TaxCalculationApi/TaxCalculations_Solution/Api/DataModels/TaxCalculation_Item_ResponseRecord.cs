// *******************************************************************************
// Filename       : TaxCalculation_Item_ResponseRecord.cs
// Type           : Class
// Function       : Tax Calculation API Request Response Item Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class TaxCalculation_Item_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public TaxCalculationRecord ResponseData { get; set; }
    }
}