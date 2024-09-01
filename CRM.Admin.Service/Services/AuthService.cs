using Crm.Admin.Data;
using Crm.Admin.Data.Models;
using Crm.Admin.Service.Models;
using CRM.Admin.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Crm.Admin.Service.Services
{
    public class AuthService
    {
        private readonly UserManager<CrmIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtConfig _jwtConfig;
        private readonly AdminDbContext _adminDbContext;
        private readonly TokenValidationParameters _tokenValidationParameters;

        public AuthService(UserManager<CrmIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptionsMonitor<JwtConfig> optionsMonitor, AdminDbContext adminDbContext, TokenValidationParameters tokenValidationParameters)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _adminDbContext = adminDbContext;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<TokenResponse<string>> Login(string emailId, string password)
        {
            CrmIdentityUser applicationUser = await _userManager.FindByEmailAsync(emailId);
            if (applicationUser == null)
            {
                return new TokenResponse<string> { IsSuccess = false, StatusCode = 400, Response = "User not found!!" };
            }
            bool isCorrect = await _userManager.CheckPasswordAsync(applicationUser, password);
            if (isCorrect == false)
            {
                return new TokenResponse<string> { IsSuccess = false, StatusCode = 401, Response = "Invalid email address or password!!" };
            }

            SecurityToken jwtSecurityToken = await GenerateJwtAuthSecurityToken(applicationUser);
            string jwtAuthToken = GenerateJwtAuthToken(jwtSecurityToken);
            string? refreshToken = await GenerateRefreshToken(jwtSecurityToken.Id, applicationUser.Id);
            return new TokenResponse<string> { IsSuccess = true, StatusCode = 201,  Response = applicationUser.Id, AuthToken = jwtAuthToken, RefreshToken = refreshToken };
        }

        public async Task<IApiResponse<string>> RefreshToken(string authToken, string refreshToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            try
            {
                ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(authToken, _tokenValidationParameters, out SecurityToken validatedToken);
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    bool result = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (result == false)
                    {
                        return new IApiResponse<string> { IsSuccess = false, StatusCode = 501 };
                    }
                }
                string? utcExpiryTime = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)?.Value;
                if (utcExpiryTime == null)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501 };
                }
                long timeStamp = long.Parse(utcExpiryTime);
                DateTime expiryDate = ParseDateTime(timeStamp);
                if (expiryDate > DateTime.Now)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Token not yet expired!!" };
                }
                RefreshToken? storedToken = _adminDbContext.RefreshTokens?.FirstOrDefault(x => x.Token == refreshToken);
                if (storedToken == null)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Token does not exist!!" };
                }
                if (storedToken.IsUsed)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Token has been used!!" };
                }
                if (storedToken.IsRevoked)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Token has been revoked!!" };
                }
                string? jti = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                if (storedToken.JwtId != jti)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Token does not match!!" };
                }
                storedToken.IsUsed = true;
                _adminDbContext.RefreshTokens?.Update(storedToken);
                await _adminDbContext.SaveChangesAsync();

                CrmIdentityUser applicationUser = await _userManager.FindByIdAsync(storedToken.UserId);

                SecurityToken newJwtSecurityToken = await GenerateJwtAuthSecurityToken(applicationUser);
                string newJwtAuthToken = GenerateJwtAuthToken(newJwtSecurityToken);
                string? newRefreshToken = await GenerateRefreshToken(newJwtSecurityToken.Id, applicationUser.Id);
                return new TokenResponse<string> { IsSuccess = true, StatusCode = 201, Response = "Success", AuthToken = newJwtAuthToken, RefreshToken = newRefreshToken };
            }
            catch (Exception)
            {

                return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Something went wrong!!" }; ;
            }
        }

        async private Task<SecurityToken> GenerateJwtAuthSecurityToken(CrmIdentityUser identityUser)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            List<Claim> claims = await GetAllValidClaimsForUser(identityUser);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.Now.AddSeconds(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),

            };
            SecurityToken securityToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            return securityToken;
        }

        private string GenerateJwtAuthToken(SecurityToken securityToken)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            string jwtToken = jwtTokenHandler.WriteToken(securityToken);
            return jwtToken;
        }

        private DateTime ParseDateTime(long timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timeStamp);
            return dateTime;
        }

        async private Task<string?> GenerateRefreshToken(string authTokenId, string userId)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                JwtId = authTokenId,
                IsUsed = false,
                IsRevoked = false,
                AddedDate = DateTime.Now,
                ExpiryDate = DateTime.Now.AddMonths(6),
                UserId = userId,
                Token = GenerateRandomString(35) + Guid.NewGuid(),
            };
            if (_adminDbContext.RefreshTokens != null)
            {
                await _adminDbContext.RefreshTokens.AddAsync(refreshToken);
                await _adminDbContext.SaveChangesAsync();
                return refreshToken.Token;
            }
            return null;
        }

        private string GenerateRandomString(int length)
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
        }

        public async Task<List<Claim>> GetAllValidClaimsForUser(CrmIdentityUser user)
        {
            IdentityOptions options = new IdentityOptions();

            //All default claims which were being passed to token
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()) //Identification for the user. Passed when creating the token
            };
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            //Get roles assigned to the user: string
            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                //Get IdentityRole object from role name
                IdentityRole identityRole = await _roleManager.FindByNameAsync(userRole);
                if (identityRole != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    //Get all claims for the current role
                    var roleClaims = await _roleManager.GetClaimsAsync(identityRole);
                    foreach (var roleClaim in roleClaims)
                    {
                        if (claims.Contains(roleClaim) == false)
                        {
                            claims.Add(roleClaim);
                        }
                    }
                }
            }
            return claims;
        }
    }
}
