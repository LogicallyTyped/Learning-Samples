namespace Template.API.Endpoints;

public static class ErrorEndpoints
{
    public static void MapErrorEndpoints(this WebApplication app)
    {
        var error = app.MapGroup("/error");
        error.MapGet("/{code}", (int code) =>
        {
            return code switch
            {
                400 => Results.BadRequest("Bad Request"),
                401 => Results.Unauthorized(),
                403 => Results.Forbid(),
                404 => Results.NotFound("Not Found"),
                500 => Results.Problem("Internal Server Error"),
                _ => Results.StatusCode(code)
            };
        });
    }
}
