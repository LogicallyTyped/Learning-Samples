using Api.Endpoints;
using SampleApi.Endpoints;

namespace Api.Startup;

public static class EndpointsConfig
{
    public static void ConfigureEndpoints(this WebApplication app)
    {
        app.MapAllHealthChecks();
        app.MapRootEndpoints();
        app.MapCourseEndpoints();
        app.MapErrorEndpoints();
        app.MapUserEndpoints();
    }
}
