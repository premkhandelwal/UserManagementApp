using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.CreateDeliveredTo;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.DeleteDeliveredTo;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveredTo.UpdateDeliveredTo;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveredToController : ControllerBase
    {
        private DeliveredToService _deliveredtoService;
        public DeliveredToController(DeliveredToService deliveredtoService)
        {
            _deliveredtoService = deliveredtoService;
        }

        [HttpPost("CreateDeliveredTo")]
        public async Task<IActionResult> CreateDeliveredTo([FromBody] CreateDeliveredToRequest deliveredto)
        {
            var result = await _deliveredtoService.CreateAsync(deliveredto);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateDeliveredTo")]
        public async Task<IActionResult> UpdateDeliveredTo([FromBody] UpdateDeliveredToRequest deliveredto)
        {
            var result = await _deliveredtoService.UpdateAsync(deliveredto);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteDeliveredTo")]
        public async Task<IActionResult> DeleteDeliveredTo([FromBody] DeleteDeliveredToRequest deliveredto)
        {
            var result = await _deliveredtoService.DeleteAsync(deliveredto);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadDeliveredTos")]
        public async Task<IActionResult> ReadDeliveredTo()
        {
            var result = await _deliveredtoService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
