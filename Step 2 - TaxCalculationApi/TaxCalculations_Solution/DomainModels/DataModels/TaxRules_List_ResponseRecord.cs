// *******************************************************************************
// Filename       : TaxRules_List_ResponseRecord.cs
// Type           : Class
// Function       : Tax Rules Types API Request Response List Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxRules_List_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public List<TaxRulesRecord> ResponseData { get; set; }
    }
}