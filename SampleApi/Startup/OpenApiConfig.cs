namespace Template.API.Startup;

public static class OpenApiConfig
{
    public static void AddOpenApi(this IServiceCollection services)
    {
        services.AddEndpointsApiExplorer();
        services.AddSwaggerGen();
    }

    public static void UseOpenApi(this WebApplication app)
    {
        //if (app.Environment.IsDevelopment())
        //{
            app.UseSwagger();
            app.UseSwaggerUI();
        //}
    }
}