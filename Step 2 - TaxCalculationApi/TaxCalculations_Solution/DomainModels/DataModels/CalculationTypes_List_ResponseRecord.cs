// *******************************************************************************
// Filename       : CalculationTypes_List_ResponseRecord.cs
// Type           : Class
// Function       : Calculation Types API Request Response List Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class CalculationTypes_List_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public List<CalculationTypesRecord> ResponseData { get; set; }
    }
}