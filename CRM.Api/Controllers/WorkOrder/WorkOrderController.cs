using CRM.Tenant.Service.Models.Requests.WorkOrder.Create;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Delete;
using CRM.Tenant.Service.Models.Requests.WorkOrder.Update;
using CRM.Tenant.Service.Services.WorkOrderService;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers.WorkOrder
{
    [Route("api/[controller]")]
    [ApiController]
    public class WorkOrderController : ControllerBase
    {
        WorkOrderService _workOrderService;

        public WorkOrderController(WorkOrderService workOrderService) 
        {
            _workOrderService = workOrderService;
        }

        [HttpPost("CreateWorkOrder")]
        public async Task<IActionResult> CreateWorkOrder([FromBody] CreateWorkOrderRequest workOrderRequest)
        {
            var result = await _workOrderService.Create(workOrderRequest);
            return StatusCode(StatusCodes.Status200OK, result);
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
    }
}
