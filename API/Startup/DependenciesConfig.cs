using API.Data;

namespace API.Startup;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApiServices();
        builder.Services.AddCorsServices();

        // Load a list that will not going to change and will allow methods to work on that list and.
        builder.Services.AddTransient<CourseData>();
    }
}
