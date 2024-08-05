using Microsoft.AspNetCore.Mvc;
using CRM.Api.Models.Masters;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public PaymentTypeController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreatePaymentType")]
        public async Task<IActionResult> CreatePaymentType([FromBody] PaymentTypeModel paymenttype)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Payment Type!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            paymenttype.AddedOn = DateTime.Now;
            paymenttype.IsDeleted = false;
            await _context.PaymentTypes!.AddAsync(paymenttype);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Payment Type created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadPaymentTypes")]
        public IActionResult ReadPaymentTypes()
        {
            List<PaymentTypeModel> result = _context.PaymentTypes!.Where(paymenttype => paymenttype.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdatePaymentType")]
        public async Task<IActionResult> UpdatePaymentType([FromBody] PaymentTypeModel paymenttype)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Payment Type!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingPaymentType = await _context.PaymentTypes!.FindAsync(paymenttype.Id);
            if (existingPaymentType == null)
            {
                response.Response = "Payment Type not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingPaymentType.PaymentType = paymenttype.PaymentType;

            _context.Update(existingPaymentType);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Payment Type updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeletePaymentType")]
        public async Task<IActionResult> DeletePaymentType([FromBody] PaymentTypeModel paymenttype)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Payment Type!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingPaymentType = await _context.PaymentTypes!.FindAsync(paymenttype.Id);
            if (existingPaymentType == null)
            {
                response.Response = "Payment Type not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            // Check for references
            bool hasReferences = await _context.QuotationTerms!.AnyAsync(e => e.PaymentId == existingPaymentType.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Payment Type as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingPaymentType.IsDeleted = true;
            _context.Update(existingPaymentType);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Payment Type deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
