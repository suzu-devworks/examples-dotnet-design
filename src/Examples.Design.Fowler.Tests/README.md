# Examples.Design.Fowler.Tests

## Table of Contents <!-- omit in toc -->

- [Martin Fowler's Domain-Driven Design](#martin-fowlers-domain-driven-design)
- [Patterns of Enterprise Application Architecture](#patterns-of-enterprise-application-architecture)
  - [Catalog](#catalog)
- [Development](#development)
  - [How the project was initialized](#how-the-project-was-initialized)

## Martin Fowler's Domain-Driven Design

- [domain driven design - martinfowler.com](https://martinfowler.com/tags/domain%20driven%20design.html)

<!-- spell-checker: words martinfowler -->

## Patterns of Enterprise Application Architecture

- [Catalog of Patterns of Enterprise Application Architecture](https://martinfowler.com/eaaCatalog/)

### Catalog

- [Domain Logic Patterns](./Design.Fowler.Tests/DomainLogic/)
- [Data Source Architectural Patterns](./Design.Fowler.Tests/DataSourceArchitectural/)
- [Object-Relational Behavioral Patterns](./Design.Fowler.Tests/ObjectRelationalBehavioral/)
- [Object-Relational Structural Patterns](./Design.Fowler.Tests/ObjectRelationalStructural/)
- [Object-Relational Metadata Mapping Patterns](./Design.Fowler.Tests/ObjectRelationalMetadataMapping/)
- [Web Presentation Patterns](./Design.Fowler.Tests/WebPresentation/)
- [Distribution Patterns](./Design.Fowler.Tests/Distribution/)
- [Offline Concurrency Patterns](./Design.Fowler.Tests/OfflineConcurrency/)
- [Session State Patterns](./Design.Fowler.Tests/SessionState/)
- [Base Patterns](./Design.Fowler.Tests/Base/)

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
cd ../../

# Update outdated package
dotnet list package --outdated
```
