using Crm.Api;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
var configuration = builder.Configuration;


var app = builder
       .ConfigureServices()
       .ConfigurePipeline();

app.Run();
