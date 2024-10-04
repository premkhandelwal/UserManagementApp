﻿using Crm.Admin.Data;
using Crm.Admin.Data.Models;
using Crm.Admin.Service.Models;
using CRM.Admin.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace Crm.Admin.Service.Services
{
    public class AuthService
    {
        private readonly UserManager<CrmIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly TokenService _tokenService; // New TokenService instance

        public AuthService(UserManager<CrmIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptionsMonitor<JwtConfig> optionsMonitor,  TokenService tokenService)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _tokenService = tokenService; // Initialize the TokenService
        }

        public async Task<IApiResponse<dynamic>> Login(string emailId, string password)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByEmailAsync(emailId);
            if (applicationUser == null)
            {
                return new IApiResponse<dynamic> { IsSuccess = false, StatusCode = 400, Response = "User not found!!" };
            }

            bool isCorrect = await _userManager.CheckPasswordAsync(applicationUser, password);
            if (!isCorrect)
            {
                return new IApiResponse<dynamic> { IsSuccess = false, StatusCode = 401, Response = "Invalid email address or password!!" };
            }

            SecurityToken jwtSecurityToken = await _tokenService.GenerateJwtAuthSecurityToken(applicationUser);
            string jwtAuthToken = _tokenService.GenerateJwtAuthToken(jwtSecurityToken);
            string refreshToken = await _tokenService.GenerateRefreshToken(jwtSecurityToken.Id, applicationUser.Id);
            List<Claim> claims = await _tokenService.GetAllValidClaimsForUser(applicationUser);

            var permissions = claims.Select(c => c.Value).ToList(); // Assuming claims contain the permissions.

            var loginResponse = new LoginResponse
            {
                UserId = applicationUser.Id,
                JwtAuthToken = jwtAuthToken,
                RefreshToken = refreshToken,
                Permissions = permissions
            };

            return new IApiResponse<dynamic> { IsSuccess = true, StatusCode = 201, Response = loginResponse };
        }

    }
}
