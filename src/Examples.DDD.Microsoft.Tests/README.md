# Examples.DDD.Microsoft.Tests

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.DDD.Microsoft.Tests
dotnet new xunit -o src/Examples.DDD.Microsoft.Tests
dotnet sln add src/Examples.DDD.Microsoft.Tests/
cd src/Examples.DDD.Microsoft.Tests
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
