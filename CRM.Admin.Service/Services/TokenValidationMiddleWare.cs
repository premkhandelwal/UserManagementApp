using Crm.Admin.Service.Services;
using CRM.Admin.Service.Models;
using Microsoft.AspNetCore.Http;
using System;
using System.Threading.Tasks;

namespace CRM.Admin.Service.Services
{
    public class TokenValidationMiddleware
    {
        private readonly RequestDelegate _next;

        public TokenValidationMiddleware(RequestDelegate next)
        {
            _next = next;
        }


        public async Task Invoke(HttpContext context, TokenService tokenService)
        {
            if (context.Request.Path.StartsWithSegments("/api/Auth/Login"))
            {
                // Skip doing anything in this middleware and continue as usual
                await _next(context);
                return;
            }

            var accessToken = context.Request.Cookies["AuthToken"];
            var refreshToken = context.Request.Cookies["RefreshToken"];

            // Check if both tokens exist
            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
            {
                // Attempt to refresh the token
                TokenRefreshResponse tokenResponse = tokenService.CheckTokenStatus(accessToken, refreshToken);

                // Handle the token response based on the status
                switch (tokenResponse.Status)
                {
                    case TokenRefreshStatus.Success:
                        // Attach the new access token to the request headers
                        context.Request.Headers["Authorization"] = $"Bearer {tokenResponse.AuthToken}";
                        break;

                    case TokenRefreshStatus.TokenExpired:
                        TokenRefreshResponse res = await tokenService.RefreshToken(accessToken, refreshToken);
                        if (res.IsSuccess)
                        {
                            context.Request.Headers["Authorization"] = $"Bearer {res.AuthToken}";
                        }
                        break;

                    case TokenRefreshStatus.TokenNotYetExpired:
                        // Access token is valid; proceed with the request
                        break;

                    case TokenRefreshStatus.TokenDoesNotExist:
                    case TokenRefreshStatus.TokenHasBeenUsed:
                    case TokenRefreshStatus.TokenHasBeenRevoked:
                    case TokenRefreshStatus.TokenDoesNotMatch:
                        // Invalid refresh token; reject request
                        context.Response.StatusCode = 401;
                        await context.Response.WriteAsync("Session expired. Please log in again.");
                        return;

                    case TokenRefreshStatus.InvalidTokenAlgorithm:
                    case TokenRefreshStatus.TokenExpiryTimeNotFound:
                    case TokenRefreshStatus.GeneralError:
                        // Handle other errors
                        context.Response.StatusCode = 500; // Internal Server Error
                        await context.Response.WriteAsync("An error occurred during token validation.");
                        return;
                }
            }

            // If no tokens are present or the tokens are valid, proceed with the request
            await _next(context);
        }

        private void SetHttpOnlyCookie(HttpContext context, string key, string value, DateTime expiry)
        {
            var cookieOptions = new CookieOptions
            {
                HttpOnly = true,
                Secure = true,
                SameSite = SameSiteMode.Strict,
                Expires = expiry
            };
            context.Response.Cookies.Append(key, value, cookieOptions);
        }
    }
}
