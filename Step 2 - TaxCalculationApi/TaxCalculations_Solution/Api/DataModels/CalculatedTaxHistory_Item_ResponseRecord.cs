// *******************************************************************************
// Filename       : CalculatedTaxHistory_Item_ResponseRecord.cs
// Type           : Class
// Function       : Calculated Tax History API Request Response Item Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class CalculatedTaxHistory_Item_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public CalculatedTaxHistoryRecord ResponseData { get; set; }
    }
}