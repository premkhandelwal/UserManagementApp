using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using UserManagementApp.Models;
using UserManagementApp.Models.UserManagementRequests;
using UserManagementService;
using UserManagementService.Models;

namespace UserManagementApp.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private UserManagement _userManagement; 
        public AuthController(UserManagement userManagement)
        {
            _userManagement = userManagement;
        }

        [HttpPost("CreateUser")]
        public async Task<IActionResult> CreateUser([FromBody] IUser registerUser)
        {
            IApiResponse<string> response = await _userManagement.CreateUser(registerUser);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            TokenResponse<string> response = await _userManagement.Login(request.emailId, request.password);
            if (response.IsSuccess)
            {
                /*var authCookieOptions = new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true, // Set to true if using HTTPS
                    SameSite = SameSiteMode.None,
                };
                var refreshCookieOptions = new CookieOptions
                {
                    HttpOnly = false,
                    Secure = true, // Set to true if using HTTPS
                    SameSite = SameSiteMode.None,
                    
                };
                Response.Cookies.Append("AuthToken", response.AuthToken ?? "", authCookieOptions);
                Response.Cookies.Append("RefreshToken", response.RefreshToken ?? "", refreshCookieOptions);
                response.AuthToken = null;
                response.RefreshToken = null;*/
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status401Unauthorized, response);
        }

        [HttpPost("RefreshToken")]
        public async Task<IActionResult> RefreshToken([FromBody] TokenRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }
            IApiResponse<string> response = await _userManagement.RefreshToken(request.AuthToken, request.RefreshToken);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status401Unauthorized, response);
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Policy = "ViewUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            IApiResponse<List<IUser>> response = await _userManagement.GetAllUsers();
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] string role)
        {
            IApiResponse<string> response = await _userManagement.CreateRole(role);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            IApiResponse<List<IdentityRole>> response = await _userManagement.GetAllRoles();
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpPost("AssignRoleToUser")]
        [Authorize(Policy = "RoleOrPolicy"), ]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleRequest request)
        {
            IApiResponse<string> response = await _userManagement.AssignRoleToUser(request.emailId, request.role);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("GetRolesForUser")]
        public async Task<IActionResult> GetRolesForUser(string emailId)
        {
            IApiResponse<List<string>> response = await _userManagement.GetRolesForUser(emailId);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
        
        [HttpPut("UpdateRoleForUser")]
        public async Task<IActionResult> UpdateRoleForUser([FromBody] AssignRoleRequest request)
        {
            IApiResponse<string> response = await _userManagement.UpdateRoleForUser(request.emailId, request.role);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
        
        [HttpPost("AddClaimForUser")]
        //[Authorize(Policy = "RolePolicy")]
        public async Task<IActionResult> AddClaimForUser([FromBody] AddClaimforUserRequest request)
        {
            IApiResponse<string> response = await _userManagement.AddClaimForUser(request.emailId, request.claimName, request.claimValue);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpPost("AddClaimsForUser")]
        //[Authorize(Policy = "RolePolicy")]
        public async Task<IActionResult> AddClaimsForUser([FromBody] AddMultipleClaimsForUserRequest request)
        {
            IApiResponse<string> response = await _userManagement.AddClaimsForUser(request.emailId, request.claims);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }



        [HttpPost("AddClaimForRole")]
        //[Authorize(Policy = "RolePolicy")]
        public async Task<IActionResult> AddClaimForRole(string emailId, string claimValue)
        {
            IApiResponse<string> response = await _userManagement.AddClaimForRole(emailId, claimValue);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("GetClaimsForUser")]
        public async Task<IActionResult> GetClaimsForUser(string emailId)
        {
            IApiResponse<List<Claim>> response = await _userManagement.GetClaimsForUser(emailId);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
    }
}
