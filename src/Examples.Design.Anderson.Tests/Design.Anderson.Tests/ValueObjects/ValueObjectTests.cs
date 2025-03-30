using System;

namespace Examples.Design.Anderson.ValueObjects.Tests;

public partial class ValueObjectTests
{
    [Fact]
    public void WhenCallingEqualsReference_WorkAsExpected()
    {
        Derived instance = new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") };

        instance.Equals(instance).Is(true);
#pragma warning disable CS1718 // Comparison made to same variable
        (instance == instance).Is(true);
        (instance != instance).Is(false);
#pragma warning restore CS1718 // Comparison made to same variable

        instance.Equals(null).Is(false);
        instance!.Equals(DateTime.Now).Is(false);

        return;
    }

    [Theory]
    [MemberData(nameof(DataOfEquals))]
    public void WhenCallingEquals_WorkAsExpected(Derived value1, Derived? value2, bool expected)
    {
        value1.Equals(value2).Is(expected);
        (value1 == value2).Is(expected);
        (value1 != value2).Is(!expected);
    }

    public static readonly TheoryData<Derived, Derived?, bool> DataOfEquals = new()
    {
        {
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            true
        },
        {
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            true
        },
        {
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            new() { Id = 2, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            false
        },
        {
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            new() { Id = 1, Name = "ABCD", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            false
        },
        {
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:57") },
            false
        },
        {
            new() { Id = 1, Name = "ABC", ExpiredAt = DateTime.Parse("2000-02-29T12:34:56") },
            null,
            false
        },
    };

}