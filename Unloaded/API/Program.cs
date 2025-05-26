using API.Endpoints;
using API.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.ApplyCorsConfig();

app.MapAllHealthChecks();

app.MapRootEndPoints();
app.MapCourseEndpoints();
app.MapErrorEndpoints();

app.Run();