using Template.API.Endpoints;

namespace Template.API.Startup;

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
