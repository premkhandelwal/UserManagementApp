using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.CreateMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.DeleteMember;
using CRM.Tenant.Service.Models.Requests.MasterRequests.Member.UpdateMember;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace Crm.Api.Controllers.Masters
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class MemberController : ControllerBase
    {
        private MemberService _memberService;
        public MemberController(MemberService memberService)
        {
            _memberService = memberService;
        }

        [HttpPost("CreateMember")]
        public async Task<IActionResult> CreateMember([FromBody] CreateMemberRequest member)
        {
            var result = await _memberService.CreateAsync(member);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpPut("UpdateMember")]
        public async Task<IActionResult> UpdateMember([FromBody] UpdateMemberRequest member)
        {
            var result = await _memberService.UpdateAsync(member);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpDelete("DeleteMember")]
        public async Task<IActionResult> DeleteMember([FromBody] DeleteMemberRequest member)
        {
            var result = await _memberService.DeleteAsync(member);
            return StatusCode(StatusCodes.Status200OK, result);
        }

        [HttpGet("ReadMembers")]
        public async Task<IActionResult> ReadMembers()
        {
            var result = await _memberService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, result);
        }
    }
}
