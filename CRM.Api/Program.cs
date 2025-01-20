using Crm.Admin.Service.Services;
using Crm.Api;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpOverrides;

var builder = WebApplication.CreateBuilder(args);

/*Host.CreateDefaultBuilder(args)
       .ConfigureWebHostDefaults(webBuilder =>
       {
           webBuilder.UseUrls("http://0.0.0.0:5000"); // Listen on all network interfaces
       });*/

builder.Configuration.AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                      .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true)
                      .AddEnvironmentVariables()
                      .Build();

// Configure services
builder.ConfigureServices(); // Call ConfigureServices

var app = builder.Build(); // Build the application

app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
});

app.MapGet("/", () => "Hello World!");
// Configure middleware pipeline
app.ConfigurePipeline(); // Call ConfigurePipeline

app.Run();
