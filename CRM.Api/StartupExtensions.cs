using Crm.Tenant.Service;
using Crm.Admin.Data;
using Crm.Api;
using Crm.Admin.Service;
using CRM.Admin.Service.Services;
using Crm.Admin.Service.Services;

namespace Crm.Api
{
    public static class StartupExtensions
    {
        public static IServiceCollection ConfigureServices(
            this WebApplicationBuilder builder)
        {
            // Add services to the container
            builder.Services.AddAdminServices(builder.Configuration);
            builder.Services.AddTenantDataServices(builder.Configuration);
            builder.Services.AddTenantServices(builder.Configuration);
            builder.Services.AddAdminDataServices(builder.Configuration);
            builder.Services.AddAuthorizationServices(builder.Configuration);
            builder.Services.AddCors();
            builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Services; // Return the IServiceCollection
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200");
            });

            app.UseMiddleware<TokenValidationMiddleware>(); // Ensure this middleware is used
            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllers();

            // Security headers
            app.Use(async (context, next) =>
            {
                context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'nonce-random'; style-src 'self' 'nonce-random';");
                context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
                context.Response.Headers.Add("X-Frame-Options", "DENY");
                context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
                context.Response.Headers.Add("Referrer-Policy", "no-referrer");
                await next();
            });

            return app;
        }
    }
}

