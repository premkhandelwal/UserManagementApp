using Microsoft.AspNetCore.Mvc;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.CreateHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.DeleteHsn;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Hsn.UpdateHsn;
using Microsoft.AspNetCore.Authorization;
using CRM.Tenant.Service.Services.MasterServices;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class HsnController : ControllerBase
    {
        private HsnService _hsnService;
        public HsnController(HsnService hsnService)
        {
            _hsnService = hsnService;
        }

        [HttpPost("CreateHsn")]
        public async Task<IActionResult> CreateHsn([FromBody] CreateHsnRequest hsn)
        {
            var result = await _hsnService.CreateAsync(hsn);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateHsn")]
        public async Task<IActionResult> UpdateHsn([FromBody] UpdateHsnRequest hsn)
        {
            var result = await _hsnService.UpdateAsync(hsn);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteHsn")]
        public async Task<IActionResult> DeleteHsn([FromBody] DeleteHsnRequest hsn)
        {
            var result = await _hsnService.DeleteAsync(hsn);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadHsn")]
        public async Task<IActionResult> ReadHsns()
        {
            var result = await _hsnService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
