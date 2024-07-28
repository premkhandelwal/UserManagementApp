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
    public class DeliveredToController : ControllerBase
    {

        private ClientApplicationDbContext _context;
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
            deliveredto.Id = Guid.NewGuid().ToString();
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
            List<DeliveredToModel> result = _context.DeliveredTo!.Where(deliveredto => deliveredto.IsDeleted == false).ToList();
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
            deliveredto.IsDeleted = false;
            _context.Update(deliveredto);
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
            deliveredto.IsDeleted = true;
            _context.Update(deliveredto);
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
