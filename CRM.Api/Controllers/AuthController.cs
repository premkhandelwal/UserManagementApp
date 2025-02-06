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
    [Authorize]
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
        public async Task<IActionResult> CreateUser([FromBody] CreateUserRequest registerUser)
        {
                UserModel? user = await _userService.CreateAsync(registerUser);

                if (user != null)
                {
                    IApiResponse<string> response = await _identityService.CreateUser(registerUser.EmailId, registerUser.Username, registerUser.Password, registerUser.Role, (int) user.Id!);
                    if (response.IsSuccess)
                    {
                        UpdateUserRequest req = new UpdateUserRequest()
                        {
                            Id = (int)user.Id,
                            AddedOn = user.AddedOn,
                            EmailId = user.EmailId,
                            Username = user.Username,
                            LastLogin = user.LastLogin,
                            MobileNo = user.MobileNo,
                            ModifiedOn = user.ModifiedOn,
                            Password = user.Password,
                            Role = user.Role,
                            UserId = response.Response!
                        };
                        await _userService.UpdateAsync(req);
                        return StatusCode(StatusCodes.Status201Created, req);
                
                    }
                }
                return BadRequest(new { message = "Failed to create user." }); ;
        }

        [HttpPost("UpdateUser")]
        public async Task<IActionResult> UpdateUser([FromBody] UpdateUserRequest updateUserRequest)
        {
            var previousUserDetails = _userService.GetById(updateUserRequest.Id);
            if (previousUserDetails == null)
            {
                return NotFound(new { message = "User not found in UserService." });
            }

            try
            {
                // Step 1: Update in UserService
                var userServiceUpdateResult = await _userService.UpdateAsync(updateUserRequest);
                if (userServiceUpdateResult == null)
                {
                    return BadRequest(new { message = "Failed to update user in UserService." });
                }

                // Step 2: Update in IdentityService
                var identityServiceUpdateResult = await _identityService.UpdateUserDetails(
                    updateUserRequest.UserId,
                    updateUserRequest.EmailId,
                    updateUserRequest.Password,
                    updateUserRequest.Username,
                    updateUserRequest.Role
                );

                if (!identityServiceUpdateResult.IsSuccess)
                {
                    throw new Exception("Failed to update user");
                }

                return Ok(new { message = "User updated successfully." });
            }
            catch (Exception ex)
            {
                // Rollback: Attempt to restore original user details
                await _userService.UpdateAsync(new UpdateUserRequest
                {
                    Id = (int)previousUserDetails.Id,
                    Username = previousUserDetails.Username,
                    EmailId = previousUserDetails.EmailId,
                    UserId = previousUserDetails.UserId,
                    Password = previousUserDetails.Password,
                    Role = previousUserDetails.Role,
                    MobileNo = previousUserDetails.MobileNo,
                    AddedOn = previousUserDetails.AddedOn,
                    ModifiedOn = previousUserDetails.ModifiedOn
                });

                return StatusCode(StatusCodes.Status500InternalServerError,
                    new { message = $"Failed to update user: {ex.Message}" });
            }
        }

        [HttpPost("DeleteUser")]
        public async Task<IActionResult> DeleteUser([FromBody] DeleteUserRequest deleteUserRequest)
        { 
            var userServiceDeleteRes = await _userService.DeleteUser(deleteUserRequest.EmailId);
            if (userServiceDeleteRes == false)
            {
                return BadRequest(new { message = "Failed to update user in UserService." });
            }
            var identityDeleteRes = await _identityService.DeleteUser(deleteUserRequest.EmailId);
            if (identityDeleteRes.IsSuccess)
            {
                return StatusCode(StatusCodes.Status200OK, identityDeleteRes);
            }
            return StatusCode(StatusCodes.Status400BadRequest, identityDeleteRes);
        }


        [HttpPost("Login")]
        [AllowAnonymous]
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

                await _userService.UpdateLastLoginTime(request.emailId);
                Response.Cookies.Append("AuthToken", loginResponse?.JwtAuthToken ?? "", authCookieOptions);
                Response.Cookies.Append("RefreshToken", loginResponse?.RefreshToken ?? "", refreshCookieOptions);
                return StatusCode(StatusCodes.Status200OK, user);

            }

            return StatusCode(StatusCodes.Status401Unauthorized, response);
        }

        [HttpGet("GetPermissions")]
        public async Task<IActionResult> GetPermissionsForUser(string emailId)
        {
            IApiResponse<dynamic> response = await _authService.GetPermissions(emailId);
            if (response.IsSuccess)
            {
                return StatusCode(response.StatusCode, response.Response);
            }
            return StatusCode(response.StatusCode, response);
        }

        [HttpGet("GetAllUsers")]
        [Authorize(Policy = "ViewUsers")]
        public async Task<IActionResult> GetAllUsers()
        {
            List<UserModel> response = await _userService.ReadAsync();
            List<UserModel> filteredUsers = response.Where(user => user.IsDeleted == false).ToList();
            return StatusCode(StatusCodes.Status200OK, filteredUsers);
        }

        [HttpPost("CreateRole")]
        public async Task<IActionResult> CreateRole([FromBody] CreateRoleRequest role)
        {
            if (role == null || string.IsNullOrEmpty(role.Role))
            {
                return BadRequest(new IApiResponse<string> { IsSuccess = false, StatusCode = 400, Response = "Invalid Role Data" });
            }

            // Call the service to create the role
            var createRoleResponse = await _identityService.CreateRole(role.Role);

            if (!createRoleResponse.IsSuccess)
            {
                return StatusCode(createRoleResponse.StatusCode, createRoleResponse);
            }

            // Add claim if IsAdmin is true
            if (role.IsAdmin)
            {
                var addClaimResponse = await _identityService.AddClaimForRole(role.Role, "adminRole");

                if (!addClaimResponse.IsSuccess)
                {
                    // Rollback the role creation if adding claim fails
                    await _identityService.DeleteRole(role.Role);
                    return StatusCode(addClaimResponse.StatusCode, new IApiResponse<string>
                    {
                        IsSuccess = false,
                        StatusCode = addClaimResponse.StatusCode,
                        Response = "Failed to add Admin claim! Role creation rolled back."
                    });
                }
            }

            return Ok(new IApiResponse<string> { IsSuccess = true, StatusCode = 201, Response = "Role created with claim successfully!" });
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
        public async Task<IActionResult> AddClaimForRole([FromBody] AddClaimForRoleRequest request)
        {
            IApiResponse<string> response = await _identityService.AddClaimForRole(request.roleName, request.claimValue);
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

                //await _userService.UpdateLastLoginTime(request.Email);
                return StatusCode(StatusCodes.Status200OK, new { message = "OTP is valid." });
            }
            return StatusCode(StatusCodes.Status501NotImplemented, new { message = "Invalid or expired OTP." });
        }
    }
}
