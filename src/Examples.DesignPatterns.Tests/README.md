# Examples.DesignPatterns.Tests

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.DesignPatterns
dotnet new classlib -o src/Examples.DesignPatterns
dotnet sln add src/Examples.DesignPatterns/
cd src/Examples.DesignPatterns
cd ../../

## Examples.DesignPatterns.Tests
dotnet new xunit -o tests/Examples.DesignPatterns.Tests
dotnet sln add tests/Examples.DesignPatterns.Tests/
cd src/Examples.DesignPatterns.Tests
dotnet add reference ../../src/Examples.DesignPatterns
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
