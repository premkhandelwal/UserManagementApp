using Crm.Admin.Data;
using Crm.Admin.Data.Models;
using Crm.Admin.Service.Models;
using CRM.Admin.Service.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;

namespace Crm.Admin.Service.Services
{
    public class TokenService
    {
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly UserManager<CrmIdentityUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtConfig _jwtConfig;
        private readonly AdminDbContext _adminDbContext;


        public TokenService(UserManager<CrmIdentityUser> userManager, RoleManager<IdentityRole> roleManager, IOptionsMonitor<JwtConfig> optionsMonitor, TokenValidationParameters tokenValidationParameters, AdminDbContext adminDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _adminDbContext = adminDbContext;
            _jwtConfig = optionsMonitor.CurrentValue;
            _tokenValidationParameters = tokenValidationParameters;
        }

        public async Task<SecurityToken> GenerateJwtAuthSecurityToken(CrmIdentityUser identityUser)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            List<Claim> claims = await GetAllValidClaimsForUser(identityUser);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddMinutes(30),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256),
            };
            SecurityToken securityToken = jwtTokenHandler.CreateToken(tokenDescriptor);
            return securityToken;
        }

        public string GenerateJwtAuthToken(SecurityToken securityToken)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            string jwtToken = jwtTokenHandler.WriteToken(securityToken);
            return jwtToken;
        }

        public async Task<string?> GenerateRefreshToken(string authTokenId, string userId)
        {
            RefreshToken refreshToken = new RefreshToken()
            {
                JwtId = authTokenId,
                IsUsed = false,
                IsRevoked = false,
                AddedDate = DateTime.UtcNow,
                ExpiryDate = DateTime.UtcNow.AddMonths(6),
                UserId = userId,
                Token = GenerateRandomString(35) + Guid.NewGuid(),
            };
            _adminDbContext.RefreshTokens?.Update(refreshToken);
            await _adminDbContext.SaveChangesAsync();
            return refreshToken.Token; // Logic to save to database should remain in AuthService
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

            List<Claim> claims = new List<Claim>
            {
                new Claim("Id", user.UserId.ToString()),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.UserName),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };
            IList<Claim> userClaims = await _userManager.GetClaimsAsync(user);
            claims.AddRange(userClaims);

            IList<string> userRoles = await _userManager.GetRolesAsync(user);
            foreach (var userRole in userRoles)
            {
                IdentityRole identityRole = await _roleManager.FindByNameAsync(userRole);
                if (identityRole != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));
                    var roleClaims = await _roleManager.GetClaimsAsync(identityRole);
                    foreach (var roleClaim in roleClaims)
                    {
                        if (!claims.Contains(roleClaim))
                        {
                            claims.Add(roleClaim);
                        }
                    }
                }
            }
            return claims;
        }

        public ClaimsPrincipal GetClaimsPrincipal(string authToken, out SecurityToken validatedToken)
        {
            JwtSecurityTokenHandler tokenHandler = new JwtSecurityTokenHandler();
            ClaimsPrincipal claimsPrincipal = tokenHandler.ValidateToken(authToken, _tokenValidationParameters, out validatedToken);
            return claimsPrincipal;

        }

        public TokenRefreshResponse CheckTokenStatus(string authToken, string refreshToken)
        {
            try
            {
                ClaimsPrincipal claimsPrincipal = GetClaimsPrincipal(authToken, out SecurityToken validatedToken);

                // Check if the token is a valid JWT
                if (validatedToken is JwtSecurityToken jwtSecurityToken)
                {
                    bool isAlgorithmValid = jwtSecurityToken.Header.Alg.Equals(SecurityAlgorithms.HmacSha256, StringComparison.InvariantCultureIgnoreCase);
                    if (!isAlgorithmValid)
                    {
                        return new TokenRefreshResponse
                        {
                            IsSuccess = false,
                            Status = TokenRefreshStatus.InvalidTokenAlgorithm,
                            Message = "Invalid token algorithm."
                        };
                    }
                }

                // Get the expiry time from the claims
                string? utcExpiryTime = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)?.Value;
                if (utcExpiryTime == null)
                {
                    return new TokenRefreshResponse
                    {
                        IsSuccess = false,
                        Status = TokenRefreshStatus.TokenExpiryTimeNotFound,
                        Message = "Token expiry time not found."
                    };
                }

                long timeStamp = long.Parse(utcExpiryTime);
                DateTime expiryDate = ParseDateTime(timeStamp); // Adjust this method according to your implementation

                // Check if the token is expired
                if (expiryDate <= DateTime.UtcNow) // Use UtcNow for consistency
                {
                    return new TokenRefreshResponse
                    {
                        IsSuccess = false,
                        Status = TokenRefreshStatus.TokenExpired,
                        Message = "Token has expired."
                    };
                }

                // If everything is valid, you might want to return a success response or perform further checks
                return new TokenRefreshResponse
                {
                    IsSuccess = true,
                    Status = TokenRefreshStatus.Success,
                    Message = "Token is valid.",
                    AuthToken = authToken
                };
            }
            catch (Exception ex)
            {
                // Optionally log the exception message
                return new TokenRefreshResponse
                {
                    IsSuccess = false,
                    Status = TokenRefreshStatus.GeneralError,
                    Message = ex.Message // You might want to log the exception instead of returning it directly
                };
            }
        }




        public async Task<TokenRefreshResponse> RefreshToken(string authToken, string refreshToken)
        {
            var response = new TokenRefreshResponse(); // Create an instance to hold the response

            try
            {
                ClaimsPrincipal claimsPrincipal = GetClaimsPrincipal(authToken, out SecurityToken validatedToken);

                RefreshToken? storedToken = _adminDbContext.RefreshTokens?.FirstOrDefault(x => x.Token == refreshToken);
                if (storedToken == null)
                {
                    return new TokenRefreshResponse
                    {
                        IsSuccess = false,
                        Status = TokenRefreshStatus.TokenDoesNotExist,
                        Message = "Token does not exist."
                    };
                }
                if (storedToken.IsUsed)
                {
                    return new TokenRefreshResponse
                    {
                        IsSuccess = false,
                        Status = TokenRefreshStatus.TokenHasBeenUsed,
                        Message = "Token has been used."
                    };
                }
                if (storedToken.IsRevoked)
                {
                    return new TokenRefreshResponse
                    {
                        IsSuccess = false,
                        Status = TokenRefreshStatus.TokenHasBeenRevoked,
                        Message = "Token has been revoked."
                    };
                }

                string? jti = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Jti)?.Value;
                if (storedToken.JwtId != jti)
                {
                    return new TokenRefreshResponse
                    {
                        IsSuccess = false,
                        Status = TokenRefreshStatus.TokenDoesNotMatch,
                        Message = "Token does not match."
                    };
                }

                //storedToken.IsUsed = true;
               

                CrmIdentityUser applicationUser = await _userManager.FindByIdAsync(storedToken.UserId);

                SecurityToken newJwtSecurityToken = await GenerateJwtAuthSecurityToken(applicationUser);
                string newJwtAuthToken = GenerateJwtAuthToken(newJwtSecurityToken);
                string? newRefreshToken = await GenerateRefreshToken(newJwtSecurityToken.Id, applicationUser.Id);

                return new TokenRefreshResponse
                {
                    IsSuccess = true,
                    Status = TokenRefreshStatus.Success,
                    UserId = applicationUser.Id,
                    AuthToken = newJwtAuthToken,
                    RefreshToken = newRefreshToken
                };
            }
            catch
            {
                return new TokenRefreshResponse
                {
                    IsSuccess = false,
                    Status = TokenRefreshStatus.GeneralError,
                    Message = "An error occurred while refreshing the token."
                };
            }
        }



        private DateTime ParseDateTime(long timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timeStamp);
            return dateTime;
        }
    }
}
