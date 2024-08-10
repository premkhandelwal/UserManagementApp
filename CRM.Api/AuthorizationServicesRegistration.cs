using Microsoft.AspNetCore.CookiePolicy;

namespace CRM.Api
{
    public static class AuthorizationServicesRegistration
    {
        public static void AddAuthorizationServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddAuthorization(options =>
            {
                options.AddPolicy("RolePolicy",
                    policy => policy.RequireClaim("claimRole", new[]
                    {
            "admin"
                    }));

                options.AddPolicy("ViewUsers", policy => policy.RequireClaim("permissions", new[] { "ViewUsers" }));
                options.AddPolicy("UpdateUsers", policy => policy.RequireClaim("permissions", new[] { "UpdateUsers" }));
                options.AddPolicy("ViewQuotation", policy => policy.RequireClaim("permissions", new[] { "ViewQuotation" }));
                options.AddPolicy("UpdateQuotation", policy => policy.RequireClaim("permissions", new[] { "UpdateQuotation" }));


                options.AddPolicy("LimitedOrFull", policy =>
                   policy.RequireAssertion(context =>
                       context.User.HasClaim(c =>
                           (c.Type == "Limited" ||
                            c.Type == "Full"))));

                /*options.AddPolicy("RoleOrPolicy", policy =>
                    policy.Requirements.Add(new RoleOrPolicyRequirement("Tester", "RolePolicy")));*/

                services.Configure<CookiePolicyOptions>(options =>
                {
                    options.CheckConsentNeeded = context => true;
                    options.MinimumSameSitePolicy = SameSiteMode.Strict;
                    options.HttpOnly = HttpOnlyPolicy.Always;
                    options.Secure = CookieSecurePolicy.Always;
                    // you can add more options here and they will be applied to all cookies (middleware and manually created cookies)
                });
            });

        }
    }
}
