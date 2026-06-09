---
description: Repository-specific constraints for this codebase.
applyTo: "**"
---

# Repository Instructions

- Do not edit files under any `bin/` or `obj/` directory; they are generated artifacts.
- Keep each pattern/example isolated within its own project under `src/Examples.Design.*.Tests`; avoid cross-project references unless explicitly requested.
- In test project `.csproj` files, set `<TargetFramework>$(LatestFramework)</TargetFramework>`; do not hardcode specific framework versions.
- Keep shared build behavior in `src/Directory.Build.props` and `src/Directory.Build.targets`; avoid per-project overrides unless there is a clear project-specific need.
- For Anderson DDD examples, keep repository interfaces in `Design.Anderson/Repositories` and concrete implementations in `Design.Anderson/Infrastructures`; domain/client code should depend on interfaces only.
- When adding a new test project, include xUnit v3 (`xunit.v3.mtp-v2`), code coverage (`Microsoft.Testing.Extensions.CodeCoverage`), and copy `xunit.runner.json` to output.
