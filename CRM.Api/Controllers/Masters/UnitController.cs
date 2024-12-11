using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Unit.CreateUnit;
using CRM.Tenant.Service.Services.MasterServices;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class UnitController : ControllerBase
    {
        UnitService _unitService;
        public UnitController(UnitService unitService) 
        {
            _unitService = unitService;
        }

        [HttpPost("CreateUnit")]
        public async Task<IActionResult> CreateUnit([FromBody] CreateUnitRequest client)
        {
            var result = await _unitService.CreateAsync(client);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadUnits")]
        public async Task<IActionResult> ReadUnits()
        {
            var result = await _unitService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
