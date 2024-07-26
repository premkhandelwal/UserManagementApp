using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.CookiePolicy;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using UserManagementApp;
using UserManagementApp.Models;
using UserManagementApp.Models.UserManagementRequests;
using UserManagementData;
using UserManagementService;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;

// Add DbContext
builder.Services.AddDbContext<ApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("UserManagementConnStr"));
}
);

builder.Services.AddDbContext<ClientApplicationDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("ConnStr"));
});

builder.Services.AddScoped<RefreshToken>();


// Add Identity services
builder.Services.AddIdentity<ApplicationUser, IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>()
    .AddDefaultTokenProviders();

// Add scoped services
builder.Services.AddScoped<UserManagement>();


// Configure JWT settings
builder.Services.Configure<JwtConfig>(configuration.GetSection("JwtConfig"));

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

builder.Services.AddSingleton(tokenValidationParameters);



// Add authentication and JWT bearer
builder.Services.AddAuthentication(options =>
{
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
}).AddJwtBearer(jwt =>
{
    jwt.SaveToken = true;
    jwt.TokenValidationParameters = tokenValidationParameters;
});

// Add authorization policies
builder.Services.AddAuthorization(options =>
{
    options.AddPolicy("RolePolicy",
        policy => policy.RequireClaim("claimRole", new[]
        {
            "admin"
        }));

    options.AddPolicy("ViewUsers", policy => policy.RequireClaim("permissions", new[]{ "ViewUsers" }));
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

builder.Services.AddSingleton<IAuthorizationHandler, RoleOrPolicyHandler>();

builder.Services.AddCors();


// Add controllers
builder.Services.AddControllers();

// Add Swagger for API documentation
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<CookiePolicyOptions>(options =>
{
    options.CheckConsentNeeded = context => true;
    options.MinimumSameSitePolicy = SameSiteMode.Strict;
    options.HttpOnly = HttpOnlyPolicy.Always;
    options.Secure = CookieSecurePolicy.Always;
    // you can add more options here and they will be applied to all cookies (middleware and manually created cookies)
});


var app = builder.Build();

app.UseCors(opt =>
{
    opt.AllowAnyHeader().AllowAnyMethod().AllowCredentials().WithOrigins("http://localhost:4200");
});



// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Use(async (context, next) =>
{
    context.Response.Headers.Add("Content-Security-Policy", "default-src 'self'; script-src 'self' 'nonce-random'; style-src 'self' 'nonce-random';");
    context.Response.Headers.Add("X-Content-Type-Options", "nosniff");
    context.Response.Headers.Add("X-Frame-Options", "DENY");
    context.Response.Headers.Add("X-XSS-Protection", "1; mode=block");
    context.Response.Headers.Add("Referrer-Policy", "no-referrer");
    await next();
});




app.Run();
