using Microsoft.AspNetCore.Mvc;
using CRM.Api.Models.Masters;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MaterialController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public MaterialController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateMaterial")]
        public async Task<IActionResult> CreateMaterial([FromBody] MaterialModel material)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Material!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            material.AddedOn = DateTime.Now;
            material.IsDeleted = false;
            await _context.Materials!.AddAsync(material);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Material created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadMaterials")]
        public IActionResult ReadMaterials()
        {
            List<MaterialModel> result = _context.Materials!.Where(material => material.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateMaterial")]
        public async Task<IActionResult> UpdateMaterial([FromBody] MaterialModel material)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Material!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMaterial = await _context.Materials!.FindAsync(material.Id);
            if (existingMaterial == null)
            {
                response.Response = "Material not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingMaterial.MaterialName = material.MaterialName;

            _context.Update(existingMaterial);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Material updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteMaterial")]
        public async Task<IActionResult> DeleteMaterial([FromBody] MaterialModel material)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Material!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMaterial = await _context.Materials!.FindAsync(material.Id);
            if (existingMaterial == null)
            {
                response.Response = "Material not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingMaterial.IsDeleted = true;
            _context.Update(existingMaterial);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Material deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
