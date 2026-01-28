# Examples.Designs.Tests

## Table of Contents <!-- omit in toc -->

- [Object Oriented, Domain Designs and Architecture](#object-oriented-domain-designs-and-architecture)
  - [Enumerating](#enumerating)
- [Development](#development)
  - [How the project was initialized](#how-the-project-was-initialized)

## Object Oriented, Domain Designs and Architecture

### Enumerating

Java's "behaving Enum" looked good.

## Development

### How the project was initialized

This project was initialized with the following command:

```shell
## Solution
dotnet new sln -o .

## Examples.Designs.Tests
dotnet new xunit3 -o src/Examples.Designs.Tests
dotnet sln add src/Examples.Designs.Tests/
cd src/Examples.Designs.Tests
dotnet add package xunit.v3.mtp-v2
dotnet add package Microsoft.Testing.Extensions.CodeCoverage
dotnet add package NSubstitute

# Update outdated package
dotnet list package --outdated
```
