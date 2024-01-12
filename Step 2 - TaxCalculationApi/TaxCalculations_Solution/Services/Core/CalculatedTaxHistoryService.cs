// *******************************************************************************
// Filename       : CalculatedTaxHistoryService.cs
// Type           : Class
// Function       : Calculated Tax History - Services Core
// *******************************************************************************

using DomainModels.DataModels;
using Microsoft.Extensions.Logging;
using Repository.Contract;
using Services.Contract;

namespace Services.Core
{
    public class CalculatedTaxHistoryService : ICalculatedTaxHistoryService
    {
        private readonly ICalculatedTaxHistoryRepository _calculatedTaxHistoryRepository;
        private readonly ILogger<CalculatedTaxHistoryService> _logger;

        public CalculatedTaxHistoryService(ICalculatedTaxHistoryRepository calculatedTaxHistoryRepository, ILogger<CalculatedTaxHistoryService> logger)
        {
            _calculatedTaxHistoryRepository = calculatedTaxHistoryRepository;
            _logger = logger;
        }

        public async Task<CalculatedTaxHistory_List_ResponseRecord> GetCalculatedTaxHistoryByPostalCodeAsync(CalculatedTaxHistoryRecord dto)
        {
            CalculatedTaxHistory_List_ResponseRecord CalculatedTaxHistory_List_ResponseDto = new CalculatedTaxHistory_List_ResponseRecord();

            try
            {
                // ----- Validate API - Request payload parameters ----- //
                if (string.IsNullOrEmpty(dto.PostalCode))
                {
                    CalculatedTaxHistory_List_ResponseDto.ResponseCode = 400;
                    CalculatedTaxHistory_List_ResponseDto.ResponseDescription = "No\\Invalid Postal Code Supplied. Please ensure you supply a valid postal code.";

                    return CalculatedTaxHistory_List_ResponseDto;
                }

                // ----- Lookup - Calculated Tax History By Postal Code ----- //
                List<CalculatedTaxHistoryRecord> List_CalculatedTaxHistoryDto = await _calculatedTaxHistoryRepository.GetCalculatedTaxHistoryByPostalCodeAsync(dto);

                if (List_CalculatedTaxHistoryDto.Count <= 0)
                {
                    CalculatedTaxHistory_List_ResponseDto.ResponseCode = 204;
                    CalculatedTaxHistory_List_ResponseDto.ResponseDescription = "No Calculated Tax History Available For Postal Code: " + dto.PostalCode;

                    return CalculatedTaxHistory_List_ResponseDto;
                }
                else
                {
                    CalculatedTaxHistory_List_ResponseDto.ResponseCode = 200;
                    CalculatedTaxHistory_List_ResponseDto.ResponseDescription = "Successfully Received - Calculated Tax History.";
                    CalculatedTaxHistory_List_ResponseDto.ResponseData = List_CalculatedTaxHistoryDto;
                }
            }
            catch (Exception ex)
            {
                // ----- Catch Error - Log Error Event For Function ----- //
                _logger.LogError(ex, "Error occurred in - CalculatedTaxHistoryService - GetCalculatedTaxHistoryByPostalCodeAsync.");

                CalculatedTaxHistory_List_ResponseDto.ResponseCode = 500;
                CalculatedTaxHistory_List_ResponseDto.ResponseDescription = "Error occurred in - CalculatedTaxHistoryService - GetCalculatedTaxHistoryByPostalCodeAsync: " + ex.Message;

                return CalculatedTaxHistory_List_ResponseDto;
            }

            return CalculatedTaxHistory_List_ResponseDto;
        }

        public async Task<CalculatedTaxHistory_Item_ResponseRecord> InsertCalculatedTaxHistoryAsync(CalculatedTaxHistoryRecord dto)
        {
            CalculatedTaxHistory_Item_ResponseRecord CalculatedTaxHistory_Item_ResponseDto = new CalculatedTaxHistory_Item_ResponseRecord();

            try
            {
                // ----- Validate API - Request payload parameters ----- //
                if (string.IsNullOrEmpty(dto.PostalCode))
                {
                    CalculatedTaxHistory_Item_ResponseDto.ResponseCode = 400;
                    CalculatedTaxHistory_Item_ResponseDto.ResponseDescription = "No\\Invalid Postal Code Supplied. Please ensure you supply a valid postal code.";

                    return CalculatedTaxHistory_Item_ResponseDto;
                }

                if (dto.AnnualIncome < 0)
                {
                    CalculatedTaxHistory_Item_ResponseDto.ResponseCode = 400;
                    CalculatedTaxHistory_Item_ResponseDto.ResponseDescription = "No\\Invalid Annual Income Supplied. Please ensure you supply a valid annual income.";

                    return CalculatedTaxHistory_Item_ResponseDto;
                }

                if (dto.CalculatedTax < 0)
                {
                    CalculatedTaxHistory_Item_ResponseDto.ResponseCode = 400;
                    CalculatedTaxHistory_Item_ResponseDto.ResponseDescription = "No\\Invalid Calculated Tax Supplied. Please ensure you supply a valid calculated tax.";

                    return CalculatedTaxHistory_Item_ResponseDto;
                }

                if (!(dto.CalculatedDateTime > DateTime.MinValue && dto.CalculatedDateTime < DateTime.MaxValue))
                {
                    CalculatedTaxHistory_Item_ResponseDto.ResponseCode = 400;
                    CalculatedTaxHistory_Item_ResponseDto.ResponseDescription = "No\\Invalid Calculated DateTime Supplied. Please ensure you supply a valid calculated dateTime.";

                    return CalculatedTaxHistory_Item_ResponseDto;
                }

                // ----- Insert - Calculated Tax History ----- //
                CalculatedTaxHistoryRecord CalculatedTaxHistoryDto = await _calculatedTaxHistoryRepository.InsertCalculatedTaxHistoryAsync(dto);

                if (CalculatedTaxHistoryDto == null)
                {
                    CalculatedTaxHistory_Item_ResponseDto.ResponseCode = 500;
                    CalculatedTaxHistory_Item_ResponseDto.ResponseDescription = "Failed To Save - Calculated Tax History.";

                    return CalculatedTaxHistory_Item_ResponseDto;
                }
                else
                {
                    CalculatedTaxHistory_Item_ResponseDto.ResponseCode = 200;
                    CalculatedTaxHistory_Item_ResponseDto.ResponseDescription = "Successfully Saved - Calculated Tax History.";
                    CalculatedTaxHistory_Item_ResponseDto.ResponseData = CalculatedTaxHistoryDto;
                }
            }
            catch (Exception ex)
            {
                // ----- Catch Error - Log Error Event For Function ----- //
                _logger.LogError(ex, "Error occurred in - CalculatedTaxHistoryService - InsertCalculatedTaxHistoryAsync.");

                CalculatedTaxHistory_Item_ResponseDto.ResponseCode = 500;
                CalculatedTaxHistory_Item_ResponseDto.ResponseDescription = "Error occurred in - CalculatedTaxHistoryService - InsertCalculatedTaxHistoryAsync: " + ex.Message;

                return CalculatedTaxHistory_Item_ResponseDto;
            }

            return CalculatedTaxHistory_Item_ResponseDto;
        }
    }
}