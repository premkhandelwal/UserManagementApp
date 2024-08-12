using Crm.Tenant.Service.Models.Requests.PaymentType.CreatePaymentType;
using Crm.Tenant.Service.Models.Requests.PaymentType.DeletePaymentType;
using Crm.Tenant.Service.Models.Requests.PaymentType.UpdatePaymentType;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class PaymentTypeController : ControllerBase
    {
        private PaymentTypeService _paymenttypeService;
        public PaymentTypeController(PaymentTypeService paymenttypeService)
        {
            _paymenttypeService = paymenttypeService;
        }

        [HttpPost("CreatePaymentType")]
        public async Task<IActionResult> CreatePaymentType([FromBody] CreatePaymentTypeRequest paymenttype)
        {
            var result = await _paymenttypeService.CreateAsync(paymenttype);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdatePaymentType")]
        public async Task<IActionResult> UpdatePaymentType([FromBody] UpdatePaymentTypeRequest paymenttype)
        {
            var result = await _paymenttypeService.UpdateAsync(paymenttype);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeletePaymentType")]
        public async Task<IActionResult> DeletePaymentType([FromBody] DeletePaymentTypeRequest paymenttype)
        {
            var result = await _paymenttypeService.DeleteAsync(paymenttype);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadPaymentTypes")]
        public async Task<IActionResult> ReadPaymentTypes()
        {
            var result = await _paymenttypeService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
