using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.CreateMtcType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.DeleteMtcType;
using CRM.Tenant.Service.Models.Requests.MasterRequests.MtcType.UpdateMtcType;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MtcTypeController : ControllerBase
    {
        private MtcTypeService _mtctypeService;
        public MtcTypeController(MtcTypeService mtctypeService)
        {
            _mtctypeService = mtctypeService;
        }

        [HttpPost("CreateMtcType")]
        public async Task<IActionResult> CreateMtcType([FromBody] CreateMtcTypeRequest mtctype)
        {
            var result = await _mtctypeService.CreateAsync(mtctype);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateMtcType")]
        public async Task<IActionResult> UpdateMtcType([FromBody] UpdateMtcTypeRequest mtctype)
        {
            var result = await _mtctypeService.UpdateAsync(mtctype);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteMtcType")]
        public async Task<IActionResult> DeleteMtcType([FromBody] DeleteMtcTypeRequest mtctype)
        {
            var result = await _mtctypeService.DeleteAsync(mtctype);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadMtcTypes")]
        public async Task<IActionResult> ReadMtcTypes()
        {
            var result = await _mtctypeService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
