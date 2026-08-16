<!-- type: context | status: active | since: 2026-08-16 | applies-to: Learning-Samples -->

# Project context: Learning-Samples

## Identity
- **Repo:** `github.com/LogicallyTyped/Learning-Samples` (PUBLIC)
- **Local:** `C:\source\github.com\LogicallyTyped\Learning-Samples\`
- **Employer:** none (personal project)
- **Standards overlay:** personal only — `C:\source\github.com\ProgramandoBonito\conventions\`

## Purpose
Scratch / learning solution, not a shipped product. `Learning.Projects.sln` bundles a grab-bag
of small, mostly-unrelated C# projects used to practice individual concepts: dependency
injection (`DependencyInjection`, `DependencyInjection.Example1`, `DependencyInjection1` —
three separate takes on the same topic), a console UI, a data-access layer (`DataAccess`,
`UserDB`), an exceptions library, a sample minimal API (`SampleApi` → `Template.API.csproj`,
target `net8.0`), and two near-duplicate test-UI projects (`TestUI`, `TesteUI`). There is no
single application here and no coherent architecture spanning the projects — each folder is
its own exercise. `FolderStructure.txt` and `TipsAndTricks.txt` are personal scratch notes,
not authored documentation.

There is no README describing intent; this assessment is inferred from the folder/project
names and commit history (`git log` shows commits like "Refactor namespaces and restructure
project organization", "Add new projects and configuration for React app" — the React
reference does not correspond to anything present in the current tree, suggesting some
exploratory work was removed or never committed here).

## Deviations

None declared.
