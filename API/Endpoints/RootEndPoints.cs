namespace API.Endpoints;

public static class RootEndPoints
{
    // adding 'this' before WebApplication makes it an extension method.
    public static void MapRootEndPoints(this WebApplication app)
    {
        app.MapGet("/", () => "Hello World!");
    }
}
