﻿using Microsoft.AspNetCore.Identity;
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

        public async Task<IApiResponse<string>> CreateUser(string emailId, string userName, string password, string role, int userId)
        {
            CrmIdentityUser? existingUser = await _userManager.FindByNameAsync(userName);
            if (existingUser != null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User Already Exists!!" };
            }
            CrmIdentityUser newUser = new()
            {
                UserId = userId,
                Email = emailId,
                UserName = userName,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, password);
            if (result.Succeeded)
            {
                IApiResponse<string>? roleAssignResponse = await AssignRoleToUser(userName, role);
                if (roleAssignResponse.IsSuccess)
                {
                    //SecurityToken jwtSecurityToken = await GenerateJwtAuthSecurityToken(newUser);
                    //string jwtAuthToken = GenerateJwtAuthToken(jwtSecurityToken);
                    //string? refreshToken = await GenerateRefreshToken(jwtSecurityToken.Id, newUser.Id);
                    //await transaction.CommitAsync();
                    CrmIdentityUser? newCreatedUser = await _userManager.FindByNameAsync(userName);
                    return new IApiResponse<string> { IsSuccess = true, StatusCode = 201, Response = newCreatedUser.Id };
                }
                else
                {
                    await _userManager.DeleteAsync(newUser);
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

        public async Task<IApiResponse<string>> AssignRoleToUser(string userName, string roleToBeAssigned)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByNameAsync(userName);
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

        public async Task<IApiResponse<List<Claim>>> GetClaimsForUser(string userName)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByNameAsync(userName);
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

        public async Task<IApiResponse<string>> AddClaimsForUser(string userName, List<KeyValuePair<string, string>> claims)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByNameAsync(userName);
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

        public async Task<IApiResponse<string>> DeleteRole(string roleName)
        {
            IdentityRole role = await _roleManager.FindByNameAsync(roleName);
            if (role == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 404, Response = "Role not found for deletion!" };
            }

            IdentityResult result = await _roleManager.DeleteAsync(role);
            if (result.Succeeded)
            {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 200, Response = "Role deleted successfully!" };
            }

            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to delete role!" };
        }

        public async Task<IApiResponse<string>> UpdateUserDetails(string userId, string emailId, string password, string userName, string newRole)
        {
            CrmIdentityUser user = await _userManager.FindByIdAsync(userId);
            if (user == null)
            {
                return new IApiResponse<string>
                {
                    IsSuccess = false,
                    StatusCode = 404,
                    Response = "User not found!"
                };
            }

            using (var transaction = await _adminDbContext.Database.BeginTransactionAsync())
            {
                try
                {
                    // Update Email if needed
                    if (!string.IsNullOrWhiteSpace(emailId) && !user.Email.Equals(emailId, StringComparison.OrdinalIgnoreCase))
                    {
                        user.Email = emailId;
                        IdentityResult emailUpdateResult = await _userManager.UpdateAsync(user);
                        if (!emailUpdateResult.Succeeded)
                        {
                            await transaction.RollbackAsync();
                            return new IApiResponse<string>
                            {
                                IsSuccess = false,
                                StatusCode = 400,
                                Response = "Failed to update email!"
                            };
                        }
                    }

                    // Update Username if needed
                    if (!string.IsNullOrWhiteSpace(userName) && !user.UserName.Equals(userName, StringComparison.OrdinalIgnoreCase))
                    {
                        user.UserName = userName;
                        IdentityResult usernameUpdateResult = await _userManager.UpdateAsync(user);
                        if (!usernameUpdateResult.Succeeded)
                        {
                            await transaction.RollbackAsync();
                            return new IApiResponse<string>
                            {
                                IsSuccess = false,
                                StatusCode = 400,
                                Response = "Failed to update username!"
                            };
                        }
                    }

                    // Update Role if needed
                    if (!string.IsNullOrWhiteSpace(newRole))
                    {
                        var userRoles = await _userManager.GetRolesAsync(user);
                        if (!userRoles.Contains(newRole, StringComparer.OrdinalIgnoreCase))
                        {
                            // Remove old roles
                            IdentityResult removeRolesResult = await _userManager.RemoveFromRolesAsync(user, userRoles);
                            if (!removeRolesResult.Succeeded)
                            {
                                await transaction.RollbackAsync();
                                return new IApiResponse<string>
                                {
                                    IsSuccess = false,
                                    StatusCode = 400,
                                    Response = "Failed to remove old roles!"
                                };
                            }

                            // Add the new role
                            IdentityResult addRoleResult = await _userManager.AddToRoleAsync(user, newRole);
                            if (!addRoleResult.Succeeded)
                            {
                                await transaction.RollbackAsync();
                                return new IApiResponse<string>
                                {
                                    IsSuccess = false,
                                    StatusCode = 400,
                                    Response = "Failed to assign new role!"
                                };
                            }
                        }
                    }

                    if (!string.IsNullOrWhiteSpace(password))
                    {
                        IdentityResult passwordUpdateResult = await _userManager.RemovePasswordAsync(user);
                        if (passwordUpdateResult.Succeeded)
                        {
                            passwordUpdateResult = await _userManager.AddPasswordAsync(user, password);
                        }

                        if (!passwordUpdateResult.Succeeded)
                        {
                            await transaction.RollbackAsync();
                            return new IApiResponse<string>
                            {
                                IsSuccess = false,
                                StatusCode = 400,
                                Response = "Failed to update password!"
                            };
                        }
                    }

                    await transaction.CommitAsync();
                    return new IApiResponse<string>
                    {
                        IsSuccess = true,
                        StatusCode = 200,
                        Response = "User details updated successfully!"
                    };
                }
                catch (Exception ex)
                {
                    await transaction.RollbackAsync();
                    return new IApiResponse<string>
                    {
                        IsSuccess = false,
                        StatusCode = 500,
                        Response = $"An error occurred: {ex.Message}"
                    };
                }
            }
        }

        public async Task<IApiResponse<string>> DeleteUser(string userName)
        {
            try
            {
                CrmIdentityUser user = await _userManager.FindByNameAsync(userName);
                if (user == null)
                {
                    return new IApiResponse<string>
                    {
                        IsSuccess = false,
                        StatusCode = 404,
                        Response = "User not found!"
                    };
                }
                user.IsDeactivated = true;
                IdentityResult emailUpdateResult = await _userManager.UpdateAsync(user);
                return new IApiResponse<string>
                {
                    IsSuccess = true,
                    StatusCode = 200,
                    Response = "User deleted successfully!"
                };
            }
            catch (Exception ex) 
            {
                return new IApiResponse<string>
                {
                    IsSuccess = false,
                    StatusCode = 500,
                    Response = $"An error occurred: {ex.Message}"
                };
            }
        }
        public async Task<IApiResponse<List<UserClaimsResponse>>> GetAllUsersWithClaims(List<string> userNameList, List<string> claims)
        {
            List<UserClaimsResponse> userClaimsList = new List<UserClaimsResponse>();
            foreach (var userName in userNameList)
            {
                var userClaimsResponse = await GetClaimsForUser(userName);
                var userClaims = userClaimsResponse.Response;
                // Filter user claims based on input claims
                var matchedClaims = userClaims
                    .Where(c => claims.Contains(c.Value))
                    .ToList();

                if (matchedClaims.Any())
                {
                    userClaimsList.Add(new UserClaimsResponse
                    {
                        UserName = userName,
                        Claims = matchedClaims.Select(c => new ClaimResponse
                        {
                            ClaimType = c.Type,
                            ClaimValue = c.Value
                        }).ToList()
                    });
                }
            }

            return new IApiResponse<List<UserClaimsResponse>>
            {
                IsSuccess = true,
                StatusCode = 200,
                Response = userClaimsList
            };
        }


    }
}