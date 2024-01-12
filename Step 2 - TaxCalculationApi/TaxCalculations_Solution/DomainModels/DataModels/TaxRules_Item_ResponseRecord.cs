// *******************************************************************************
// Filename       : TaxRules_Item_ResponseRecord.cs
// Type           : Class
// Function       : Tax Rules Types API Request Response Item Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxRules_Item_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public TaxRulesRecord ResponseData { get; set; }
    }
}