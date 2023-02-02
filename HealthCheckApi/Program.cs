using HealthCheckApi.Services.Health;
using HealthChecks.UI.Client;
using Microsoft.AspNetCore.Diagnostics.HealthChecks;

var builder = WebApplication.CreateBuilder(args);
var services = builder.Services;

services.AddEndpointsApiExplorer();
services.AddSwaggerGen();

// HEALTH CHECK   & ApiHealthCheck is where all the meat is
services.AddHealthChecks().AddCheck<ApiHealthCheck>("AirportApiChecks", tags: new string[]{"AirportApi"});

var app = builder.Build();
app.UseSwagger();
app.UseSwaggerUI();
app.UseHttpsRedirection();

// Map Health Check Endpoints
app.MapHealthChecks("/health", new HealthCheckOptions()
{
    Predicate = _ => true, ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
});

app.Run();