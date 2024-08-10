using Crm.Tenant.Data.DbContexts;
using CRM.Admin.Service.Models;
using CRM.Api.Models.Quotation;
using Microsoft.AspNetCore.Mvc;

namespace CRM.Api.Controllers.Quotation
{
    [Route("api/[controller]")]
    [ApiController]
    public class QuotationController : ControllerBase
    {
        private ClientApplicationDbContext _context;
        public QuotationController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateQuotation")]
        public async Task<IActionResult> CreateQuotation(QuotationModel quotation)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Quotation!!",
                StatusCode = 501
            };
            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            
            await _context.Quotations!.AddAsync(quotation);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Quotation created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

    }
}
