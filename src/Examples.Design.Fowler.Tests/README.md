# Examples.Design.Fowler.Tests

## Table of Contents <!-- omit in toc -->

- [Examples.Design.Fowler.Tests](#examplesdesignfowlertests)
  - [Martin Fowler's Domain-Driven Design](#martin-fowlers-domain-driven-design)
  - [Patterns of Enterprise Application Architecture](#patterns-of-enterprise-application-architecture)
  - [Development](#development)
    - [How the project was initialized](#how-the-project-was-initialized)

## Martin Fowler's Domain-Driven Design

- <https://martinfowler.com/tags/domain%20driven%20design.html>

## Patterns of Enterprise Application Architecture

- <https://martinfowler.com/eaaCatalog/>

## Development

### How the project was initialized

This project was initialized with the following command:

```shell
## Solution
dotnet new sln -o .

## Examples.Design.Fowler.Tests
dotnet new xunit -o src/Examples.Design.Fowler.Tests
dotnet sln add src/Examples.Design.Fowler.Tests/
cd src/Examples.Design.Fowler.Tests
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
