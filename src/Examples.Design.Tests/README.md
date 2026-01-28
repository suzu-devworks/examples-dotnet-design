# Examples.Design.Tests

## Table of Contents <!-- omit in toc -->

- [Object Oriented, Domain Design and Architecture](#object-oriented-domain-design-and-architecture)
  - [Enumerating](#enumerating)
- [Development](#development)
  - [How the project was initialized](#how-the-project-was-initialized)

## Object Oriented, Domain Design and Architecture

### Enumerating

Java's "behaving Enum" looked good.

## Development

### How the project was initialized

This project was initialized with the following command:

```shell
## Solution
dotnet new sln -o .

## Examples.Design.Tests
dotnet new xunit3 -o src/Examples.Design.Tests
dotnet sln add src/Examples.Design.Tests/
cd src/Examples.Design.Tests
dotnet add package xunit.v3.mtp-v2
dotnet add package Microsoft.Testing.Extensions.CodeCoverage
dotnet add package NSubstitute

# Update outdated package
dotnet list package --outdated
```
