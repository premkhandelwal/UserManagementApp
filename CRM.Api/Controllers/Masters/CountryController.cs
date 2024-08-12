using Crm.Tenant.Service.Models.Requests.Currencies.CreateCountry;
using Microsoft.AspNetCore.Mvc;
using Crm.Tenant.Service.Models.Requests.Currencies.UpdateCountry;
using Crm.Tenant.Service.Models.Requests.Currencies.DeleteCountry;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class CountryController : ControllerBase
    {
        private CountryService _countryService;

        public CountryController(CountryService countryService)
        {
            _countryService = countryService;
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry([FromBody] CreateCountryRequest country)
        {
            var result = await _countryService.CreateAsync(country);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry([FromBody] UpdateCountryRequest country)
        {
            var result = await _countryService.UpdateAsync(country);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry([FromBody] DeleteCountryRequest country)
        {
            var result = await _countryService.DeleteAsync(country);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadCountries")]
        public async Task<IActionResult> ReadCountries()
        {
            var result = await _countryService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
