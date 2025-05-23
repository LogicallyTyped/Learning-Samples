using API.Endpoints;
using API.Startup;

///<summary>
///
///</summary>


var builder = WebApplication.CreateBuilder(args);

builder.AddDependencies();

var app = builder.Build();

app.UseOpenApi();

app.UseHttpsRedirection();

app.MapRootEndPoints();
app.MapCourseEndpoints();

app.Run();