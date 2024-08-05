using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Api.Models.Masters;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;
using CRM.Api.Models.UserManagementRequests;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class CurrencyController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public CurrencyController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateCurrency")]
        public async Task<IActionResult> CreateCurrency([FromBody] CurrencyModel currency)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Currency!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            currency.IsDeleted = false;
            currency.AddedOn = DateTime.Now;
            await _context.Currencies!.AddAsync(currency);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Currency created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadCurrencies")]
        public IActionResult ReadCurrencies()
        {
            List<CurrencyModel> result = _context.Currencies!.Where(currency => currency.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateCurrency")]
        public async Task<IActionResult> UpdateCurrency([FromBody] CurrencyModel currency)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Currency!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingCurrency = await _context.Currencies!.FindAsync(currency.Id);
            if (existingCurrency == null)
            {
                response.IsSuccess = false;
                response.Response = "Currency not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            existingCurrency.CurrencyName = currency.CurrencyName;
            existingCurrency.CurrencyRate = currency.CurrencyRate;

            _context.Update(existingCurrency);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Currency updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteCurrency")]
        public async Task<IActionResult> DeleteCurrency([FromBody] CurrencyModel currency)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Currency!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingCurrency = await _context.Currencies!.FindAsync(currency.Id);
            if (existingCurrency == null)
            {
                response.IsSuccess = false;
                response.Response = "Currency not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            bool hasReferences = await _context.QuotationTerms!.AnyAsync(e => e.CurrencyId == existingCurrency.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Currency as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingCurrency.IsDeleted = true;
            _context.Update(existingCurrency);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Currency deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
