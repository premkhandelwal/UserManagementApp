using Microsoft.AspNetCore.Mvc;
using CRM.Api.Models.Masters;
using CRM.Api.Models.UserManagementRequests;
using CRM.Admin.Data;
using CRM.Admin.Service.Models;
using Microsoft.EntityFrameworkCore;

namespace CRM.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    public class MemberController : ControllerBase
    {
        private readonly ClientApplicationDbContext _context;

        public MemberController(ClientApplicationDbContext clientApplicationDbContext)
        {
            _context = clientApplicationDbContext;
        }

        [HttpPost("CreateMember")]
        public async Task<IActionResult> CreateMember([FromBody] MemberModel member)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to add Member!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            member.AddedOn = DateTime.Now;
            member.IsDeleted = false;
            await _context.Members!.AddAsync(member);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Member created successfully!!";
                response.StatusCode = 201;
                return StatusCode(StatusCodes.Status201Created, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("ReadMembers")]
        public IActionResult ReadMembers()
        {
            List<MemberModel> result = _context.Members!.Where(member => member.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody] MemberModel member)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to update Member!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMember = await _context.Members!.FindAsync(member.Id);
            if (existingMember == null)
            {
                response.Response = "Member not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            existingMember.MemberName = member.MemberName;
            existingMember.Email = member.Email;
            existingMember.Mobile = member.Mobile;
            existingMember.IsWhatsApp = member.IsWhatsApp;
            existingMember.SkypeId = member.SkypeId;
            existingMember.Telephone = member.Telephone;
            existingMember.ClientId = member.ClientId;

            _context.Update(existingMember);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Member updated successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpDelete("DeleteMember")]
        public async Task<IActionResult> DeleteMember([FromBody] MemberModel member)
        {
            IApiResponse<string> response = new IApiResponse<string>
            {
                IsSuccess = false,
                Response = "Failed to delete Member!!",
                StatusCode = 501
            };

            if (ModelState.IsValid == false)
            {
                response.Response = "Bad request!!";
                response.StatusCode = 400;
                return StatusCode(StatusCodes.Status400BadRequest, response);
            }

            var existingMember = await _context.Members!.FindAsync(member.Id);
            if (existingMember == null)
            {
                response.Response = "Member not found!!";
                response.StatusCode = 404;
                return StatusCode(StatusCodes.Status404NotFound, response);
            }

            // Check for references
            bool hasReferences = await _context.Quotations!.AnyAsync(e => e.QuotationAttentionId == existingMember.Id);
            if (hasReferences)
            {
                response.IsSuccess = false;
                response.Response = "Cannot delete Member as it is referenced in other records.";
                response.StatusCode = 409; // Conflict
                return StatusCode(StatusCodes.Status409Conflict, response);
            }

            existingMember.IsDeleted = true;
            _context.Update(existingMember);
            int result = await _context.SaveChangesAsync();

            if (result > 0)
            {
                response.IsSuccess = true;
                response.Response = "Member deleted successfully!!";
                response.StatusCode = 200;
                return StatusCode(StatusCodes.Status200OK, response);
            }

            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
