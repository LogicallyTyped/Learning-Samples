namespace Template.API.Endpoints;

public static class UserEndPoints
{
    public static void MapUserEndpoints(this WebApplication app)
    {
        var users = app.MapGroup("/users");
        users.MapGet("", GetUsers);
        users.MapGet("/{id}", Getuser);
        users.MapPost("", InsertUser);
        users.MapPut("", UpdateUser);
        users.MapDelete("/{id}", DeleteUser);
    }

    private static async Task<IResult> GetUsers(IUserData data)
    {
        try
        {
            return Results.Ok(await data.GetUsers());
        }
        catch (Exception ex)
        {

            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> Getuser(IUserData data, int id)
    {
        try
        {
            var user = await data.GetUser(id);
            return user is not null ? Results.Ok(user) : Results.NotFound();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> InsertUser(IUserData data, UserModel user)
    {
        try
        {
            await data.InsertUser(user);
            return Results.Ok();
            //return Results.Created($"/users/{user.Id}", user);
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> UpdateUser(IUserData data, UserModel user)
    {
        try
        {
            await data.UpdateUser(user);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }

    private static async Task<IResult> DeleteUser(IUserData data, int id)
    {
        try
        {
            await data.DeleteUser(id);
            return Results.Ok();
        }
        catch (Exception ex)
        {
            return Results.Problem(ex.Message);
        }
    }
}
