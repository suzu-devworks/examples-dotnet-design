using System;
using System.Collections.Generic;
using Examples.Design.Enumerating.JavaStyle;

namespace Examples.Design.Tests.Enumerating.JavaStyle;

/// <summary>
/// Tests <see cref="EnumerationsT}" /> methods.
/// </summary>
public partial class EnumerationTests
{

    [Theory]
    [MemberData(nameof(DatesOfEqualObjects))]
    public void WhenCallingEquals_WithEqualObjects_ReturnsTrue(CardType? instanceA, CardType? instanceB, string reason)
    {
        EqualityComparer<CardType>.Default.Equals(instanceA, instanceB).IsTrue(reason);
        object.Equals(instanceA, instanceB).IsTrue(reason);

        (instanceA == instanceB).IsTrue(reason);
    }

    public static readonly TheoryData<CardType?, CardType?, string> DatesOfEqualObjects = new()
    {
        {
            null,
            null,
            "they should be equal because they are both null"
        },
        {
            CardType.Amex,
            CardType.Amex,
            "they should be equal because they are the same object"
        },
    };

    [Theory]
    [MemberData(nameof(DataOfNotEqualObjects))]
    public void WhenCallingEquals_WithNotEqualObjects_ReturnsFalse(CardType? instanceA, CardType? instanceB, string reason)
    {
        EqualityComparer<CardType>.Default.Equals(instanceA, instanceB).IsFalse(reason);
        object.Equals(instanceA, instanceB).IsFalse(reason);

        (instanceA != instanceB).IsTrue(reason);
    }

    public static readonly TheoryData<CardType?, CardType?, string> DataOfNotEqualObjects = new()
    {
        {
            null,
            CardType.Amex,
            "they should not be equal because the left side is null"
        },
        {
            CardType.Amex,
            null,
            "they should not be equal because the right side is null"
        },
        {
            CardType.Amex,
            CardType.Visa,
            "they should not be equal because the right side is null"
        },
    };

    [Fact]
    public void WhenCallingCompareTo()
    {
        (CardType.Amex.CompareTo(CardType.ValueOf("Amex")) == 0).IsTrue();

        (CardType.Amex.CompareTo(CardType.ValueOf("amex")) == 0).IsFalse();
        (CardType.Amex.CompareTo(CardType.ValueOf("Visa")) == 0).IsFalse();
        return;
    }

    [Fact]
    public void WhenCallingValueOf()
    {
        (CardType.Amex == Enumeration<CardType>.ValueOf("Amex")).IsTrue();
        (CardType.Amex == CardType.ValueOf("Amex")).IsTrue();
        (CardType.Amex == CardType.ValueOf("amex", ignoreCase: true)).IsTrue();

        (CardType.Amex == CardType.ValueOf("amex")).IsFalse();
        (CardType.Amex == CardType.ValueOf("Visa")).IsFalse();
        return;
    }

    [Fact]
    public void WhenUsedInSwitchStatement()
    {
        var value1 = CardType.ValueOf("Visa");

        var value2 = value1 switch
        {
            var x when x == CardType.Amex => null,
            var x when x == CardType.Visa => x,
            var x when x == CardType.MasterCard => null,
            _ => throw new NotSupportedException($"{value1}"),
        };
        value2.IsNotNull();

        return;
    }

}