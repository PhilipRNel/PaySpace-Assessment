// *******************************************************************************
// Filename       : TaxCalculation_List_ResponseRecord.cs
// Type           : Class
// Function       : Tax Calculation API Request Response List Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxCalculation_List_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public List<TaxCalculationRecord> ResponseData { get; set; }
    }
}