using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using System.Security.Claims;
using Crm.Admin.Data;
using Crm.Admin.Service.Models;
using Crm.Admin.Data.Models;
using CRM.Admin.Service.Models;

namespace Crm.Admin.Service.Services
{
    public class IdentityService
    {
        private readonly UserManager<CrmIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly AdminDbContext _adminDbContext;

        public IdentityService(UserManager<CrmIdentityUser> userManager, RoleManager<IdentityRole> roleManager, AdminDbContext adminDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminDbContext = adminDbContext;
        }

        public async Task<IApiResponse<string>> CreateUser(string emailId, string userName, string password, string role)
        {
            CrmIdentityUser? existingUser = await _userManager.FindByEmailAsync(emailId);
            if (existingUser != null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User Already Exists!!" };
            }
            CrmIdentityUser newUser = new()
            {
                Email = emailId,
                UserName = userName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                IApiResponse<string>? roleAssignResponse = await AssignRoleToUser(emailId, role);
                if (roleAssignResponse.IsSuccess)
                {
                    //SecurityToken jwtSecurityToken = await GenerateJwtAuthSecurityToken(newUser);
                    //string jwtAuthToken = GenerateJwtAuthToken(jwtSecurityToken);
                    //string? refreshToken = await GenerateRefreshToken(jwtSecurityToken.Id, newUser.Id);
                    //await transaction.CommitAsync();
                    CrmIdentityUser? newCreatedUser = await _userManager.FindByEmailAsync(emailId);
                    return new IApiResponse<string> { IsSuccess = true, StatusCode = 201, Response = newCreatedUser.Id };
                }
                else
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 500, Response = roleAssignResponse.Response };
                }
            }
            await _userManager.DeleteAsync(newUser);
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 500, Response = "Failed to assign role, user creation failed" };
        }

        

        public async Task<IApiResponse<string>> CreateRole(string role)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(role);
            if (roleExists)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "Role Already Exists!!" };
            }
            IdentityResult result = await _roleManager.CreateAsync(new IdentityRole(role));
            if (result.Succeeded)
            {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 201, Response = "Role Created Successfully!!" };
            }
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to create role!!" };
        }

        public async Task<IApiResponse<List<string>>> GetAllRoles()
        {
            List<string> roleNames = await _roleManager.Roles.Select(r => r.Name).ToListAsync();
            if (roleNames != null)
            {
                
                return new IApiResponse<List<string>> { IsSuccess = true, StatusCode = 200, Response = roleNames };
            }
            return new IApiResponse<List<string>> { IsSuccess = false, StatusCode = 501, Response = null };

        }

        public async Task<IApiResponse<string>> AssignRoleToUser(string userEmail, string roleToBeAssigned)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User Not Found!!" };
            }
            IdentityRole identityRole = await _roleManager.FindByNameAsync(roleToBeAssigned);
            if (identityRole == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "Role Not Found!!" };
            }
            IdentityResult result = await _userManager.AddToRoleAsync(applicationUser, roleToBeAssigned);
            if (result.Succeeded)
            {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 200, Response = "Role assigned to user!!" };
            }
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to assign role to user" };

        }

        public async Task<IApiResponse<List<string>>> GetRolesForUser(string userEmail)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                return new IApiResponse<List<string>> { IsSuccess = false, StatusCode = 401, Response = null };
            }

            IList<string> roles = await _userManager.GetRolesAsync(applicationUser);
            return new IApiResponse<List<string>>
            {
                IsSuccess = true,
                Response = roles.ToList(),
                StatusCode = 200
            };
        }

        public async Task<IApiResponse<string>> UpdateRoleForUser(string emailId, string newRole)
        {
            using var transaction = _adminDbContext.Database.BeginTransaction();

            CrmIdentityUser user = await _userManager.FindByEmailAsync(emailId);
            IList<string> rolesForUser = await _userManager.GetRolesAsync(user);
            string? currRole = rolesForUser.FirstOrDefault();
            if (currRole != null)
            {
                IdentityResult removeResult = await _userManager.RemoveFromRoleAsync(user, currRole);
                if (removeResult.Succeeded == false)
                {
                    await transaction.RollbackAsync();
                    return new IApiResponse<string>() { IsSuccess = false, StatusCode = 501, Response = "Failed to update role!!" };
                }
            }
            IdentityResult addResult = await _userManager.AddToRoleAsync(user, newRole);
            if (addResult.Succeeded)
            {
                await transaction.CommitAsync();
                return new IApiResponse<string>() { IsSuccess = true, StatusCode = 200, Response = "Updated role successfully!!" };
            }
            await transaction.RollbackAsync();
            return new IApiResponse<string>() { IsSuccess = false, StatusCode = 501, Response = "Failed to update role!!" };
        }

        public async Task<IApiResponse<List<Claim>>> GetClaimsForUser(string userEmail)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                return new IApiResponse<List<Claim>> { IsSuccess = false, StatusCode = 401, Response = null };
            }
            IList<Claim> claims = await _userManager.GetClaimsAsync(applicationUser);
            return new IApiResponse<List<Claim>>
            {
                IsSuccess = true,
                Response = claims.ToList(),
                StatusCode = 200
            };
        }

        public async Task<IApiResponse<string>> AddClaimForUser(string userEmail, string claimName, string claimValue)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User not found!!" };
            }
            IdentityResult result = await _userManager.AddClaimAsync(applicationUser, new Claim(claimName, claimValue));
            if (result.Succeeded)
            {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 200, Response = "Claim added successfully" };
            }
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to add claim" };
        }

        public async Task<IApiResponse<string>> AddClaimsForUser(string userEmail, List<KeyValuePair<string, string>> claims)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User not found!" };
            }

            using (var transaction = await _adminDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    var existingClaims = await _userManager.GetClaimsAsync(applicationUser);
                    IdentityResult removeResult = await _userManager.RemoveClaimsAsync(applicationUser, existingClaims);
                    if (!removeResult.Succeeded)
                    {
                        await transaction.RollbackAsync();
                        return new IApiResponse<string> { IsSuccess = false, StatusCode = 500, Response = "Failed to add claims" };
                    }

                    List<Claim> claimsList = new List<Claim>();
                    claims.ForEach((entry) => claimsList.Add(new Claim(entry.Key, entry.Value)));

                    IdentityResult addResult = await _userManager.AddClaimsAsync(applicationUser, claimsList);
                    if (addResult.Succeeded)
                    {
                        await transaction.CommitAsync();
                        return new IApiResponse<string> { IsSuccess = true, StatusCode = 200, Response = "Claims added successfully" };
                    }
                    else
                    {
                        await transaction.RollbackAsync();
                        return new IApiResponse<string> { IsSuccess = false, StatusCode = 500, Response = "Failed to add claims" };
                    }
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 500, Response = $"An error occurred: {ex.Message}" };
                }
            }
        }

        public async Task<IApiResponse<string>> AddClaimForRole(string roleName, string claimValue)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User not found!!" };
            }
            IdentityResult result = await _roleManager.AddClaimAsync(role, new Claim(ClaimTypes.Role, claimValue));
            if (result.Succeeded)
            {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 200, Response = "Claim added successfully" };
            }
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to add claim" };
        }

    }
}