using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.Metrics;
using UserManagementApp.Models.Masters;
using UserManagementApp.Models.UserManagementRequests;
using UserManagementData;
using UserManagementService.Models;

namespace UserManagementApp.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {

        private ClientApplicationDbContext _context;
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
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            paymenttype.Id = Guid.NewGuid().ToString();
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
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            paymenttype.IsDeleted = false;
            _context.Update(paymenttype);
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
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            paymenttype.IsDeleted = true;
            _context.Update(paymenttype);
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