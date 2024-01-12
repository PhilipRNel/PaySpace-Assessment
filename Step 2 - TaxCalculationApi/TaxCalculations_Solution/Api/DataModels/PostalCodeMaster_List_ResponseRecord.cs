// *******************************************************************************
// Filename       : PostalCodeMaster_List_ResponseRecord.cs
// Type           : Class
// Function       : Postal Code Master API Request Response List Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class PostalCodeMaster_List_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public List<PostalCodeMasterRecord> ResponseData { get; set; }
    }
}