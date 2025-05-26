using Api.Data;
using Api.Startup;

namespace SampleApi.Startup;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        builder.Services.AddCorsServices();
        builder.Services.AddAllHealthChecks();

        builder.Services.AddTransient<CourseData>();
    }
}
