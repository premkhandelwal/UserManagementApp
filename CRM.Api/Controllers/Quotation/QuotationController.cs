using Microsoft.AspNetCore.Mvc;
using CRM.Tenant.Service.Models.Requests.Quotation;
using CRM.Tenant.Service.Services.QuotationService;
using CRM.Tenant.Service.Models.Requests.Quotation.Update;
using CRM.Tenant.Service.Models.Requests.Quotation.Update.UpdateQuotationFields;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CRM.Tenant.Service.Models.Requests.Quotation.Delete;

namespace Crm.Api.Controllers.Quotation
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
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

        [HttpPut("UpdateQuotation")]
        public async Task<IActionResult> UpdateQuotation([FromBody] UpdateQuotationRequest quotationRequest)
        {
            var result = await _quotationService.Update(quotationRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("DeleteQuotation")]
        public async Task<IActionResult> DeleteQuotation([FromBody] DeleteQuotationRequest quotationRequest)
        {
            var result = await _quotationService.Delete(quotationRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQuotations")]
        public async Task<IActionResult> GetQuotations()
        {

            var isAdmin = User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "admnRole");
            int userId = -1;
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out userId);
            if (userId == -1)
            {
                return Unauthorized(new { Message = "User is not authorized." });
            }

            if (User.IsInRole("adminRole"))
            {
                // User is an Admin, return all quotations
                var quotations = await _quotationService.Get();
                return Ok(quotations);
            }
            else
            {
                var userQuotations = await _quotationService.GetQuotationsForUser(userId);
                return Ok(userQuotations);
            }

        }

        [HttpGet("GetQuotationById")]
        public async Task<IActionResult> GetQuotationById(int id)
        {
            var result = await _quotationService.GetQuotationById(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

    }
}
