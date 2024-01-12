// *******************************************************************************
// Filename       : CalculationTypes_Item_ResponseRecord.cs
// Type           : Class
// Function       : Calculation Types API Request Response Item Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class CalculationTypes_Item_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public CalculationTypesRecord ResponseData { get; set; }
    }
}