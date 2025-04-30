using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Authorization;
using CRM.Tenant.Service.Services.MasterServices.PurchaseOrder;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.CreateVendor;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.UpdateVendor;
using CRM.Tenant.Service.Models.Requests.MasterRequests.PurchseOrder.Vendor.DeleteVendor;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class VendorController : ControllerBase
    {
        private VendorService _vendorService;
        public VendorController(VendorService vendorService)
        {
            _vendorService = vendorService;
        }

        [HttpPost("CreateVendor")]
        public async Task<IActionResult> CreateVendor([FromBody] CreateVendorRequest vendor)
        {
            var result = await _vendorService.CreateAsync(vendor);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateVendor")]
        public async Task<IActionResult> UpdateVendor([FromBody] UpdateVendorRequest vendor)
        {
            var result = await _vendorService.UpdateAsync(vendor);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteVendor")]
        public async Task<IActionResult> DeleteVendor([FromBody] DeleteVendorRequest vendor)
        {
            var result = await _vendorService.DeleteAsync(vendor);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadVendors")]
        public async Task<IActionResult> ReadVendors()
        {
            var result = await _vendorService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
