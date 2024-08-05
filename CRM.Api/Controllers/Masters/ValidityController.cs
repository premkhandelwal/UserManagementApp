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
    public class ValidityController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public ValidityController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateValidity")]
        public async Task<IActionResult> CreateValidity([FromBody] ValidityModel validity)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Validity!",
                StatusCode = 501
            };

            if (!ModelState.IsValid)
            {
                response.Response = "Bad request!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            validity.AddedOn = DateTime.Now;
            validity.IsDeleted = false;

            await _context.Validities!.AddAsync(validity);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Validity created successfully!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadValidities")]
        public IActionResult ReadValidities()
        {
            var result = _context.Validities!.Where(v => !v.IsDeleted).ToList();

            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateValidity")]
        public async Task<IActionResult> UpdateValidity([FromBody] ValidityModel validity)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Validity!",
                StatusCode = 501
            };

            if (!ModelState.IsValid)
            {
                response.Response = "Bad request!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingValidity = await _context.Validities!.FindAsync(validity.Id);
            if (existingValidity == null)
            {
                response.Response = "Validity not found!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingValidity.Validity = validity.Validity;
            existingValidity.IsDeleted = validity.IsDeleted;

            _context.Update(existingValidity);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Validity updated successfully!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteValidity")]
        public async Task<IActionResult> DeleteValidity([FromBody] ValidityModel validity)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Validity!",
                StatusCode = 501
            };

            if (!ModelState.IsValid)
            {
                response.Response = "Bad request!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingValidity = await _context.Validities!.FindAsync(validity.Id);
            if (existingValidity == null)
            {
                response.Response = "Validity not found!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            // Check for references
            bool hasReferences = await _context.QuotationTerms!.AnyAsync(e => e.ValidityId == existingValidity.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Validity as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingValidity.IsDeleted = true;
            _context.Update(existingValidity);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Validity deleted successfully!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
