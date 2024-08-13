using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.CreateTransportMode;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.DeleteTransportMode;
using CRM.Tenant.Service.Models.Requests.MasterRequests.TransportMode.UpdateTransportMode;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class TransportModeController : ControllerBase
    {
        private TransportModeService _transportmodeService;
        public TransportModeController(TransportModeService transportmodeService)
        {
            _transportmodeService = transportmodeService;
        }

        [HttpPost("CreateTransportMode")]
        public async Task<IActionResult> CreateTransportMode([FromBody] CreateTransportModeRequest transportmode)
        {
            var result = await _transportmodeService.CreateAsync(transportmode);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateTransportMode")]
        public async Task<IActionResult> UpdateTransportMode([FromBody] UpdateTransportModeRequest transportmode)
        {
            var result = await _transportmodeService.UpdateAsync(transportmode);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteTransportMode")]
        public async Task<IActionResult> DeleteTransportMode([FromBody] DeleteTransportModeRequest transportmode)
        {
            var result = await _transportmodeService.DeleteAsync(transportmode);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadTransportModes")]
        public async Task<IActionResult> ReadTransportModes()
        {
            var result = await _transportmodeService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
