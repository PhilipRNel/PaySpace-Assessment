// *******************************************************************************
// Filename       : PostalCodeMasterRecord.cs
// Type           : Class
// Function       : Postal Code Master Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class PostalCodeMasterRecord
    {
        [JsonProperty("PostalCode")]
        public string PostalCode { get; set; }

        [JsonProperty("TaxCalculationTypeID")]
        public int TaxCalculationTypeID { get; set; }
    }
}