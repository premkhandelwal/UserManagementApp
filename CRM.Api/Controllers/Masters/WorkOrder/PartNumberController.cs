using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.CreatePartNumber;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.DeletePartNumber;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PartNumber.UpdatePartNumber;
using CRM.Tenant.Service.Services.MasterServices.WorkOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers.Masters.WorkOrder
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PartNumberController : ControllerBase
    {
        private PartNumberService _partNumberService;

        public PartNumberController(PartNumberService partNumberService)
        {
            _partNumberService = partNumberService;
        }
        //TODO: Add migration for part number
        [HttpPost("CreatePartNumber")]
        public async Task<IActionResult> CreatePartNumber([FromBody] CreatePartNumberRequest partnumber)
        {
            var result = await _partNumberService.CreateAsync(partnumber);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdatePartNumber")]
        public async Task<IActionResult> UpdatePartNumber([FromBody] UpdatePartNumberRequest partnumber)
        {
            var result = await _partNumberService.UpdateAsync(partnumber);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeletePartNumber")]
        public async Task<IActionResult> DeletePartNumber([FromBody] DeletePartNumberRequest partnumber)
        {
            var result = await _partNumberService.DeleteAsync(partnumber);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadPartNumbers")]
        public async Task<IActionResult> ReadPartNumbers()
        {
            var result = await _partNumberService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
