using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;

namespace Crm.Api
{
    public static class AuthorizationServicesRegistration
    {
        public static void AddAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
        {
            /*services.Configure<CookiePolicyOptions>(options =>
            {
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.Strict;
                options.HttpOnly = HttpOnlyPolicy.Always;
                options.Secure = CookieSecurePolicy.Always;
                // you can add more options here and they will be applied to all cookies (middleware and manually created cookies)
            });*/
            services.AddScoped<IAuthorizationHandler, RoleOrPolicyHandler>();
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RolePolicy", policy => policy.RequireClaim("permissions", new[] { "UserManagementAccess" }));

                options.AddPolicy("ViewUsers", policy => policy.RequireClaim("permissions", new[] { "UserManagementAccess" }));
                options.AddPolicy("UpdateUsers", policy => policy.RequireClaim("permissions", new[] { "UpdateUsers" }));
                options.AddPolicy("ViewQuotation", policy => policy.RequireClaim("permissions", new[] { "ViewQuotation" }));
                options.AddPolicy("UpdateQuotation", policy => policy.RequireClaim("permissions", new[] { "UpdateQuotation" }));


                options.AddPolicy("LimitedOrFull", policy =>
                   policy.RequireAssertion(context =>
                       context.User.HasClaim(c =>
                           (c.Type == "Limited" ||
                            c.Type == "Full"))));

                options.AddPolicy("RoleOrPolicy", policy =>
                    policy.Requirements.Add(new RoleOrPolicyRequirement("Tester", "RolePolicy")));

                
            });

        }
    }
}
