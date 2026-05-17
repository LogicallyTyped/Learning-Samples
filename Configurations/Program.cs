using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

var builder = Host.CreateApplicationBuilder(args);

builder.Configuration
    // Shared defaults. Base config, same everywhere
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .AddJsonFile($"appsettings.{builder.Environment.EnvironmentName}.json", optional: true, reloadOnChange: true)
    .AddEnvironmentVariables() // for testing PowerShell $env:environment='dev'
    .AddCommandLine(args) // PowerShell dotnet run -- --environment Staging

    // This is best for unity testing
    .AddInMemoryCollection(new Dictionary<string, string?>
    {
        ["greeting"] = "Hola"
    })

    // User Secrets are good for development not to check in git repo. In production, use something like Azure Key Vault or AWS Secrets Manager.
    .AddUserSecrets<Program>()

    ;

using IHost host = builder.Build();

ConfigurationManager configuration = builder.Configuration;

// Ask the service provider for the configuration instance. This is the same instance as the one we have in the builder.Configuration.
IConfiguration config = host.Services.GetRequiredService<IConfiguration>();

// Biding is strongly typed and is the standard/object
var settings = config.Get<AppSettings>() ?? new AppSettings();

// Get values from the config given their key and their target type
int keyOneValue = config.GetValue<int>("KeyOne");
bool keyTwoValue = config.GetValue<bool>("KeyTwo");
string? keyThreeValue = config.GetValue<string?>("KeyThree:Message");

//Console.WriteLine("Hello, World!");
//Console.WriteLine($"{configuration["greeting"]}, {configuration["environment"]}!");

int i = 0;
foreach (var src in configuration.Sources.Reverse())
{
    Console.WriteLine($"Source {i++}: {src.GetType().Name}");
}

Console.WriteLine(configuration.GetDebugView(ctx =>
    ctx.Key.Contains("Secret", StringComparison.OrdinalIgnoreCase)
        ? "****"
        : ctx.Value));

await host.RunAsync();