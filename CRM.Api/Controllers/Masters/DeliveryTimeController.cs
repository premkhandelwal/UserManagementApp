using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.CreateDeliveryTime;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.DeleteDeliveryTime;
using CRM.Tenant.Service.Models.Requests.MasterRequests.DeliveryTime.UpdateDeliveryTime;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class DeliveryTimeController : ControllerBase
    {
        private DeliveryTimeService _deliverytimeService;
        public DeliveryTimeController(DeliveryTimeService deliverytimeService)
        {
            _deliverytimeService = deliverytimeService;
        }

        [HttpPost("CreateDeliveryTime")]
        public async Task<IActionResult> CreateDeliveryTime([FromBody] CreateDeliveryTimeRequest deliverytime)
        {
            var result = await _deliverytimeService.CreateAsync(deliverytime);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateDeliveryTime")]
        public async Task<IActionResult> UpdateDeliveryTime([FromBody] UpdateDeliveryTimeRequest deliverytime)
        {
            var result = await _deliverytimeService.UpdateAsync(deliverytime);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteDeliveryTime")]
        public async Task<IActionResult> DeleteDeliveryTime([FromBody] DeleteDeliveryTimeRequest deliverytime)
        {
            var result = await _deliverytimeService.DeleteAsync(deliverytime);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadDeliveryTimes")]
        public async Task<IActionResult> ReadDeliveryTimes()
        {
            var result = await _deliverytimeService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
