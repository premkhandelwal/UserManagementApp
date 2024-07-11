using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagementData;
using UserManagementService.Models;

namespace UserManagementService
{
    public class UserManagement
    {
        private UserManager<ApplicationUser> _userManager;
        private RoleManager<IdentityRole> _roleManager;

        public UserManagement(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public async Task<IApiResponse<string>> CreateUser(IUser registerUser)
        {
            ApplicationUser? existingUser = await _userManager.FindByEmailAsync(registerUser.Email);
            if(existingUser != null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User Already Exists!!" };
            }
            ApplicationUser newUser = new()
            {
                Email = registerUser.Email,
                UserName = registerUser.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registerUser.Password);
            if (result.Succeeded) 
            {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 201, Response = "User Created Successfully!!" };
            }
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to create user!!" };

        }

        public async Task<IApiResponse<List<ApplicationUser>>> GetAllUsers()
        {
           List<ApplicationUser> applicationUsersList = await _userManager.Users.ToListAsync();
            if (applicationUsersList != null)
            {
                return new IApiResponse<List<ApplicationUser>> { IsSuccess = true, StatusCode = 200, Response = applicationUsersList };
            }
            return new IApiResponse<List<ApplicationUser>> { IsSuccess = false, StatusCode = 501, Response = null };

        }

        public async Task<IApiResponse<string>> CreateRole(string role)
        {
            bool roleExists = await _roleManager.RoleExistsAsync(role);
            if (roleExists)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "Role Already Exists!!" };
            }
            IdentityResult result =  await _roleManager.CreateAsync(new IdentityRole(role));
            if (result.Succeeded) {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 201, Response = "Role Created Successfully!!" };
            }
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to create role!!" };
        }

        public async Task<IApiResponse<List<IdentityRole>>> GetAllRoles()
        {
            List<IdentityRole> applicationRolesList = await _roleManager.Roles.ToListAsync();
            if (applicationRolesList != null)
            {
                return new IApiResponse<List<IdentityRole>> { IsSuccess = true, StatusCode = 200, Response = applicationRolesList };
            }
            return new IApiResponse<List<IdentityRole>> { IsSuccess = false, StatusCode = 501, Response = null };

        }

        public async Task<IApiResponse<string>> AssignRoleToUser(string userEmail, string roleToBeAssigned)
        {
            ApplicationUser applicationUser  = await _userManager.FindByEmailAsync(userEmail);
            if(applicationUser == null)
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
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
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

        public async Task<IApiResponse<List<Claim>>> GetClaimsForUser(string userEmail)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if(applicationUser == null)
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
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
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

        public async Task<IApiResponse<string>> AddClaimForRole(string userEmail, string claimValue)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User not found!!" };
            }
            IdentityResult result = await _userManager.AddClaimAsync(applicationUser, new Claim(ClaimTypes.Role, claimValue));
            if (result.Succeeded)
            {
                return new IApiResponse<string> { IsSuccess = true, StatusCode = 200, Response = "Claim added successfully" };
            }
            return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Failed to add claim" };
        }
    }
}