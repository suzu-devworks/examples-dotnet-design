using System;
using System.Collections.Generic;
using Examples.Design.Enumerating.Generic;

namespace Examples.Design.Tests.Enumerating.Generic;

/// <summary>
/// Tests <see cref="Enumeration{T}" /> class.
/// </summary>
public partial class EnumerationTests
{

    [Theory]
    [MemberData(nameof(DataOfEqualObjects))]
    public void WhenCallingEquals_WithEqualObjects_ReturnsTrue(CardType? instanceA, CardType? instanceB, string reason)
    {
        EqualityComparer<CardType>.Default.Equals(instanceA, instanceB).IsTrue(reason);
        object.Equals(instanceA, instanceB).IsTrue(reason);

        (instanceA == instanceB).IsTrue(reason);
    }

    public static readonly TheoryData<CardType?, CardType?, string> DataOfEqualObjects = new()
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

    //[Fact]
    //public void WhenCallingCompareTo()
    //{
    //    // Enumeration<CardType> is not IComparable<CardType>
    //    return;
    //}

    [Fact]
    public void WhenCallingValueOf_WorkAsExpected()
    {
        (CardType.Amex == Enumeration<CardType>.Parse("Amex")).IsTrue();

        (CardType.Amex == CardType.Parse("Amex")).IsTrue();
        (CardType.Amex == CardType.Parse("amex")).IsTrue();
        (CardType.Amex == CardType.Parse("1")).IsTrue();
        (CardType.Amex == CardType.Parse("ameX")).IsFalse();

        (CardType.Visa == CardType.Parse("Visa")).IsTrue();
        (CardType.Visa == CardType.Parse("visa")).IsTrue();
        (CardType.Visa == CardType.Parse("2")).IsTrue();
        (CardType.Visa == CardType.Parse("vIsa")).IsFalse();

        (CardType.MasterCard == CardType.Parse("MasterCard")).IsTrue();
        (CardType.MasterCard == CardType.Parse("mastercard")).IsTrue();
        (CardType.MasterCard == CardType.Parse("3")).IsTrue();
        (CardType.MasterCard == CardType.Parse("mAsterCard")).IsFalse();

        // spell-checker:: disable-next-line
        CardType.Parse("hogehoge").IsNull();
        Assert.Throws<ArgumentNullException>(() => CardType.Parse(null));

        return;
    }

    [Fact]
    public void WhenUsedInSwitchStatement()
    {
        var value1 = CardType.Parse("Visa");

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