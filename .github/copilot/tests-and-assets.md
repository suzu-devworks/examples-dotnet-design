# Tests and Test Assets

## Test Style and Naming

- Test code should prioritize readability and behavior verification for DDD study scenarios.
- Place test code and test projects under `src/` (for example `src/Examples.Design.Anderson.Tests`).
- Use xUnit conventions (`[Fact]`/`[Theory]`) unless a project explicitly uses another framework.
- Method names should be descriptive and clearly communicate the scenario.
- Keep tests deterministic and avoid dependency on external services unless intentionally testing integration points.

Examples:

- `When_EmailAddressIsDuplicated_Then_ReturnsFailure`
- `When_ValueObjectIsCreated_WithInvalidInput_Then_Throws`

## Test Data and Sensitive Files

- Never commit production secrets, real credentials, or machine-specific certificate material.
- If a scenario needs sample data, keep it in the relevant test project and make it small, explicit, and easy to review.
- Prefer inline builders, lightweight fixtures, or local test files over machine-specific paths.

## Environment-Dependent Tests and Assumptions

- Most tests in this repository should be self-contained and deterministic.
- Unless explicitly requested, do not remove or rewrite existing environment-dependent skip logic.
- Follow repository patterns for fixture and environment checks used in tests.
- When touching domain behavior, prefer adding focused tests over broad rewrites.
- For changes in shared test helpers or fixtures, verify at least one affected test project runs as expected.
