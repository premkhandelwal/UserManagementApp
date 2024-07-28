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
    public class MtcTypeController : ControllerBase
    {

        private ClientApplicationDbContext _context;
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
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            mtctype.Id = Guid.NewGuid().ToString();
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
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            mtctype.IsDeleted = false;
            _context.Update(mtctype);
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
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            mtctype.IsDeleted = true;
            _context.Update(mtctype);
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