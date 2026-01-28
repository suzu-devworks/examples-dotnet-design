# Examples.Design.Evans.Tests

## Table of Contents <!-- omit in toc -->

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
dotnet new xunit3 -o src/Examples.Design.Evans.Tests
dotnet sln add src/Examples.Design.Evans.Tests/
cd src/Examples.Design.Evans.Tests
dotnet add package xunit.v3.mtp-v2
dotnet add package Microsoft.Testing.Extensions.CodeCoverage
dotnet add package NSubstitute
cd ../../

# Update outdated package
dotnet list package --outdated
```
