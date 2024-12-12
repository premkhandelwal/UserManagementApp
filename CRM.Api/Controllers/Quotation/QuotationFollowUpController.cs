using CRM.Tenant.Service.Models.Requests.Quotation;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp;
using CRM.Tenant.Service.Services.QuotationService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers.Quotation
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class QuotationFollowUpController : ControllerBase
    {
        private QuotationFollowUpService quotationFollowUpService;

        public QuotationFollowUpController(QuotationFollowUpService quotationFollowUpService)
        {
            this.quotationFollowUpService = quotationFollowUpService;
        }

        [HttpPost("AddQuotationFollowUp")]
        public async Task<IActionResult> AddQuotationFollowUp([FromBody] CreateQuotationFollowUpRequest quotationRequest)
        {
            var result = await quotationFollowUpService.CreateAsync(quotationRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQuotationFollowUps")]
        public async Task<IActionResult> GetQuotationFollowUps(int quotationId)
        {
            var result = await quotationFollowUpService.GetByIdAsync(quotationId);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetAllFollowUps")]
        public async Task<IActionResult> GetAllFollowUps()
        {
            var result = await quotationFollowUpService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetFollowUpsForDate")]
        public async Task<IActionResult> GetFollowUpsForDate(DateTime date,string userId)
        {
            var result = await quotationFollowUpService.GetFollowUpsForDate(date, userId);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
