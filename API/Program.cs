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

///<summary>
/// https://www.youtube.com/playlist?list=PLLWMQd6PeGY1TU4qj0UW9iS28j5O-Iwa4
/// 
/// Tricks for Visual Studio Code:
/// ALT+ arrow keys to move lines up and down.
/// CTRL+SHIFT+SPACE to bring up parameter info.
/// CTRL+J to bring the completion list.
/// ALT+SHIFT+down arrow to select the next line and modify all selected lines.
/// 
/// TIPS:
/// 
///</summary>