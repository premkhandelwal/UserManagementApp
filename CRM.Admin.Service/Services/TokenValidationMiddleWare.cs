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
            if (context.Request.Path.StartsWithSegments("/api/Auth/Login") || context.Request.Path.StartsWithSegments("/api/Auth/CreateUser") || context.Request.Path.StartsWithSegments("/api/Auth/AddClaimForUser"))
            {
                // Skip doing anything in this middleware and continue as usual
                await _next(context);
                return;
            }

            var accessToken = context.Request.Cookies["AuthToken"];
            var refreshToken = context.Request.Cookies["RefreshToken"];

            if (string.IsNullOrEmpty(accessToken) || string.IsNullOrEmpty(refreshToken))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                context.Response.ContentType = "application/json";
                await context.Response.WriteAsync("{\"message\":\"Session expired. Please log in again.\"}");
                return;
            }

            // Check if both tokens exist
            if (!string.IsNullOrEmpty(accessToken) && !string.IsNullOrEmpty(refreshToken))
            {
                TokenRefreshResponse tokenResponse = tokenService.CheckTokenStatus(accessToken, refreshToken);

                switch (tokenResponse.Status)
                {
                    case TokenRefreshStatus.Success:
                        
                        context.Request.Headers["Authorization"] = $"Bearer {tokenResponse.AuthToken}";
                        break;

                    case TokenRefreshStatus.TokenExpired:
                        TokenRefreshResponse res = await tokenService.RefreshToken(accessToken, refreshToken);
                        if (res.IsSuccess)
                        {
                            context.Request.Headers["Authorization"] = $"Bearer {res.AuthToken}";
                            context.Response.Cookies.Delete("AuthToken");
                            context.Response.Cookies.Delete("RefreshToken");
                            context.Response.Cookies.Append("AuthToken", res.AuthToken ?? "");
                            context.Response.Cookies.Append("RefreshToken", res.RefreshToken ?? "");
                        }
                        else
                        {
                            context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                            context.Response.ContentType = "application/json";
                            await context.Response.WriteAsync("{\"message\":\"Token expired. Please log in again.\"}");
                            return;
                        }
                        break;

                    case TokenRefreshStatus.TokenNotYetExpired:
                        // Proceed with the request
                        break;

                    case TokenRefreshStatus.TokenDoesNotExist:
                    case TokenRefreshStatus.TokenHasBeenUsed:
                    case TokenRefreshStatus.TokenHasBeenRevoked:
                    case TokenRefreshStatus.TokenDoesNotMatch:
                        context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("{\"message\":\"Session expired. Please log in again.\"}");
                        return;

                    case TokenRefreshStatus.InvalidTokenAlgorithm:
                    case TokenRefreshStatus.TokenExpiryTimeNotFound:
                    case TokenRefreshStatus.GeneralError:
                        context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                        context.Response.ContentType = "application/json";
                        await context.Response.WriteAsync("{\"message\":\"An error occurred during token validation.\"}");
                        return;
                }
            }

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
