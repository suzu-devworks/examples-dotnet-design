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
dotnet new xunit -o src/Examples.Design.Tests
dotnet sln add src/Examples.Design.Tests/
cd src/Examples.Design.Tests
dotnet add package Microsoft.NET.Test.Sdk
dotnet add package xunit
dotnet add package xunit.runner.visualstudio
dotnet add package coverlet.collector
dotnet add package Moq
dotnet add package ChainingAssertion.Core.Xunit
cd ../../

# Update outdated package
dotnet list package --outdated
```
