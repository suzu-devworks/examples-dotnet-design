# Examples.DDD.Vernon.Tests

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.DDD.Vernon.Tests
dotnet new xunit -o src/Examples.DDD.Vernon.Tests
dotnet sln add src/Examples.DDD.Vernon.Tests/
cd src/Examples.DDD.Vernon.Tests
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
