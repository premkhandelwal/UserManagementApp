using Microsoft.AspNetCore.Mvc;
using CRM.Tenant.Service.Services.PurchaseOrderService;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Update;
using System.Security.Claims;
using Microsoft.AspNetCore.Authorization;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Create;
using CRM.Tenant.Service.Models.Requests.PurchaseOrder.Delete;

namespace Crm.Api.Controllers.PurchaseOrder
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class PurchaseOrderController : ControllerBase
    {
        PurchaseOrderService _purchaseOrderService;
        public PurchaseOrderController(PurchaseOrderService purchaseOrderService)
        {
            _purchaseOrderService = purchaseOrderService;
        }

        [HttpPost("CreatePurchaseOrder")]
        public async Task<IActionResult> CreatePurchaseOrder([FromBody] CreatePurchaseOrderRequest purchaseOrderRequest)
        {
            var result = await _purchaseOrderService.Create(purchaseOrderRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdatePurchaseOrder")]
        public async Task<IActionResult> UpdatePurchaseOrder([FromBody] UpdatePurchaseOrderRequest purchaseOrderRequest)
        {
            var result = await _purchaseOrderService.Update(purchaseOrderRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("DeletePurchaseOrder")]
        public async Task<IActionResult> DeletePurchaseOrder([FromBody] DeletePurchaseOrderRequest purchaseOrderRequest)
        {
            var result = await _purchaseOrderService.Delete(purchaseOrderRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetPurchaseOrders")]
        public async Task<IActionResult> GetPurchaseOrders()
        {

            var isAdmin = User.HasClaim(c => c.Type == ClaimTypes.Role && c.Value == "admnRole");
            int userId = -1;
            int.TryParse(User.Claims.FirstOrDefault(c => c.Type == "Id")?.Value, out userId);
            if (userId == -1)
            {
                return Unauthorized(new { Message = "User is not authorized." });
            }

            if (User.IsInRole("adminRole"))
            {
                // User is an Admin, return all purchaseOrders
                var purchaseOrders = await _purchaseOrderService.Get();
                return Ok(purchaseOrders);
            }
            else
            {
                var userPurchaseOrders = await _purchaseOrderService.GetPurchaseOrdersForUser(userId);
                return Ok(userPurchaseOrders);
            }

        }

        [HttpGet("GetPurchaseOrderById")]
        public async Task<IActionResult> GetPurchaseOrderById(int id)
        {
            var result = await _purchaseOrderService.GetPurchaseOrderById(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

    }
}
