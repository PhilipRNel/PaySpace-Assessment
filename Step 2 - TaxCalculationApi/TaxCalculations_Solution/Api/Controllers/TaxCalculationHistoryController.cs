// *******************************************************************************
// Filename       : CalculatedTaxHistoryController.vb
// Type           : Controller
// Function       : Calculated Tax History - Web Service Controller
// *******************************************************************************

using Microsoft.AspNetCore.Mvc;
using AutoMapper;
using Services.Contract;
using Api.DataModels;

namespace Api.Controllers
{
    [Route("api/CalculatedTaxHistoryController")]
    [ApiController]
    public class CalculatedTaxHistoryController : ControllerBase
    {
        private readonly ICalculatedTaxHistoryService _calculatedTaxHistoryService;
        private readonly IMapper _mapper;

        public CalculatedTaxHistoryController(ICalculatedTaxHistoryService calculatedTaxHistoryService, IMapper mapper)
        {
            _calculatedTaxHistoryService = calculatedTaxHistoryService;
            _mapper = mapper;
        }

        [HttpPost]
        [Route("GetCalculatedTaxHistoryByPostalCodeAsync")]
        public async Task<IActionResult> GetCalculatedTaxHistoryByPostalCodeAsync(CalculatedTaxHistoryRecord RecordData)
        {   
            // ----- Data Mapping - Mapping From Api.DataModels To DomainModels.DataModels ----- //
            var CalculatedTaxHistoryDto = _mapper.Map<DomainModels.DataModels.CalculatedTaxHistoryRecord>(RecordData);

            // ----- Business Logic Layer - Tax Calculation History ----- //
            var result = await _calculatedTaxHistoryService.GetCalculatedTaxHistoryByPostalCodeAsync(CalculatedTaxHistoryDto);

            // ----- Data Mapping - Mapping From DomainModels.DataModels To Api.DataModels ----- //
            var CalculatedTaxHistory_List_ResponseDto = _mapper.Map<CalculatedTaxHistory_List_ResponseRecord>(result);

            // ----- Return Payload - Build Response Payload ----- //
            return StatusCode(CalculatedTaxHistory_List_ResponseDto.ResponseCode, CalculatedTaxHistory_List_ResponseDto);
        }

        [HttpPut]
        [Route("InsertCalculatedTaxHistoryAsync")]
        public async Task<IActionResult> InsertCalculatedTaxHistoryAsync(CalculatedTaxHistoryRecord RecordData)
        {
            // ----- Data Mapping - Mapping From Api.DataModels To DomainModels.DataModels ----- //
            var CalculatedTaxHistoryDto = _mapper.Map<DomainModels.DataModels.CalculatedTaxHistoryRecord>(RecordData);

            // ----- Business Logic Layer - Tax Calculation History ----- //
            var result = await _calculatedTaxHistoryService.InsertCalculatedTaxHistoryAsync(CalculatedTaxHistoryDto);

            // ----- Data Mapping - Mapping From DomainModels.DataModels To Api.DataModels ----- //
            var CalculatedTaxHistory_Item_ResponseDto = _mapper.Map<CalculatedTaxHistory_Item_ResponseRecord>(result);

            // ----- Return Payload - Build Response Payload ----- //
            return StatusCode(CalculatedTaxHistory_Item_ResponseDto.ResponseCode, CalculatedTaxHistory_Item_ResponseDto);
        }
    }
}