using Microsoft.Extensions.Diagnostics.HealthChecks;
using RestSharp;

namespace HealthCheckApi.Services.Health;

public class ApiHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = new CancellationToken())
    {
        var url = "https://airport-info.p.rapidapi.com/airport?iata=BNA";
        var client = new RestClient();
        var request = new RestRequest(url, Method.Get);
        request.AddHeader("X-RapidAPI-Key", "a8f27ae40bmsh1c7be8fb44f7ac5p14ead9jsn3f7b1a107706");
        request.AddHeader("X-RapidAPI-Host", "airport-info.p.rapidapi.com");

        var response = client.Execute(request);

        if (response.IsSuccessful)
        {
            return Task.FromResult(HealthCheckResult.Healthy());
        }
        else
        {
            return Task.FromResult(HealthCheckResult.Unhealthy());
        }
    }
}