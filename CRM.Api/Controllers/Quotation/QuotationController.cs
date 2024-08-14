using Microsoft.AspNetCore.Mvc;
using CRM.Tenant.Service.Models.Requests.Quotation;
using CRM.Tenant.Service.Services.QuotationService;

namespace Crm.Api.Controllers.Quotation
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        QuotationService _quotationService;
        public QuotationController(QuotationService quotationService)
        {
            _quotationService = quotationService;
        }

        [HttpPost("CreateQuotation")]
        public async Task<IActionResult> CreateQuotation([FromBody] CreateQuotationRequest quotationRequest)
        {
            var result = await _quotationService.Create(quotationRequest);
            return StatusCode(StatusCodes.Status200OK, result);    
        }

        [HttpGet("GetQuotations")]
        public async Task<IActionResult> GetQuotations()
        {
            var result = await _quotationService.Get();
            return StatusCode(StatusCodes.Status200OK, result);
        }

    }
}
