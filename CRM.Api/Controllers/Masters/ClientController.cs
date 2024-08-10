using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using CRM.Admin.Service.Models;
using CRM.Tenant.Service.Services.MasterServices;
using CRM.Tenant.Service.Models.Requests.Clients.CreateClient;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {
        private ClientService _clientService;
        public ClientController(ClientService clientService)
        {
            _clientService = clientService;
        }

        [HttpPost("CreateClient")]
        public async Task<IActionResult> CreateClient([FromBody] CreateClientRequest client)
        {
            if (ModelState.IsValid == false)
            {
                

            }
            var result = await _clientService.CreateClient(client);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        /*[HttpGet("ReadClients")]
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
        }*/
    }
}
