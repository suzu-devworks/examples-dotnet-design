# Examples.DDD.Anderson.Tests

## Project Initialize

```shell
## Solution
dotnet new sln -o .

## Examples.DDD.Anderson.Tests
dotnet new xunit -o src/Examples.DDD.Anderson.Tests
dotnet sln add src/Examples.DDD.Anderson.Tests/
cd src/Examples.DDD.Anderson.Tests
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
