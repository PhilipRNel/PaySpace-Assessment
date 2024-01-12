// *******************************************************************************
// Filename       : TaxCalculation_Item_ResponseRecord.cs
// Type           : Class
// Function       : Tax Calculation API Request Response Item Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxCalculation_Item_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public TaxCalculationRecord ResponseData { get; set; }
    }
}