using Microsoft.AspNetCore.Mvc;
using Crm.Tenant.Service.Models.Requests.Currencies.CreateCurrency;
using Crm.Tenant.Service.Models.Requests.Currencies.DeleteCurrency;
using Crm.Tenant.Service.Models.Requests.Currencies.UpdateCurrency;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private CurrencyService _currencyService;
        public CurrencyController(CurrencyService currencyService)
        {
            _currencyService = currencyService;
        }

        [HttpPost("CreateCurrency")]
        public async Task<IActionResult> CreateCurrency([FromBody] CreateCurrencyRequest currency)
        {
            var result = await _currencyService.CreateAsync(currency);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateCurrency")]
        public async Task<IActionResult> UpdateCurrency([FromBody] UpdateCurrencyRequest currency)
        {
            var result = await _currencyService.UpdateAsync(currency);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteCurrency")]
        public async Task<IActionResult> DeleteCurrency([FromBody] DeleteCurrencyRequest currency)
        {
            var result = await _currencyService.DeleteAsync(currency);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadCurrencies")]
        public async Task<IActionResult> ReadCurrencies()
        {
            var result = await _currencyService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
