// *******************************************************************************
// Filename       : IPostalCodeMasterRepository.cs
// Type           : Class
// Function       : Postal Code Master - Repository Contract
// *******************************************************************************

using DomainModels.DataModels;

namespace Repository.Contract
{
    public interface IPostalCodeMasterRepository
    {
        Task<PostalCodeMasterRecord> GetPostalCodeMasterByPostalCodeAsync(PostalCodeMasterRecord dto);
    }
}
