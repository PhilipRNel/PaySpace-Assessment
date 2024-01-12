// *******************************************************************************
// Filename       : PostalCodeMaster_List_ResponseRecord.cs
// Type           : Class
// Function       : Postal Code Master API Request Response List Data Transfer Object
// *******************************************************************************

namespace DomainModels.DataModels
{
    public class PostalCodeMaster_List_ResponseRecord
    {
        public int ResponseCode { get; set; }
        public string ResponseDescription { get; set; }
        public List<PostalCodeMasterRecord> ResponseData { get; set; }
    }
}