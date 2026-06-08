# examples-dotnet-design

![Dynamic XML Badge](https://img.shields.io/badge/dynamic/xml?url=https%3A%2F%2Fraw.githubusercontent.com%2Fsuzu-devworks%2Fexamples-dotnet-design%2Frefs%2Fheads%2Fmain%2Fsrc%2FDirectory.Build.props&query=%2F%2FLatestFramework&logo=dotnet&label=Framework&color=%23512bd4)
[![build](https://github.com/suzu-devworks/examples-dotnet-design/actions/workflows/dotnet-build.yml/badge.svg)](https://github.com/suzu-devworks/examples-dotnet-design/actions/workflows/dotnet-build.yml)
[![CodeQL](https://github.com/suzu-devworks/examples-dotnet-design/actions/workflows/github-code-scanning/codeql/badge.svg)](https://github.com/suzu-devworks/examples-dotnet-design/actions/workflows/github-code-scanning/codeql)

## What is this repository?

This repository contains examples and experiments with programming patterns such as Domain-Driven Design (DDD) using .NET.

Most of the content focuses on the Generic Host and the infrastructure commonly used in .NET applications,
such as dependency injection, configuration, logging, application lifetime management, and command-line argument handling.

The repository primarily serves as a personal knowledge base and a place to explore ideas through small, focused examples.

The examples reflect my current understanding of each topic and may evolve over time.

## What topics are covered?

Topics currently covered include:

- GoF design patterns (creational, structural, and behavioral)
- Patterns of Enterprise Application Architecture (Martin Fowler)
- Domain-Driven Design (DDD) fundamentals, including entities, value objects, repositories, and aggregates
- DDD-oriented examples inspired by Eric Evans, Vaughn Vernon, and Piikokku Anderson
- Microsoft architecture guidance around DDD and CQRS patterns
- Test-focused implementations using xUnit and test doubles

Additional topics may be added as the repository evolves.

## Why use Dev Containers?

I recommend using Dev Containers when working with this repository.

The development container provides the tools and dependencies needed to build and run the examples,
making it easy to get started without modifying your local environment.

For container details, see [`.devcontainer/devcontainer.json`](.devcontainer/devcontainer.json).

After the container is created, run [`.devcontainer/postCreateCommand.sh`](.devcontainer/postCreateCommand.sh)
and follow the instructions shown in the terminal.
