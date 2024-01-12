// *******************************************************************************
// Filename       : CalculatedTaxHistory_List_ResponseRecord.cs
// Type           : Class
// Function       : Calculated Tax History API Request Response List Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class CalculatedTaxHistory_List_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public List<CalculatedTaxHistoryRecord> ResponseData { get; set; }
    }
}