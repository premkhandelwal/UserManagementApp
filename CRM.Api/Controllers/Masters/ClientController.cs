using Microsoft.AspNetCore.Mvc;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.CreateClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.DeleteClient;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Clients.UpdateClient;

namespace Crm.Api.Controllers.Masters
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
            var result = await _clientService.CreateAsync(client);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] UpdateClientRequest client)
        {
            var result = await _clientService.UpdateAsync(client);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient([FromBody] DeleteClientRequest client)
        {
            var result = await _clientService.DeleteAsync(client);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadClients")]
        public async Task<IActionResult> ReadClients()
        {
            var result = await _clientService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
