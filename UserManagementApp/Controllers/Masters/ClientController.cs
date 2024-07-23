using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.ChangeTracking;
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
        public async Task<IActionResult> CreateClient([FromBody] ClientModel Client)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            await _context.Clients!.AddAsync(Client);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, "Client created successfully!!");
            }
            return StatusCode(StatusCodes.Status501NotImplemented, "Failed to add Client");
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
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            _context.Update(Client);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, "Client updated successfully!!");
            }
            return StatusCode(StatusCodes.Status501NotImplemented, "Failed to update Client");
        }


        [HttpDelete("DeleteClient")]
        public async Task<IActionResult> DeleteClient([FromBody] ClientModel Client)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            _context.Remove(Client);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, "Client deleted successfully!!");
            }
            return StatusCode(StatusCodes.Status501NotImplemented, "Failed to delete Client");
        }



    }
}
