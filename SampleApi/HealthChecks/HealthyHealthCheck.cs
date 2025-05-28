using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Template.API.HealthChecks;

public class HealthyHealthCheck : IHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        // Simulate a health check by returning a healthy status. But in reality, you would check the health of a service or resource here. Like a database connection, an external API, etc.
        return Task.FromResult(HealthCheckResult.Healthy("The check indicates a healthy status."));
    }
}
