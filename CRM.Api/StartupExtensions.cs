using CRM.Tenant.Service;
using CRM.Admin.Data;
using CRM.Api;
using CRM.Admin.Service;

namespace Crm.Api
{
    public static class StartupExtensions
    {
        public static WebApplication ConfigureServices(
            this WebApplicationBuilder builder)
        {

            builder.Services.AddAdminServices(builder.Configuration);
            builder.Services.AddAuthorizationServices(builder.Configuration);
            builder.Services.AddAdminDataServices(builder.Configuration);
            builder.Services.AddTenantDataServices(builder.Configuration);
            builder.Services.AddTenantServices(builder.Configuration);
            builder.Services.AddControllers();
            builder.Services.AddCors();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            return builder.Build();
        }

        public static WebApplication ConfigurePipeline(this WebApplication app)
        {

            app.UseCors("open");

            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
            }

            app.UseAuthentication();
            app.UseAuthorization();

            app.UseHttpsRedirection();
            app.MapControllers();

            app.UseCors(opt =>
            {
                opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200");
            });



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
