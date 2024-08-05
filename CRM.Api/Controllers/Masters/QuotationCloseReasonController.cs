using Microsoft.AspNetCore.Mvc;
using CRM.Api.Models.Masters;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationCloseReasonController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public QuotationCloseReasonController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateQuotationCloseReason")]
        public async Task<IActionResult> CreateQuotationCloseReason([FromBody] QuotationCloseReasonModel quotationCloseReason)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Quotation Close Reason!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            quotationCloseReason.AddedOn = DateTime.Now;
            quotationCloseReason.IsDeleted = false;
            await _context.QuotationCloseReasons!.AddAsync(quotationCloseReason);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Quotation Close Reason created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadQuotationCloseReasons")]
        public IActionResult ReadQuotationCloseReasons()
        {
            List<QuotationCloseReasonModel> result = _context.QuotationCloseReasons!.Where(q => q.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateQuotationCloseReason")]
        public async Task<IActionResult> UpdateQuotationCloseReason([FromBody] QuotationCloseReasonModel quotationCloseReason)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Quotation Close Reason!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingReason = await _context.QuotationCloseReasons!.FindAsync(quotationCloseReason.Id);
            if (existingReason == null)
            {
                response.Response = "Quotation Close Reason not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingReason.QuotationCloseReason = quotationCloseReason.QuotationCloseReason;
            existingReason.IsDeleted = quotationCloseReason.IsDeleted;

            _context.Update(existingReason);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Quotation Close Reason updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteQuotationCloseReason")]
        public async Task<IActionResult> DeleteQuotationCloseReason([FromBody] QuotationCloseReasonModel quotationCloseReason)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Quotation Close Reason!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingReason = await _context.QuotationCloseReasons!.FindAsync(quotationCloseReason.Id);
            if (existingReason == null)
            {
                response.Response = "Quotation Close Reason not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingReason.IsDeleted = true;
            _context.Update(existingReason);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Quotation Close Reason deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
