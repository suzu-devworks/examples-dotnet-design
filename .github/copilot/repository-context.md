# Repository Context

## Purpose

This repository is a personal playground for learning Domain-Driven Design (DDD) with .NET.
It focuses on understanding design ideas through focused test projects inspired by authors and patterns
such as Anderson, Evans, Fowler, GoF, Microsoft, and Vernon.

## Tech Stack and Setup

- .NET SDK (shared framework settings live in `src/Directory.Build.props`)
- Test-first solutions under `src/Examples.Design.*` with xUnit and NSubstitute
- Shared test project: `src/Examples.Design.Tests`
- Multiple focused test projects for specific DDD/design-study themes

See [README](../../README.md) for repository purpose and devcontainer setup notes.

## Key Configuration

- `src/Directory.Build.props` centralizes the target framework and enables `TreatWarningsAsErrors`.
- `global.json` pins the .NET SDK version used by the repo.
- `nuget.config` defines package sources.
- `xunit.runner.json` is checked into each test project for consistent test discovery and execution.

## Project Conventions

- Place projects under `src/` with clear naming (`Examples.Design.*`).
- Keep examples focused on the domain concept being studied rather than on application plumbing.
- Prefer ubiquitous language from the pattern or author being referenced.
- Keep domain objects, value objects, repositories, and test doubles small and explicit.
- Isolate each study area in its own project so scenarios can be understood independently.
- Keep tests deterministic and avoid external dependencies unless a scenario is explicitly about integration behavior.

## Build and Test Commands

Common local/CI flow:

```bash
dotnet restore
dotnet build examples-dotnet-design.slnx --configuration Release --no-restore
dotnet test examples-dotnet-design.slnx --configuration Release --no-build --verbosity normal
```

Clean generated outputs with:

```bash
dotnet msbuild -t:RemoveDirectories
```

## Default branch

Default branch: `main`
