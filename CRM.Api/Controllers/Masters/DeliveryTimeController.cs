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
    public class DeliveryTimeController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public DeliveryTimeController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateDeliveryTime")]
        public async Task<IActionResult> CreateDeliveryTime([FromBody] DeliveryTimeModel deliveryTime)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Delivery Time!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            deliveryTime.AddedOn = DateTime.Now;
            deliveryTime.IsDeleted = false;
            await _context.DeliveryTime!.AddAsync(deliveryTime);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Delivery Time created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadDeliveryTimes")]
        public IActionResult ReadDeliveryTimes()
        {
            List<DeliveryTimeModel> result = _context.DeliveryTime!
                .Where(deliveryTime => deliveryTime.IsDeleted == false)
                .ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateDeliveryTime")]
        public async Task<IActionResult> UpdateDeliveryTime([FromBody] DeliveryTimeModel deliveryTime)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Delivery Time!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingDeliveryTime = await _context.DeliveryTime!.FindAsync(deliveryTime.Id);
            if (existingDeliveryTime == null)
            {
                response.IsSuccess = false;
                response.Response = "Delivery Time not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            existingDeliveryTime.DeliveryTime = deliveryTime.DeliveryTime;

            _context.Update(existingDeliveryTime);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Delivery Time updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteDeliveryTime")]
        public async Task<IActionResult> DeleteDeliveryTime([FromBody] DeliveryTimeModel deliveryTime)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Delivery Time!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingDeliveryTime = await _context.DeliveryTime!.FindAsync(deliveryTime.Id);
            if (existingDeliveryTime == null)
            {
                response.IsSuccess = false;
                response.Response = "Delivery Time not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            // Check for references
            bool hasReferences = await _context.QuotationTerms!.AnyAsync(e => e.DeliveryTimeId == existingDeliveryTime.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Delivered Time as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingDeliveryTime.IsDeleted = true;
            _context.Update(existingDeliveryTime);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Delivery Time deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
