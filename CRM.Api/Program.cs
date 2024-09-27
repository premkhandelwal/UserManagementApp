using Crm.Admin.Service.Services;
using Crm.Api;

var builder = WebApplication.CreateBuilder(args);

// Configure services
builder.ConfigureServices(); // Call ConfigureServices

var app = builder.Build(); // Build the application

// Configure middleware pipeline
app.ConfigurePipeline(); // Call ConfigurePipeline

app.Run();
