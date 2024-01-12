// *******************************************************************************
// Filename       : CalculationTypes_List_ResponseRecord.cs
// Type           : Class
// Function       : Calculation Types API Request Response List Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class CalculationTypes_List_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public List<CalculationTypesRecord> ResponseData { get; set; }
    }
}