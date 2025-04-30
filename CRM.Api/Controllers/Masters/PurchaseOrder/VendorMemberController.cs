using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.CreateVendorMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.DeleteVendorMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.VendorMember.UpdateVendorMember;
using CRM.Tenant.Service.Services.MasterServices.PurchaseOrder;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorMemberController : ControllerBase
    {
        private VendorMemberService _vendormemberService;
        public VendorMemberController(VendorMemberService vendormemberService)
        {
            _vendormemberService = vendormemberService;
        }

        [HttpPost("CreateVendorMember")]
        public async Task<IActionResult> CreateVendorMember([FromBody] CreateVendorMemberRequest vendormember)
        {
            var result = await _vendormemberService.CreateAsync(vendormember);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateVendorMember")]
        public async Task<IActionResult> UpdateVendorMember([FromBody] UpdateVendorMemberRequest vendormember)
        {
            var result = await _vendormemberService.UpdateAsync(vendormember);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteVendorMember")]
        public async Task<IActionResult> DeleteVendorMember([FromBody] DeleteVendorMemberRequest vendormember)
        {
            var result = await _vendormemberService.DeleteAsync(vendormember);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadVendorMembers")]
        public async Task<IActionResult> ReadVendorMembers()
        {
            var result = await _vendormemberService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
