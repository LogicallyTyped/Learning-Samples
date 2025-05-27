using Api.Data;
using Api.Startup;
using DataAccess.DbAccess;

namespace SampleApi.Startup;

public static class DependenciesConfig
{
    public static void AddDependencies(this WebApplicationBuilder builder)
    {
        builder.Services.AddOpenApi();
        builder.Services.AddCorsServices();
        builder.Services.AddAllHealthChecks();

        builder.Services.AddTransient<CourseData>();

        builder.Services.AddSingleton<ISqlDataAccess, SqlDataAccess>();
        builder.Services.AddSingleton<IUserData, UserData>();

    }
}
