using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api.HealthChecks;

public class UnhealthyHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // Simulate a health check by returning an unhealthy status. In reality, you would check the health of a service or resource here.
        return Task.FromResult(HealthCheckResult.Unhealthy("The check indicates an unhealthy status."));
    }
}
