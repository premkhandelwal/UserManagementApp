using CRM.Tenant.Service.Models.Requests.WorkOrder.Create;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Create.CreateWorkOrderStatus;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Delete;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Update;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Update.UpdateWorkOrderStatus;
using CRM.Tenant.Service.Models.Responses.WorkOrder;
using CRM.Tenant.Service.Services.WorkOrderService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Controllers.WorkOrder
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]

    public class WorkOrderController : ControllerBase
    {
        WorkOrderService _workOrderService;
        WorkOrderStatusService _workOrderStatusService;

        public WorkOrderController(WorkOrderService workOrderService, WorkOrderStatusService workOrderStatusService) 
        {
            _workOrderService = workOrderService;
            _workOrderStatusService = workOrderStatusService;
        }

        [HttpPost("CreateWorkOrder")]
        public async Task<IActionResult> CreateWorkOrder([FromBody] CreateWorkOrderRequest workOrderRequest)
        {
            try
            {
                CreateWorkOrderResponse result = await _workOrderService.Create(workOrderRequest);

                // TryParse result.Message as Id
                bool isSuccess = int.TryParse(result.Message, out int id);
                if (isSuccess)
                {
                    CreateWorkOrderStatusRequest workOrderStatus = new CreateWorkOrderStatusRequest()
                    {
                        WorkOrderId = id,
                        AddedOn = DateTime.Now,
                        ModifiedOn = DateTime.Now,
                    };
                    await _workOrderStatusService.CreateAsync(workOrderStatus);
                }

                return Ok(result); // 200 OK
            }
            catch (InvalidOperationException ex) when (ex.Message.Contains("duplicate", StringComparison.OrdinalIgnoreCase))
            {
                return BadRequest(new { response = "Duplicate work id found" }); // 409 Conflict
            }
            catch (InvalidOperationException ex)
            {
                return BadRequest(new { response = ex.Message }); // 400 Bad Request
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { message = "An unexpected error occurred.", detail = ex.Message });
            }
        }

        [HttpPut("UpdateWorkOrder")]
        public async Task<IActionResult> UpdateWorkOrder([FromBody] UpdateWorkOrderRequest workOrderRequest)
        {
            var result = await _workOrderService.Update(workOrderRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("DeleteWorkOrder")]
        public async Task<IActionResult> DeleteWorkOrder([FromBody] DeleteWorkOrderRequest workOrderRequest)
        {
            var result = await _workOrderService.Delete(workOrderRequest);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("GetWorkOrders")]
        public async Task<IActionResult> GetWorkOrders()
        {
            var workOrders = await _workOrderService.Get();
            return Ok(workOrders);
        }

        [HttpGet("GetWorkOrderById")]
        public async Task<IActionResult> GetWorkOrderById(int id)
        {
            var result = await _workOrderService.GetWorkOrderById(id);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateWorkOrderStatus")]
        public async Task<IActionResult> UpdateWorkOrder([FromBody] UpdateWorkOrderStatusRequest workOrderRequest)
        {
            try
            {
                var result = await _workOrderStatusService.Update(workOrderRequest);
                return StatusCode(StatusCodes.Status200OK, result);
            }
            catch (DbUpdateConcurrencyException)
            {
                return Conflict(new { response = "The record was updated by another user." });
            }
        }

        [HttpGet("GetWorkOrdersStatus")]
        public async Task<IActionResult> GetWorkOrdersStatus()
        {
            var workOrders = await _workOrderService.Get();
            var result = await _workOrderStatusService.GetWorkOrdersStatus(workOrders);
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
