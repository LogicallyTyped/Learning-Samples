<!-- type: findings | status: active | since: 2026-08-16 | applies-to: Learning-Samples -->

# Findings — Learning-Samples

In-task friction and pipeline bugs surfaced during Stage 2 (verify) of the repo-doc
pipeline, TASK-5.2. Per `repo-documentation.md`, convention edits land at quarterly
review; this file is the interim record.

## repo_distiller bugs (deterministic fields — left unedited, flagged here per contract)

1. **`deterministic.entrypoints` mislabels class libraries as `type: "cli"`.**
   `DataAccess/User.DataAccess.csproj` and `ExceptionsLibrary/ExceptionsLibrary.csproj`
   are both plain `Microsoft.NET.Sdk` class libraries with no `Program.cs` / `Main`
   method (verified: grep for `static.*Main|class Program` in both folders returns
   no matches). Neither is an entrypoint of any kind -- they're referenced by other
   projects. The distiller appears to treat "has a .csproj with no obvious web/worker
   markers" as a CLI-entrypoint fallback instead of checking for `OutputType=Exe` /
   a `Main` method. Left the field as parsed per instructions; README's Entrypoints
   section omits these two rather than repeating the bug.

2. **`deterministic.routes` loses the `MapGroup` prefix.** The parsed route list
   (`GET ""`, `POST ""`, `PUT ""`, `GET "/"`, `GET "/{code}"`, `DELETE "/{id}"`,
   `GET "/{id}"`) is accurate as literal suffixes but drops which `MapGroup` each
   belongs to (`/users`, `/courses`, `/error` -- confirmed against
   `SampleApi/Endpoints/*.cs`). As written the array can't distinguish "GET /{id}"
   under `/users` from "GET /{id}" under `/courses`. Not wrong, but materially lossy;
   worth fixing in the parser so route paths are recorded with their full mapped path.

## Interpretive corrections (Stage 2 -- corrected in place)

3. **`interpretive.integration_points` mislabeled in-process patterns as external
   integrations.** The original three entries ("Configuration Sources", "Dependency
   Injection", "Exception Handling") are internal .NET framework/library features
   demonstrated within a single process -- not external systems, per the schema's own
   definition ("External system/API/queue/database name"). Meanwhile the repo's one
   genuine external integration -- `DataAccess` (Dapper + `Microsoft.Data.SqlClient`)
   calling stored procedures against the `UserDB` SQL Server database project, wired
   into `SampleApi`'s `/users` endpoints -- was omitted entirely. Replaced the three
   mislabeled entries with the one real integration point. Count changes 3 -> 1.

4. **`interpretive.data_flow_summary` implied one coherent application.** The
   original text described configuration/DI/exception-handling as if flowing through
   "the application" (singular), which overstates cohesion. `.ai/CONTEXT.md`
   (already present, pre-dating this task) is explicit: "There is no single
   application here and no coherent architecture spanning the projects -- each folder
   is its own exercise." Rewrote the summary to say so directly and to describe the
   one real cross-project data flow that does exist (SampleApi -> DataAccess -> UserDB).

5. **`interpretive.operational_notes` -- added a 4th, verified note.** Ran
   `dotnet build ExceptionsLibrary/ExceptionsLibrary.csproj` and confirmed
   `DemoCode.cs(55,1): error CS1022` -- a stray extra closing brace after the class
   body under a file-scoped namespace. `ConsoleUI` references `ExceptionsLibrary`
   and will not build until this is fixed. This is a real, currently-broken build
   path a reader needs to know about before trusting a `dotnet build` Quickstart
   step, so it was added as a fourth operational note (the array is additive, not
   fixed-size, and the schema imposes no minItems/maxItems).

## Judgment calls (not corrections, recorded for audit trail)

6. **`interpretive.components` (15 entries): all verified to exist**, each checked
   against its real source file. No hallucinations, no duplicate names found. Left
   unchanged. Coverage is intentionally partial -- 15 of roughly 35 .cs files in the
   repo (the `DataAccess`, `SampleApi/Endpoints`, `SampleApi/HealthChecks`,
   `SampleApi/Startup`, `TestUI`, and `Unloaded` trees are not individually itemized).
   `docs/architecture.md`'s component list draws on real source for the folders the
   distillate's 15 entries don't cover, since the distillate is the spine, not a wall.

7. **`TestUI` vs `TesteUI`.** Confirmed by direct comparison: `TestUI/Program.cs` and
   `TesteUI/Program.cs` are byte-identical (`TesteUI/Program.cs` even imports the
   `TestUI` namespace). This looks like an accidental duplicate/typo'd clone project,
   not two distinct samples. Documented as one Blazor WASM sample with a duplicate
   folder, rather than two independent components, in `docs/architecture.md`.

8. **`purpose` / `consumers` left unedited.** Slightly generous ("Teams implementing
   dependency injection...", "API developers needing a simple API setup") for what
   `.ai/CONTEXT.md` calls a personal "Scratch / learning solution, not a shipped
   product," but not factually wrong -- a public GitHub repo genuinely can be read by
   other developers as reference examples. Not worth churn; README's What this is
   section states the scratch/learning framing explicitly regardless, per CONTEXT.md.

9. **`.ai/CONTEXT.md` already exists and already declares an employer** (`**Employer:**
   none`, bold-label prose form, pre-dating this task). The contract requires an
   `employer:` declaration to exist and resolve to `none`/a valid slug; this file
   satisfies that in substance even though its exact key formatting (`**Employer:**`
   vs a bare `employer:` key) differs cosmetically from other repos in this pipeline
   run. Left untouched per Stage 3 instructions (only add the section if it does not
   already declare `employer:`). Its `## Deviations` section is present and empty
   ("None declared.") -- not touched, per hard rule.

10. **Two solution-level build failures confirmed, unrelated to the ExceptionsLibrary
    bug above:** `UserDB/UserDB.sqlproj` fails under `dotnet build` with `MSB4278`
    because SSDT (`Microsoft.Data.Tools.Schema.SqlTasks.targets`) is a
    Visual-Studio-only component not present in the plain `dotnet` CLI toolchain --
    this is an environment/tooling limitation, not a repo bug, and is called out in
    README's Quickstart section rather than filed as a finding.
