// *******************************************************************************
// Filename       : CalculatedTaxService.cs
// Type           : Class
// Function       : Calculated Tax - Services Core
// *******************************************************************************

using DomainModels.DataModels;
using Microsoft.Extensions.Logging;
using Repository.Contract;
using Services.Contract;

namespace Services.Core
{
    public class CalculatedTaxService : ICalculatedTaxService
    {
        private readonly IPostalCodeMasterRepository _postalCodeMasterRepository;
        private readonly ITaxRulesRepository _taxRulesRepository;
        private readonly ILogger<CalculatedTaxService> _logger;

        public CalculatedTaxService(IPostalCodeMasterRepository postalCodeMasterRepository, ITaxRulesRepository taxRulesRepository, ILogger<CalculatedTaxService> logger)
        {
            _postalCodeMasterRepository = postalCodeMasterRepository;
            _taxRulesRepository = taxRulesRepository;
            _logger = logger;
        }

        public async Task<TaxCalculation_Item_ResponseRecord> GetCalculatedTaxValueAsync(TaxCalculationRecord dto)
        {
            TaxCalculation_Item_ResponseRecord TaxCalculation_Item_ResponseDto= new TaxCalculation_Item_ResponseRecord();

            // ----- Validate API - Request payload parameters ----- //
            if (string.IsNullOrEmpty(dto.PostalCode))
            {
                TaxCalculation_Item_ResponseDto.ResponseCode = 400;
                TaxCalculation_Item_ResponseDto.ResponseDescription = "No\\Invalid Postal Code Supplied. Please ensure you supply a valid postal code.";

                return TaxCalculation_Item_ResponseDto;
            }

            if (dto.AnnualIncome < 0)
            {
                TaxCalculation_Item_ResponseDto.ResponseCode = 400;
                TaxCalculation_Item_ResponseDto.ResponseDescription = "No\\Invalid Annual Income Supplied. Please ensure you supply a valid annual income.";

                return TaxCalculation_Item_ResponseDto;
            }

            // ----- Lookup - Get Tax Calculation Type From Postal Code Master ----- //
            PostalCodeMasterRecord PostalCodeMaster_ResponseDto = new PostalCodeMasterRecord();

            try
            {
                PostalCodeMasterRecord PostalCodeMasterDto = new PostalCodeMasterRecord();
                PostalCodeMasterDto.PostalCode = dto.PostalCode;

                PostalCodeMaster_ResponseDto = await _postalCodeMasterRepository.GetPostalCodeMasterByPostalCodeAsync(PostalCodeMasterDto);

                if (PostalCodeMaster_ResponseDto == null)
                {
                    TaxCalculation_Item_ResponseDto.ResponseCode = 400;
                    TaxCalculation_Item_ResponseDto.ResponseDescription = "No\\Invalid Postal Code Supplied. Please ensure you supply a valid postal code.";

                    return TaxCalculation_Item_ResponseDto;
                }
            }
            catch (Exception ex)
            {
                // ----- Catch Error - Log Error Event For Function ----- //
                _logger.LogError(ex, "Error occurred in - CalculatedTaxService - GetCalculatedTaxValueAsync - GetPostalCodeMasterByPostalCodeAsync.");

                TaxCalculation_Item_ResponseDto.ResponseCode = 500;
                TaxCalculation_Item_ResponseDto.ResponseDescription = "Error occurred in - CalculatedTaxService - GetCalculatedTaxValueAsync - GetPostalCodeMasterByPostalCodeAsync: " + ex.Message;

                return TaxCalculation_Item_ResponseDto;
            }

            // ----- Lookup - Get Tax Rules From Tax Calculation Type ----- //
            List<TaxRulesRecord> List_TaxRulesDto = new List<TaxRulesRecord>();

            try
            {
                TaxRulesRecord TaxRulesDto = new TaxRulesRecord();
                TaxRulesDto.TaxCalculationTypeID = PostalCodeMaster_ResponseDto.TaxCalculationTypeID;

                List_TaxRulesDto = await _taxRulesRepository.GetTaxRulesByTaxCalculationTypeAsync(TaxRulesDto);

                if (List_TaxRulesDto.Count <= 0)
                {
                    TaxCalculation_Item_ResponseDto.ResponseCode = 204;
                    TaxCalculation_Item_ResponseDto.ResponseDescription = "Please note that currently no tax rules were setup for the postal code supplied.";

                    return TaxCalculation_Item_ResponseDto;
                }
            }
            catch (Exception ex)
            {
                // ----- Catch Error - Log Error Event For Function ----- //
                _logger.LogError(ex, "Error occurred in - CalculatedTaxService - GetCalculatedTaxValueAsync - GetTaxRulesByTaxCalculationTypeAsync.");

                TaxCalculation_Item_ResponseDto.ResponseCode = 500;
                TaxCalculation_Item_ResponseDto.ResponseDescription = "Error occurred in - CalculatedTaxService - GetCalculatedTaxValueAsync - GetTaxRulesByTaxCalculationTypeAsync: " + ex.Message;

                return TaxCalculation_Item_ResponseDto;
            }

            // ----- Calculation - Calculate Tax Value ----- //
            try
            {
                decimal CalculatedTaxValue = 0;

                foreach (TaxRulesRecord TaxRulesRecord in List_TaxRulesDto)
                {
                    switch (TaxRulesRecord.TaxCalculationTypeID)
                    {
                        // ----- Tax Calculation Type - Flat Value ----- //
                        case 1:

                            if (TaxRulesRecord.ToAmount == 0) { TaxRulesRecord.ToAmount = dto.AnnualIncome; }

                            if (dto.AnnualIncome >= TaxRulesRecord.FromAmount && dto.AnnualIncome <= TaxRulesRecord.ToAmount)
                            {
                                switch (TaxRulesRecord.CalculationTypeID)
                                {
                                    // ----- Calculation Type - Percentage ----- //
                                    case 1:

                                        CalculatedTaxValue += dto.AnnualIncome * (TaxRulesRecord.CalculationValue / 100);

                                        break;

                                    // ----- Calculation Type - Value ----- //
                                    case 2:

                                        CalculatedTaxValue = TaxRulesRecord.CalculationValue;

                                        break;
                                }
                            }

                            break;

                        // ----- Tax Calculation Type - Flat Rate ----- //
                        case 2:

                            if (TaxRulesRecord.ToAmount == 0) { TaxRulesRecord.ToAmount = dto.AnnualIncome; }

                            if (dto.AnnualIncome >= TaxRulesRecord.FromAmount && dto.AnnualIncome <= TaxRulesRecord.ToAmount)
                            {
                                switch (TaxRulesRecord.CalculationTypeID)
                                {
                                    // ----- Calculation Type - Percentage ----- //
                                    case 1:

                                        CalculatedTaxValue += dto.AnnualIncome * (TaxRulesRecord.CalculationValue / 100);

                                        break;

                                    // ----- Calculation Type - Value ----- //
                                    case 2:

                                        CalculatedTaxValue += TaxRulesRecord.CalculationValue;

                                        break;
                                }
                            }

                            break;

                        // ----- Tax Calculation Type - Progressive ----- //
                        case 3:

                            if (TaxRulesRecord.ToAmount == 0) { TaxRulesRecord.ToAmount = dto.AnnualIncome; }
                            if (TaxRulesRecord.ToAmount > dto.AnnualIncome) { TaxRulesRecord.ToAmount = dto.AnnualIncome; }

                            if (dto.AnnualIncome < TaxRulesRecord.FromAmount) { break; }

                            decimal calculationValue = TaxRulesRecord.ToAmount - TaxRulesRecord.FromAmount;

                            switch (TaxRulesRecord.CalculationTypeID)
                            {
                                // ----- Calculation Type - Percentage ----- //
                                case 1:

                                    CalculatedTaxValue += calculationValue * (TaxRulesRecord.CalculationValue / 100);

                                    break;

                                // ----- Calculation Type - Value ----- //
                                case 2:

                                    CalculatedTaxValue += TaxRulesRecord.CalculationValue;

                                    break;
                            }

                            break;
                    }
                }

                dto.CalculatedTaxValue = Math.Round(CalculatedTaxValue, 2);

                TaxCalculation_Item_ResponseDto.ResponseCode = 200;
                TaxCalculation_Item_ResponseDto.ResponseDescription = "Successfully Calculated - Calculated Tax Value.";
                TaxCalculation_Item_ResponseDto.ResponseData = dto;
            }
            catch (Exception ex)
            {
                // ----- Catch Error - Log Error Event For Function ----- //
                _logger.LogError(ex, "Error occurred in - CalculatedTaxService - GetCalculatedTaxValueAsync - CalculateTaxValue.");

                TaxCalculation_Item_ResponseDto.ResponseCode = 500;
                TaxCalculation_Item_ResponseDto.ResponseDescription = "Error occurred in - CalculatedTaxService - GetCalculatedTaxValueAsync - CalculateTaxValue: " + ex.Message;

                return TaxCalculation_Item_ResponseDto;
            }

            return TaxCalculation_Item_ResponseDto;
        }
    }
}
