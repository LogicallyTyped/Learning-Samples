using Api.Endpoints;
using Api.Startup;
using SampleApi.Endpoints;
using SampleApi.Startup;

var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.ApplyCorsConfig();

app.MapAllHealthChecks();
app.MapRootEndpoints();
app.MapCourseEndpoints();
app.MapErrorEndpoints();

app.Run();
