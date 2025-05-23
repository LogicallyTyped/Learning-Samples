using API.Endpoints;
using API.Startup;

///<summary>
///https://www.youtube.com/playlist?list=PLLWMQd6PeGY1TU4qj0UW9iS28j5O-Iwa4
///</summary>

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