using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Api.Models.Masters;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportModeController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public TransportModeController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateTransportMode")]
        public async Task<IActionResult> CreateTransportMode([FromBody] TransportModeModel transportMode)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Transport Mode!",
                StatusCode = 501
            };

            if (!ModelState.IsValid)
            {
                response.Response = "Bad request!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            transportMode.AddedOn = DateTime.Now;
            transportMode.IsDeleted = false;
            await _context.TransportModes!.AddAsync(transportMode);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Transport Mode created successfully!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadTransportModes")]
        public IActionResult ReadTransportModes()
        {
            var result = _context.TransportModes!.Where(tm => !tm.IsDeleted).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateTransportMode")]
        public async Task<IActionResult> UpdateTransportMode([FromBody] TransportModeModel transportMode)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Transport Mode!",
                StatusCode = 501
            };

            if (!ModelState.IsValid)
            {
                response.Response = "Bad request!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMode = await _context.TransportModes!.FindAsync(transportMode.Id);
            if (existingMode == null)
            {
                response.Response = "Transport Mode not found!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingMode.TransportMode = transportMode.TransportMode;
            existingMode.IsDeleted = transportMode.IsDeleted;

            _context.Update(existingMode);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Transport Mode updated successfully!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteTransportMode")]
        public async Task<IActionResult> DeleteTransportMode([FromBody] TransportModeModel transportMode)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Transport Mode!",
                StatusCode = 501
            };

            if (!ModelState.IsValid)
            {
                response.Response = "Bad request!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMode = await _context.TransportModes!.FindAsync(transportMode.Id);
            if (existingMode == null)
            {
                response.Response = "Transport Mode not found!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            bool hasDeliveredToReferences = await _context.DeliveredTo!.AnyAsync(e => e.TransportModeId == existingMode.Id);
            bool hasQuotationReferences = await _context.QuotationTerms!.AnyAsync(e => e.PackingTypeId == existingMode.Id);

            if (hasDeliveredToReferences || hasQuotationReferences)
            {
                response.Response = "Cannot delete Transport Mode as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingMode.IsDeleted = true;
            _context.Update(existingMode);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Transport Mode deleted successfully!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
