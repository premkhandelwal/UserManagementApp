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
    public class MtcTypeController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public MtcTypeController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateMtcType")]
        public async Task<IActionResult> CreateMtcType([FromBody] MtcTypeModel mtctype)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Mtc Type!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            mtctype.AddedOn = DateTime.Now;
            mtctype.IsDeleted = false;
            await _context.MtcTypes!.AddAsync(mtctype);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Mtc Type created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadMtcTypes")]
        public IActionResult ReadMtcTypes()
        {
            List<MtcTypeModel> result = _context.MtcTypes!.Where(mtctype => mtctype.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateMtcType")]
        public async Task<IActionResult> UpdateMtcType([FromBody] MtcTypeModel mtctype)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Mtc Type!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMtcType = await _context.MtcTypes!.FindAsync(mtctype.Id);
            if (existingMtcType == null)
            {
                response.Response = "Mtc Type not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingMtcType.MtcType = mtctype.MtcType;

            _context.Update(existingMtcType);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Mtc Type updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteMtcType")]
        public async Task<IActionResult> DeleteMtcType([FromBody] MtcTypeModel mtctype)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Mtc Type!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMtcType = await _context.MtcTypes!.FindAsync(mtctype.Id);
            if (existingMtcType == null)
            {
                response.Response = "Mtc Type not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            // Check for references
            bool hasReferences = await _context.QuotationTerms!.AnyAsync(e => e.MtcTypeId == existingMtcType.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Mtc Type as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingMtcType.IsDeleted = true;
            _context.Update(existingMtcType);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Mtc Type deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
