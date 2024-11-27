using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.Security.Claims;
using Crm.Api.Models.UserManagementRequests;
using Crm.Admin.Service.Models;
using Crm.Admin.Service.Services;
using CRM.Admin.Service.Models;
using CRM.Tenant.Service.Services;
using Crm.Admin.Data.Models;
using CRM.Tenant.Service.Models.Requests.UserRequests;
using System.Transactions;
using Crm.Tenant.Data.Models.UserManagementRequests;
using CRM.Admin.Service.Services;

namespace Crm.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IdentityService _identityService;
        private readonly UserService _userService;
        private readonly AuthService _authService;
        private readonly EmailService _emailService;
        private readonly OtpService _otpService;
        public AuthController(IdentityService identityService, UserService userService, AuthService authService, EmailService emailService, OtpService otpService)
        {
            _identityService = identityService;
            _userService = userService;
            _authService = authService;
            _emailService = emailService;
            _otpService = otpService;
        }

        [HttpPost("CreateUser")]
        [Authorize]
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest registerUser)
        {
                IApiResponse<string> response = await _identityService.CreateUser(registerUser.EmailId, registerUser.Username, registerUser.Password, registerUser.Role);

                if (response.IsSuccess)
                {
                    registerUser.UserId = response.Response;
                    UserModel? user = await _userService.CreateAsync(registerUser);
                    return StatusCode(StatusCodes.Status201Created, user);
                }
                else
                {
                    return StatusCode(StatusCodes.Status501NotImplemented, response);
                }
        }

        [HttpPost("Login")]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            if (ModelState.IsValid == false)
            {
                return StatusCode(StatusCodes.Status400BadRequest, "Bad request!!");
            }

            IApiResponse<dynamic> response = await _authService.Login(request.emailId, request.password);
            if (response.IsSuccess)
            {
                var loginResponse = response.Response;

                List<UserModel> usersList = await _userService.ReadAsync();
                UserModel? user = usersList.Find(u => u.UserId == loginResponse.UserId);
                if (user == null)
                {
                    return StatusCode(StatusCodes.Status401Unauthorized);
                }

                // Set the cookies with the tokens
                var authCookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Set to true if using HTTPS
                    SameSite = SameSiteMode.None,
                };

                var refreshCookieOptions = new CookieOptions
                {
                    HttpOnly = true,
                    Secure = true, // Set to true if using HTTPS
                    SameSite = SameSiteMode.None,
                };

                var permissionCookieOptions = new CookieOptions
                {
                    SameSite = SameSiteMode.None,
                };

                Response.Cookies.Append("AuthToken", loginResponse?.JwtAuthToken ?? "", authCookieOptions);
                Response.Cookies.Append("RefreshToken", loginResponse?.RefreshToken ?? "", refreshCookieOptions);
                Response.Cookies.Append("Permissions", string.Join(",", loginResponse?.Permissions));

                return StatusCode(StatusCodes.Status200OK, user);
            }

            return StatusCode(StatusCodes.Status401Unauthorized, response);
        }
        [HttpGet("GetAllUsers")]
        [Authorize(Policy = "ViewUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserModel> response = await _userService.ReadAsync();
            return StatusCode(StatusCodes.Status200OK, response);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest role)
        {
            IApiResponse<string> response = await _identityService.CreateRole(role.Role);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("GetAllRoles")]
        public async Task<IActionResult> GetAllRoles()
        {
            IApiResponse<List<string>> response = await _identityService.GetAllRoles();

            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpPost("AssignRoleToUser")]
        [Authorize(Policy = "RoleOrPolicy")]
        public async Task<IActionResult> AssignRoleToUser([FromBody] AssignRoleRequest request)
        {
            IApiResponse<string> response = await _identityService.AssignRoleToUser(request.emailId, request.role);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("GetRolesForUser")]
        public async Task<IActionResult> GetRolesForUser(string emailId)
        {
            IApiResponse<List<string>> response = await _identityService.GetRolesForUser(emailId);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }
        
        [HttpPut("UpdateRoleForUser")]
        public async Task<IActionResult> UpdateRoleForUser([FromBody] AssignRoleRequest request)
        {
            IApiResponse<string> response = await _identityService.UpdateRoleForUser(request.emailId, request.role);
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
            IApiResponse<string> response = await _identityService.AddClaimForUser(request.emailId, request.claimName, request.claimValue);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpPost("AddClaimsForUser")]
        [Authorize(Policy = "RolePolicy")]
        public async Task<IActionResult> AddClaimsForUser([FromBody] AddMultipleClaimsForUserRequest request)
        {
            IApiResponse<string> response = await _identityService.AddClaimsForUser(request.emailId, request.claims);
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
            IApiResponse<string> response = await _identityService.AddClaimForRole(emailId, claimValue);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpGet("GetClaimsForUser")]
        public async Task<IActionResult> GetClaimsForUser(string emailId)
        {
            IApiResponse<List<Claim>> response = await _identityService.GetClaimsForUser(emailId);
            if (response.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, response);
            }
            return StatusCode(StatusCodes.Status501NotImplemented, response);
        }

        [HttpPost("GenerateOTP")]
        public async Task<IActionResult> GenerateOtp([FromBody] OtpRequest request)
        {
            string otp = await _otpService.GenerateOtp(request.Email);

            DateTime generatedTime = DateTime.Now;
            string formattedTime = generatedTime.ToString("hh:mm tt");
            int otpValidityMinutes = 10;
            string messageBody = $@"You have requested for a new OTP to login to the Arihant CRM Application.
Enter the following OTP to proceed
OTP: {otp}
(This OTP is generated at {formattedTime} and is valid for the next {otpValidityMinutes} minutes)";

            await _emailService.SendEmailAsync(request.Email, "OTP for login - Arihant CRM Application", messageBody);

            return Ok(new { message = "OTP sent to your email" });
            
        }

        [HttpPost("ValidateOTP")]
        public async Task<IActionResult> ValidateOtp([FromBody] OtpValidationRequest request)
        {
            var isValid = await _otpService.ValidateOtp(request.Email, request.Otp);
            if (isValid)
            {

                await _userService.UpdateLastLoginTime(request.Email);
                return StatusCode(StatusCodes.Status200OK, new { message = "OTP is valid." });
            }
            return StatusCode(StatusCodes.Status501NotImplemented, new { message = "Invalid or expired OTP." });
        }
    }
}
