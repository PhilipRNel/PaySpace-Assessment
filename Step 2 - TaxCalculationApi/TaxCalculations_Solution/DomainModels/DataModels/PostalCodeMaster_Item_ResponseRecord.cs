// *******************************************************************************
// Filename       : PostalCodeMaster_Item_ResponseRecord.cs
// Type           : Class
// Function       : Postal Code Master API Request Response Item Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class PostalCodeMaster_Item_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public PostalCodeMasterRecord ResponseData { get; set; }
    }
}