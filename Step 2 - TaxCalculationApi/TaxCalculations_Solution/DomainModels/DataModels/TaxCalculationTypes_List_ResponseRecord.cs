// *******************************************************************************
// Filename       : TaxCalculationTypes_List_ResponseRecord.cs
// Type           : Class
// Function       : Tax Calculation Types API Request Response List Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class TaxCalculationTypes_List_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public List<TaxCalculationTypesRecord> ResponseData { get; set; }
    }
}