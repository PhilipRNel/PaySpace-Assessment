// *******************************************************************************
// Filename       : PostalCodeMaster_Item_ResponseRecord.cs
// Type           : Class
// Function       : Postal Code Master API Request Response Item Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class PostalCodeMaster_Item_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public PostalCodeMasterRecord ResponseData { get; set; }
    }
}