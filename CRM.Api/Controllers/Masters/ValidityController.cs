﻿using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.CreateValidity;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.DeleteValidity;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Validity.UpdateValidity;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class ValidityController : ControllerBase
    {
        private ValidityService _validityService;
        public ValidityController(ValidityService validityService)
        {
            _validityService = validityService;
        }

        [HttpPost("CreateValidity")]
        public async Task<IActionResult> CreateValidity([FromBody] CreateValidityRequest validity)
        {
            var result = await _validityService.CreateAsync(validity);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateValidity")]
        public async Task<IActionResult> UpdateValidity([FromBody] UpdateValidityRequest validity)
        {
            var result = await _validityService.UpdateAsync(validity);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteValidity")]
        public async Task<IActionResult> DeleteValidity([FromBody] DeleteValidityRequest validity)
        {
            var result = await _validityService.DeleteAsync(validity);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadValidities")]
        public async Task<IActionResult> ReadValidities()
        {
            var result = await _validityService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
