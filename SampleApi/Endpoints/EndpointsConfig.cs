using Api.Startup;
using SampleApi.Endpoints;

namespace Api.Endpoints;

public static class EndpointsConfig
{
    public static void ConfigureEndpoints(this WebApplication app)
    {
        app.MapAllHealthChecks();
        app.MapRootEndpoints();
        app.MapCourseEndpoints();
        app.MapErrorEndpoints();
    }
}
