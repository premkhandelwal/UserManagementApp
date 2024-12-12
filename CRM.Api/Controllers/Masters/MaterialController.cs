using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.CreateMaterial;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.DeleteMaterial;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Material.UpdateMaterial;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MaterialController : ControllerBase
    {
        private MaterialService _materialService;
        public MaterialController(MaterialService materialService)
        {
            _materialService = materialService;
        }

        [HttpPost("CreateMaterial")]
        public async Task<IActionResult> CreateMaterial([FromBody] CreateMaterialRequest material)
        {
            var result = await _materialService.CreateAsync(material);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateMaterial")]
        public async Task<IActionResult> UpdateMaterial([FromBody] UpdateMaterialRequest material)
        {
            var result = await _materialService.UpdateAsync(material);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteMaterial")]
        public async Task<IActionResult> DeleteMaterial([FromBody] DeleteMaterialRequest material)
        {
            var result = await _materialService.DeleteAsync(material);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadMaterials")]
        public async Task<IActionResult> ReadMaterials()
        {
            var result = await _materialService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
