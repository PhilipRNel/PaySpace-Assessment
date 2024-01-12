// *******************************************************************************
// Filename       : CalculatedTaxHistory_Item_ResponseRecord.cs
// Type           : Class
// Function       : Calculated Tax History API Request Response Item Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class CalculatedTaxHistory_Item_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public CalculatedTaxHistoryRecord ResponseData { get; set; }
    }
}