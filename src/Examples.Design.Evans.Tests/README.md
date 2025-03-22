# Examples.Design.Evans.Tests

## Table of Contents <!-- omit in toc -->

- [Examples.Design.Evans.Tests](#examplesdesignevanstests)
  - [Eric Evans's Domain-Driven Design](#eric-evanss-domain-driven-design)
  - [Development](#development)
    - [How the project was initialized](#how-the-project-was-initialized)

## Eric Evans's Domain-Driven Design

- <https://www.domainlanguage.com/>

## Development

### How the project was initialized

This project was initialized with the following command:

```shell
## Solution
dotnet new sln -o .

## Examples.Design.Evans.Tests
dotnet new xunit -o src/Examples.Design.Evans.Tests
dotnet sln add src/Examples.Design.Evans.Tests/
cd src/Examples.Design.Evans.Tests
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
