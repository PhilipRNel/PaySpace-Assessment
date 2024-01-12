// *******************************************************************************
// Filename       : TaxCalculatorController.vb
// Type           : Controller
// Function       : Tax Calculator - Web Service Controller
// *******************************************************************************

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Contract;
using Api.DataModels;

namespace Api.Controllers
{
    [Route("api/TaxCalculatorController")]
    [ApiController]
    public class TaxCalculatorController : ControllerBase
    {
        private readonly ICalculatedTaxService _calculatedTaxService;
        private readonly IMapper _mapper;

        public TaxCalculatorController(ICalculatedTaxService calculatedTaxService, IMapper mapper)
        {
            _calculatedTaxService = calculatedTaxService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("CalculateTaxValue")]
        public async Task<IActionResult> CalculateTaxValueAsync(TaxCalculationRecord RecordData)
        {   
            // ----- Data Mapping - Mapping From Api.DataModels To DomainModels.DataModels ----- //
            var TaxCalculationDto = _mapper.Map<DomainModels.DataModels.TaxCalculationRecord>(RecordData);

            // ----- Business Logic Layer - Calculate The Tax Value ----- //
            var result = await _calculatedTaxService.GetCalculatedTaxValueAsync(TaxCalculationDto);

            // ----- Data Mapping - Mapping From DomainModels.DataModels To Api.DataModels ----- //
            var TaxCalculation_Item_ResponseDto = _mapper.Map<TaxCalculation_Item_ResponseRecord>(result);

            // ----- Return Payload - Build Response Payload ----- //
            return StatusCode(TaxCalculation_Item_ResponseDto.ResponseCode, TaxCalculation_Item_ResponseDto);
        }
    }
}