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
    public class CountryController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public CountryController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateCountry")]
        public async Task<IActionResult> CreateCountry([FromBody] CountryModel country)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Country!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            country.IsDeleted = false;
            country.AddedOn = DateTime.Now;
            await _context.Countries!.AddAsync(country);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Country created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadCountries")]
        public IActionResult ReadCountries()
        {
            List<CountryModel> result = _context.Countries!.Where(country => country.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateCountry")]
        public async Task<IActionResult> UpdateCountry([FromBody] CountryModel country)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Country!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingCountry = await _context.Countries!.FindAsync(country.Id);
            if (existingCountry == null)
            {
                response.IsSuccess = false;
                response.Response = "Country not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            existingCountry.CountryName = country.CountryName;
            _context.Update(existingCountry);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Country updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteCountry")]
        public async Task<IActionResult> DeleteCountry([FromBody] CountryModel country)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Country!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingCountry = await _context.Countries!.FindAsync(country.Id);
            if (existingCountry == null)
            {
                response.IsSuccess = false;
                response.Response = "Country not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            bool hasReferences = await _context.QuotationTerms!.AnyAsync(e => e.CountryofOriginId == existingCountry.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Country as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }
            existingCountry.IsDeleted = true;
            _context.Update(existingCountry);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Country deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
