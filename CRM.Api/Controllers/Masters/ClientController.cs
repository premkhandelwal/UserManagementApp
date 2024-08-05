using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.Metrics;
using CRM.Api.Models.Masters;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private ClientApplicationDbContext _context;
        public ClientController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] ClientModel client)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Client!!",
                StatusCode = 501
            };
            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            client.AddedOn = DateTime.Now;
            client.IsDeleted = false;
            await _context.Clients!.AddAsync(client);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Client created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadClients")]
        public IActionResult ReadClients()
        {
            List<ClientModel> result = _context.Clients!.Where(client => client.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] ClientModel client)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Client!!",
                StatusCode = 501
            };
            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            var existingClient = await _context.Clients!.FindAsync(client.Id);
            if(existingClient == null)
            {
                response.IsSuccess = false;
                response.Response = "Client not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            existingClient.CompanyName = client.CompanyName;
            existingClient.Country = client.Country;
            existingClient.Region = client.Region;
            existingClient.Website = client.Website;
            _context.Update(existingClient);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Client updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }


        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient([FromBody] ClientModel client)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Client!!",
                StatusCode = 501
            };
            if (ModelState.IsValid == false)
            {
                response.IsSuccess = false;
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            var existingClient = await _context.Clients!.FindAsync(client.Id);
            if (existingClient == null)
            {
                response.IsSuccess = false;
                response.Response = "Client not found!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }
            bool hasMemberReferences = await _context.Members!.AnyAsync(e => e.ClientId == existingClient.Id);
            bool hasQuotationReferences = await _context.Quotations!.AnyAsync(e => e.QuotationCompanyId == existingClient.Id);
            if (hasMemberReferences || hasQuotationReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Client as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }
            existingClient.IsDeleted = true;
            _context.Update(existingClient);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Client deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
