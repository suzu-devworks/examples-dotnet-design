# Validation and Commit

## Validation Checklist

- Run `dotnet restore` before build unless a prior step already restored packages.
- Run `dotnet build examples-dotnet-design.slnx --configuration Release --no-restore` and ensure zero warnings/errors.
- Run `dotnet test examples-dotnet-design.slnx --configuration Release --no-build --verbosity normal` and ensure tests pass
  (or clearly document skipped tests and why).
- For documentation changes related to Copilot or workspace settings, keep Markdown formatting clean.
- If verification is skipped, state the reason and any known risks.
- In PR descriptions, include what changed, why, how it was verified, and remaining risks.

## Scenario Checks (When Relevant)

- For changes in shared test helpers or fixtures, verify at least one affected test project builds and runs as expected.
- For changes that affect a family of domain examples, spot-check one representative project from that family.

## Commit Convention

Follow Conventional Commits:

```text
type(scope): subject
```

Common types:

- `feat`: new feature
- `fix`: bug fix
- `docs`: documentation only
- `style`: formatting, no logic change
- `refactor`: neither bug fix nor new feature
- `test`: adding or updating tests
- `chore`: maintenance tasks

Rules:

- Include a brief description in the subject line.
- Add a body for significant changes explaining rationale and verification steps.
- For breaking changes, include `BREAKING CHANGE:` in the body with impact and migration steps.
