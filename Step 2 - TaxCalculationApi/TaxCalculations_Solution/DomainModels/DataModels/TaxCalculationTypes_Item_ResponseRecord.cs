// *******************************************************************************
// Filename       : TaxCalculationTypes_Item_ResponseRecord.cs
// Type           : Class
// Function       : Tax Calculation Types API Request Response Item Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxCalculationTypes_Item_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public TaxCalculationTypesRecord ResponseData { get; set; }
    }
}