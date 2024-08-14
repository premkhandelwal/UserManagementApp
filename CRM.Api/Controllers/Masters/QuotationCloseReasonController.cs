using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.CreateQuotationCloseReason;
using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.DeleteQuotationCloseReason;
using CRM.Tenant.Service.Models.Requests.MasterRequests.QuotationCloseReason.UpdateQuotationCloseReason;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationCloseReasonController : ControllerBase
    {
        private QuotationCloseReasonService _quotationclosereasonService;
        public QuotationCloseReasonController(QuotationCloseReasonService quotationclosereasonService)
        {
            _quotationclosereasonService = quotationclosereasonService;
        }

        [HttpPost("CreateQuotationCloseReason")]
        public async Task<IActionResult> CreateQuotationCloseReason([FromBody] CreateQuotationCloseReasonRequest quotationclosereason)
        {
            var result = await _quotationclosereasonService.CreateAsync(quotationclosereason);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateQuotationCloseReason")]
        public async Task<IActionResult> UpdateQuotationCloseReason([FromBody] UpdateQuotationCloseReasonRequest quotationclosereason)
        {
            var result = await _quotationclosereasonService.UpdateAsync(quotationclosereason);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteQuotationCloseReason")]
        public async Task<IActionResult> DeleteQuotationCloseReason([FromBody] DeleteQuotationCloseReasonRequest quotationclosereason)
        {
            var result = await _quotationclosereasonService.DeleteAsync(quotationclosereason);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadQuotationCloseReasons")]
        public async Task<IActionResult> ReadQuotationCloseReasons()
        {
            var result = await _quotationclosereasonService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
