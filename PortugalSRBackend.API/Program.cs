using PortugalSRBackend.API.Extensions;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddServiceCollection(builder.Configuration);
var app = builder.Build();
app.AddApplicationConfiguration();
app.AddEndpointConfiguration();
app.Run();
