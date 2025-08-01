﻿using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Create;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Delete;
using CRM.Tenant.Service.Models.Requests.QuotationFollowUp.Update;
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
        public async Task<IActionResult> AddQuotationFollowUp([FromBody] CreateQuotationFollowUpRequest createQuotationFollowUpRequest)
        {
            var result = await quotationFollowUpService.CreateAsync(createQuotationFollowUpRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateQuotationFollowUp")]
        public async Task<IActionResult> UpdateQuotationFollowUp([FromBody] UpdateQuotationFollowUpRequest updateQuotationFollowUpRequest)
        {
            var result = await quotationFollowUpService.UpdateAsync(updateQuotationFollowUpRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteQuotationFollowUp")]
        public async Task<IActionResult> DeleteQuotationFollowUp([FromBody] DeleteQuotationFollowUpRequest deleteQuotationFollowUpRequest)
        {
            var result = await quotationFollowUpService.DeleteAsync(deleteQuotationFollowUpRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetQuotationFollowUps")]
        public async Task<IActionResult> GetQuotationFollowUps(int quotationId)
        {
            var result = await quotationFollowUpService.GetFollowUpsForIdAsync(quotationId);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetAllFollowUps")]
        public async Task<IActionResult> GetAllFollowUps()
        {
            var result = await quotationFollowUpService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetFollowUpsForDate")]
        public async Task<IActionResult> GetFollowUpsForDate(DateTime date,int userId)
        {
            var result = await quotationFollowUpService.GetFollowUpsForDate(date, userId);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
