﻿using Crm.Admin.Data.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using System.Text;
namespace Crm.Admin.Data
{
    public static class AdminDataServicesRegistration
    {
        public static void AddAdminDataServices(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped<RefreshToken>();

            services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

            services.AddDbContext<AdminDbContext>(options =>
            {
                options.UseSqlServer(configuration.GetConnectionString("AdminConnectionString"));
            });

            byte[] key = Encoding.ASCII.GetBytes(configuration["JwtConfig:Secret"]);


            TokenValidationParameters tokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
                ValidateLifetime = false,
                RequireExpirationTime = false
            };
            services.AddSingleton(tokenValidationParameters);

            services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            }).AddJwtBearer(jwt =>
            {
                jwt.SaveToken = true;
                jwt.TokenValidationParameters = tokenValidationParameters;
            });
            services.AddIdentity<CrmIdentityUser, IdentityRole>()
                .AddEntityFrameworkStores<AdminDbContext>()
                .AddDefaultTokenProviders();

        }
    }
}
