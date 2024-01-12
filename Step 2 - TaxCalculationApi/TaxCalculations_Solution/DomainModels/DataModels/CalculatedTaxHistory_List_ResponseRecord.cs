// *******************************************************************************
// Filename       : CalculatedTaxHistory_List_ResponseRecord.cs
// Type           : Class
// Function       : Calculated Tax History API Request Response List Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class CalculatedTaxHistory_List_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public List<CalculatedTaxHistoryRecord> ResponseData { get; set; }
    }
}