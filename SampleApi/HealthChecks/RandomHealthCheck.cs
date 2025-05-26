using Microsoft.Extensions.Diagnostics.HealthChecks;

namespace Api.HealthChecks;

public class RandomHealthCheck
{
    public Task<HealthCheckResult> CheckHealthAsync(HealthCheckContext context, CancellationToken cancellationToken = default)
    {
        int randomResult = Random.Shared.Next(1, 4); // Generates a random number between 1 and 3

        // Simulate a health check by returning a random status based on the generated number.
        return randomResult switch
        {
            1 => Task.FromResult(HealthCheckResult.Healthy("The check indicates a healthy status.")),
            2 => Task.FromResult(HealthCheckResult.Degraded("The check indicates a degraded status.")),
            3 => Task.FromResult(HealthCheckResult.Unhealthy("The check indicates an unhealthy status.")),
            _ => Task.FromResult(HealthCheckResult.Unhealthy("This is a test random service."))
        };
    }
}
