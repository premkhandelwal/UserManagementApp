using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Api.Models.Masters;
using CRM.Admin.Data;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Service.Models;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveredToController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public DeliveredToController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateDeliveredTo")]
        public async Task<IActionResult> CreateDeliveredTo([FromBody] DeliveredToModel deliveredto)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Delivered To!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            deliveredto.AddedOn = DateTime.Now;
            deliveredto.IsDeleted = false;
            await _context.DeliveredTo!.AddAsync(deliveredto);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Delivered To created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadDeliveredTo")]
        public IActionResult ReadDeliveredTos()
        {
            List<DeliveredToModel> result = _context.DeliveredTo!.Where(deliveredto => deliveredto.IsDeleted == false)
                                                                 .Include(dt => dt.TransportMode)
                                                                 .ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateDeliveredTo")]
        public async Task<IActionResult> UpdateDeliveredTo([FromBody] DeliveredToModel deliveredto)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Delivered To!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingDeliveredTo = await _context.DeliveredTo!.FindAsync(deliveredto.Id);
            if (existingDeliveredTo == null)
            {
                response.IsSuccess = false;
                response.Response = "Delivered To not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            existingDeliveredTo.DeliveryName = deliveredto.DeliveryName;
            existingDeliveredTo.TransportModeId = deliveredto.TransportModeId;

            _context.Update(existingDeliveredTo);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Delivered To updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteDeliveredTo")]
        public async Task<IActionResult> DeleteDeliveredTo([FromBody] DeliveredToModel deliveredto)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Delivered To!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingDeliveredTo = await _context.DeliveredTo!.FindAsync(deliveredto.Id);
            if (existingDeliveredTo == null)
            {
                response.IsSuccess = false;
                response.Response = "Delivered To not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            // Check for references
            bool hasReferences = await _context.QuotationTerms!.AnyAsync(e => e.DelieveryNameId == existingDeliveredTo.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Delivered To as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingDeliveredTo.IsDeleted = true;
            _context.Update(existingDeliveredTo);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Delivered To deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
