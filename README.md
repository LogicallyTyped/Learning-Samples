# Learning-Samples

## What this is

This is a personal scratch / learning solution — not a shipped product, not a single
application. `Learning.Projects.sln` bundles a grab-bag of small, mostly-unrelated C#
(.NET 8/9/10) projects, each one an isolated exercise in a specific concept:
configuration binding, dependency injection (three separate takes on the same idea),
global exception handling, a minimal-API + Dapper data-access sample backed by a SQL
Server database project, and a Blazor WebAssembly UI. There is no coherent
architecture spanning the folders — each is its own self-contained demo.

**Consumers:** primarily the repo owner, practicing individual .NET concepts; the
repo is public on GitHub, so secondarily any developer browsing for small, isolated
C#/.NET reference examples (configuration sources, DI patterns, minimal APIs,
Dapper-backed data access, Blazor WASM hosting).

## Quickstart

There is no top-level build/test script and no automated tests in this repo — each
sample is built and run independently as its own project.

```
# Run an individual console sample
dotnet run --project Configurations/Configurations.csproj
dotnet run --project DependencyInjection/DependencyInjection.csproj
dotnet run --project DependencyInjection1/DependencyInjection1.csproj
dotnet run --project DependencyInjection.Example1/DependencyInjection.csproj

# Run the minimal API sample (Swagger UI at /swagger, health checks at /health)
dotnet run --project SampleApi/Template.API.csproj

# Run a Blazor WebAssembly sample
dotnet run --project TestUI/TestUI.csproj
```

**Known-broken build paths** (see `.ai/findings.md` for detail): `dotnet build
Learning.Projects.sln` currently fails on two of its projects —
`ExceptionsLibrary/DemoCode.cs` has a stray extra closing brace and does not compile
(so `ConsoleUI`, which references it, won't build either), and `UserDB/UserDB.sqlproj`
requires SSDT (a Visual Studio component, not the plain `dotnet` CLI) to build. Build
individual working projects directly rather than the whole solution.

## Entrypoints

- `Configurations/Program.cs` — console; demonstrates binding config from JSON,
  environment variables, command-line args, in-memory values, and user secrets.
- `ConsoleUI/Program.cs` — console; global exception-handling demo. Depends on
  `ExceptionsLibrary`, which currently fails to build (see Quickstart).
- `DependencyInjection/Program.cs` — console; manual constructor/setter/interface
  injection, no DI container.
- `DependencyInjection.Example1/Program.cs` — console/hosted service; DI container
  (`Microsoft.Extensions.DependencyInjection`) with a `BackgroundService` worker.
- `DependencyInjection1/Program.cs` — console; minimal, bare `ServiceCollection` setup
  (no services registered).
- `SampleApi/Program.cs` (project `Template.API`) — HTTP; minimal-API app with
  `/users`, `/courses`, `/error/{code}`, and `/health*` endpoints, Swagger/OpenAPI,
  and CORS.
- `TestUI/Program.cs` and `TesteUI/Program.cs` — HTTP (Blazor WebAssembly dev host).
  These two projects are byte-identical; `TesteUI` looks like an accidental
  duplicate/typo'd clone of `TestUI` rather than a distinct sample.
- `Unloaded/API/Program.cs` and `Unloaded/SampleUI/Program.cs` — HTTP; an earlier,
  now-orphaned API + Blazor UI pair. **Not referenced by `Learning.Projects.sln`.**

`DataAccess/User.DataAccess.csproj` and `ExceptionsLibrary/ExceptionsLibrary.csproj`
are class libraries with no `Main` method — not entrypoints, despite being flagged as
such by this repo's doc-distillation tooling (a known distiller bug, see
`.ai/findings.md`).

## Configuration

Config key **names only** (no values are recorded here or anywhere in this repo's
generated docs); several are sensitive and must never be committed with real values:

- `AllowedHosts`
- `ConnectionStrings:Default` (sensitive)
- `KeyOne` (sensitive)
- `KeyThree:Message` (sensitive)
- `KeyTwo` (sensitive)
- `Logging:LogLevel:Default`
- `Logging:LogLevel:Microsoft.AspNetCore`
- `environment`
- `greeting`

## Dependencies

Major runtime dependencies (NuGet), by sample:

- `Microsoft.Extensions.Hosting`, `Microsoft.Extensions.DependencyInjection`,
  `Microsoft.Extensions.Configuration.Abstractions` — configuration/DI samples
- `Dapper`, `Microsoft.Data.SqlClient`, `System.Data.SqlClient` — `DataAccess`
- `Microsoft.AspNetCore.OpenApi`, `Swashbuckle.AspNetCore`, `Scalar.AspNetCore`,
  `AspNetCore.HealthChecks.UI.Client` — `SampleApi`
- `Microsoft.AspNetCore.Components.WebAssembly` (+ `.DevServer`, dev-only) —
  `TestUI` / `TesteUI` / `Unloaded/SampleUI`

Build-time: the .NET SDK, spanning multiple target framework monikers across
projects (`net8.0`, `net9.0`, `net10.0`). `UserDB` additionally needs SSDT
(a Visual Studio component) to build as a database project.

## Operational surface

N/A — no operational surface. Nothing in this repo is deployed; there are no
scheduled tasks, Windows services, containers, or IIS sites. `SampleApi` exposes
HTTP endpoints (including `/health*`) only when run locally by a developer.

## Deeper docs

- `docs/architecture.md` — component list, data flow, and the one real external
  integration point (SQL Server via `DataAccess`/`UserDB`)
- `.ai/CONTEXT.md` — project identity and standards-overlay declaration
- `.ai/findings.md` — distillation-pipeline bugs and verification judgment calls
  found while writing this documentation

---
schema_version: 1.0.0
distilled_from_sha: 30251b9140f8181bc9cb580fcd774ca6542d4712
verified_sha: 30251b9140f8181bc9cb580fcd774ca6542d4712
verified_at: 2026-08-16T18:38:11Z
