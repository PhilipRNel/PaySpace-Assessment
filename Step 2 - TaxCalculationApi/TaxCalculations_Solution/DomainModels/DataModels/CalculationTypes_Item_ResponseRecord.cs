// *******************************************************************************
// Filename       : CalculationTypes_Item_ResponseRecord.cs
// Type           : Class
// Function       : Calculation Types API Request Response Item Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class CalculationTypes_Item_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public CalculationTypesRecord ResponseData { get; set; }
    }
}