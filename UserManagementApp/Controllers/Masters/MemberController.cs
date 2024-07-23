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
    public class MemberController : ControllerBase
    {

        private ClientApplicationDbContext _context;
        public MemberController(ClientApplicationDbContext arihantApplicationDbContext)
        {
            _context = arihantApplicationDbContext;
        }

        [HttpPost("CreateMember")]
        public async Task<IActionResult> CreateMember([FromBody] MemberModel member)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            await _context.Members!.AddAsync(member);
            int result = await _context.SaveChangesAsync();
            if(result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, "Member created successfully!!");
            }  
            return StatusCode(StatusCodes.Status501NotImplemented, "Failed to add member");
        }

        [HttpGet("ReadMembers")]
        public IActionResult ReadMembers()
        {
            List<MemberModel> result = _context.Members!.ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody] MemberModel member)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            _context.Update(member);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, "Member updated successfully!!");
            }
            return StatusCode(StatusCodes.Status501NotImplemented, "Failed to update member");
        }


        [HttpDelete("DeleteMember")]
        public async Task<IActionResult> DeleteMember([FromBody] MemberModel member)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            _context.Remove(member);
            int result = await _context.SaveChangesAsync();
            if (result > 0)
            {
                return StatusCode(StatusCodes.Status200OK, "Member deleted successfully!!");
            }
            return StatusCode(StatusCodes.Status501NotImplemented, "Failed to delete member");
        }



    }
}
