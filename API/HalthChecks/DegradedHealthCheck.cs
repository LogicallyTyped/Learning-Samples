using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace API.HalthChecks;

public class DegradedHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // Simulate a health check by returning a degraded status. In reality, you would check the health of a service or resource here.
        return Task.FromResult(HealthCheckResult.Degraded("The check indicates a degraded status."));
    }
}