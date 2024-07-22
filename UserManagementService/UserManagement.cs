using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Data;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Text;
using System.Threading.Tasks;
using UserManagementApp;
using UserManagementApp.Models;
using UserManagementData;
using UserManagementService.Models;

namespace UserManagementService
{
    public class UserManagement
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        private readonly JwtConfig _jwtConfig;
        private readonly TokenValidationParameters _tokenValidationParameters;
        private readonly ApplicationDbContext _applicationDbContext;
        public UserManagement(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager, IOptionsMonitor<JwtConfig> optionsMonitor, TokenValidationParameters tokenValidationParameters, ApplicationDbContext applicationDbContext)
        {
            _userManager = userManager;
            _roleManager = roleManager;
            _jwtConfig = optionsMonitor.CurrentValue;
            _tokenValidationParameters = tokenValidationParameters;
            _applicationDbContext = applicationDbContext;

        }
        private string GenerateRandomString(int length) 
        {
            Random random = new Random();
            string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length).Select(x => x[random.Next(x.Length)]).ToArray());
        }   

        async private Task<SecurityToken> GenerateJwtAuthSecurityToken(ApplicationUser identityUser)
        {
            JwtSecurityTokenHandler jwtTokenHandler = new JwtSecurityTokenHandler();
            byte[] key = Encoding.ASCII.GetBytes(_jwtConfig.Secret);
            List<Claim> claims = await GetAllValidClaimsForUser(identityUser);
            SecurityTokenDescriptor tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(claims),
                Expires = DateTime.UtcNow.AddSeconds(30),
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

        async private Task<string?> GenerateRefreshToken(string authTokenId, string userId)
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
            if (_applicationDbContext.RefreshTokens != null)
            {
                await _applicationDbContext.RefreshTokens.AddAsync(refreshToken);
                await _applicationDbContext.SaveChangesAsync();
                return refreshToken.Token;
            }
            return null;
        }

        private DateTime ParseDateTime(long timeStamp)
        {
            DateTime dateTime = new DateTime(1970, 1, 1, 0, 0, 0, DateTimeKind.Utc);
            dateTime = dateTime.AddSeconds(timeStamp);
            return dateTime;
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
                        return new IApiResponse<string> { IsSuccess = false, StatusCode = 501};
                    }
                }
                string? utcExpiryTime = claimsPrincipal.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Exp)?.Value;
                if (utcExpiryTime == null)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501};
                }
                long timeStamp = long.Parse(utcExpiryTime);
                DateTime expiryDate = ParseDateTime(timeStamp);
                if (expiryDate > DateTime.UtcNow)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Token not yet expired!!" };
                }
                RefreshToken? storedToken = _applicationDbContext.RefreshTokens?.FirstOrDefault(x => x.Token == refreshToken);
                if(storedToken == null)
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
                if(storedToken.JwtId != jti)
                {
                    return new IApiResponse<string> { IsSuccess = false, StatusCode = 501, Response = "Token does not match!!" };
                }
                storedToken.IsUsed = true;
                _applicationDbContext.RefreshTokens?.Update(storedToken);
                await _applicationDbContext.SaveChangesAsync();
                
                ApplicationUser applicationUser = await _userManager.FindByIdAsync(storedToken.UserId);

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

        public async Task<TokenResponse<string>> CreateUser(IUser registerUser)
        {
            using var transaction = _applicationDbContext.Database.BeginTransaction();
            ApplicationUser? existingUser = await _userManager.FindByEmailAsync(registerUser.EmailId);
            if(existingUser != null)
            {
                return new TokenResponse<string> {  IsSuccess = false, StatusCode = 401, Response = "User Already Exists!!" };
            }
            ApplicationUser newUser = new()
            {
                Email = registerUser.EmailId,
                UserName = registerUser.Username,
                SecurityStamp = Guid.NewGuid().ToString(),
            };
            IdentityResult result = await _userManager.CreateAsync(newUser, registerUser.Password);
            if (result.Succeeded) 
            {
                IApiResponse<string>? roleAssignResponse = await AssignRoleToUser(registerUser.EmailId, registerUser.Role);
                if (roleAssignResponse.IsSuccess)
                {
                    SecurityToken jwtSecurityToken = await GenerateJwtAuthSecurityToken(newUser);
                    string jwtAuthToken = GenerateJwtAuthToken(jwtSecurityToken);
                    string? refreshToken = await GenerateRefreshToken(jwtSecurityToken.Id, newUser.Id);
                    await transaction.CommitAsync();

                    return new TokenResponse<string> { IsSuccess = true, StatusCode = 201, Response = "Success", AuthToken = jwtAuthToken, RefreshToken = refreshToken };
                }
                else
                {
                    return new TokenResponse<string> { IsSuccess = false, StatusCode = 500, Response = roleAssignResponse.Response};
                }
            }
            await _userManager.DeleteAsync(newUser);
            await transaction.RollbackAsync();
            return new TokenResponse<string> { IsSuccess = false, StatusCode = 500, Response = "Failed to assign role, user creation failed" };
        }

        public async Task<TokenResponse<string>> Login(string emailId, string password)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(emailId);
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
            return new TokenResponse<string> { IsSuccess = true, StatusCode = 201, Response = "Success", AuthToken = jwtAuthToken, RefreshToken = refreshToken };
        }

        public async Task<IApiResponse<List<IUser>>> GetAllUsers()
        {
           List<ApplicationUser> applicationUsersList = await _userManager.Users.ToListAsync();
            List<IUser> usersList = new List<IUser>();
            if (applicationUsersList != null)
            {
                foreach (var user in applicationUsersList)
                {
                    var roles = await _userManager.GetRolesAsync(user);
                    usersList.Add(new IUser()
                    {
                        
                        EmailId = user.Email,
                        Username = user.UserName,
                        Role = roles.FirstOrDefault() ?? ""
                    });
                }
                return new IApiResponse<List<IUser>> { IsSuccess = true, StatusCode = 200, Response = usersList };
            }
            return new IApiResponse<List<IUser>> { IsSuccess = false, StatusCode = 501, Response = null };

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

        public async Task<IApiResponse<string>> UpdateRoleForUser(string emailId, string newRole)
        {
            using var transaction = _applicationDbContext.Database.BeginTransaction();

            ApplicationUser user = await _userManager.FindByEmailAsync(emailId);
            IList<string> rolesForUser = await _userManager.GetRolesAsync(user);
            string? currRole = rolesForUser.FirstOrDefault();
            if(currRole != null)
            {
                IdentityResult removeResult = await _userManager.RemoveFromRoleAsync(user, currRole);
                if (removeResult.Succeeded == false)
                {
                    await transaction.RollbackAsync();
                    return new IApiResponse<string>() { IsSuccess = false, StatusCode = 501, Response = "Failed to update role!!"};
                }
            }
            IdentityResult addResult =  await _userManager.AddToRoleAsync(user, newRole);
            if (addResult.Succeeded) 
            {
                await transaction.CommitAsync();
                return new IApiResponse<string>() { IsSuccess = true, StatusCode = 200, Response = "Updated role successfully!!"};
            }
            await transaction.RollbackAsync();
            return new IApiResponse<string>() { IsSuccess = false, StatusCode = 501, Response = "Failed to update role!!" };
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

        public async Task<IApiResponse<string>> AddClaimsForUser(string userEmail, List<KeyValuePair<string, string>> claims)
        {
            ApplicationUser applicationUser = await _userManager.FindByEmailAsync(userEmail);
            if (applicationUser == null)
            {
                return new IApiResponse<string> { IsSuccess = false, StatusCode = 401, Response = "User not found!" };
            }

            using (var transaction = await _applicationDbContext.Database.BeginTransactionAsync())
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

        public async Task<List<Claim>> GetAllValidClaimsForUser(ApplicationUser user)
        {
            IdentityOptions options = new IdentityOptions();

            //All default claims which were being passed to token
            List<Claim> claims = new List<Claim>()
            {
                new Claim("Id", user.Id),
                new Claim(JwtRegisteredClaimNames.Email, user.Email),
                new Claim(JwtRegisteredClaimNames.Sub, user.Email),
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
                if(identityRole != null)
                {
                    claims.Add(new Claim(ClaimTypes.Role, userRole));

                    //Get all claims for the current role
                    var roleClaims = await _roleManager.GetClaimsAsync(identityRole);
                    foreach (var roleClaim in roleClaims) 
                    {
                        if(claims.Contains(roleClaim) == false)
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