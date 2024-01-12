﻿// *******************************************************************************
// Filename       : TaxCalculation_List_ResponseRecord.cs
// Type           : Class
// Function       : Tax Calculation API Request Response List Data Transfer Object
// *******************************************************************************

using Newtonsoft.Json;

namespace Api.DataModels
{
    public class TaxCalculation_List_ResponseRecord
    {
        [JsonProperty("ResponseCode")]
        public int ResponseCode { get; set; }

        [JsonProperty("ResponseDescription")]
        public string ResponseDescription { get; set; }

        [JsonProperty("ResponseData")]
        public List<TaxCalculationRecord> ResponseData { get; set; }
    }
}