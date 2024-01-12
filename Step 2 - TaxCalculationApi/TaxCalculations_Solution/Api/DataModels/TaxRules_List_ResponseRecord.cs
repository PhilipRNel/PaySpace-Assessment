// *******************************************************************************
// Filename       : TaxRules_List_ResponseRecord.cs
// Type           : Class
// Function       : Tax Rules Types API Request Response List Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class TaxRules_List_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public List<TaxRulesRecord> ResponseData { get; set; }
    }
}