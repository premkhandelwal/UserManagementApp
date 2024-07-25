using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using System.Diagnostics.Metrics;
using UserManagementApp.Models.Masters;
using UserManagementApp.Models.UserManagementRequests;
using UserManagementData;
using UserManagementService.Models;

namespace UserManagementApp.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class ClientController : ControllerBase
    {

        private ClientApplicationDbContext _context;
        public ClientController(ClientApplicationDbContext arihantApplicationDbContext)
        {
            _context = arihantApplicationDbContext;
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
            client.Id = Guid.NewGuid().ToString();
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
            List<ClientModel> result = _context.Clients!.ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateClient")]
        public async Task<IActionResult> UpdateClient([FromBody] ClientModel Client)
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
            _context.Update(Client);
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
            //client.IsDeleted = true;
            _context.Update(client);
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
