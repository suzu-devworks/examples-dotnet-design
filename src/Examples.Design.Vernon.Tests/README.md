# Examples.Design.Vernon.Tests

## Table of Contents <!-- omit in toc -->

- [Examples.Design.Vernon.Tests](#examplesdesignvernontests)
  - [Vaughn Vernon's Domain-Driven Design](#vaughn-vernons-domain-driven-design)
  - [Development](#development)
    - [How the project was initialized](#how-the-project-was-initialized)

## Vaughn Vernon's Domain-Driven Design

- <https://github.com/VaughnVernon/IDDD_Samples_NET>

## Development

### How the project was initialized

This project was initialized with the following command:

```shell
## Solution
dotnet new sln -o .

## Examples.Design.Vernon.Tests
dotnet new xunit -o src/Examples.Design.Vernon.Tests
dotnet sln add src/Examples.Design.Vernon.Tests/
cd src/Examples.Design.Vernon.Tests
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
