#pragma warning disable IDE1006 //Naming rule violation

namespace Examples.DesignPatterns.Enumerations.SeedWork.Tests;

/// <summary>
/// Tests <see cref="Enumerations /> class.
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

    [Fact]
    public void WhenCallingCompareTo()
    {
        (CardType.Amex.CompareTo(CardType.FromDisplayName<CardType>("Amex")) == 0).IsTrue();

        //　InvalidOperationException
        //　(CardType.Amex.CompareTo(CardType.FromDisplayName<CardType>("amex")) == 0).IsFalse();
        (CardType.Amex.CompareTo(CardType.FromDisplayName<CardType>("Visa")) == 0).IsFalse();
        return;
    }

    [Fact]
    public void WhenCallingValueOf()
    {
        (CardType.Amex == CardType.FromDisplayName<CardType>("Amex")).IsTrue();
        //　InvalidOperationException
        //　(CardType.Amex == CardType.FromDisplayName<CardType>("amex", ignoreCase: true)).IsTrue();

        //　InvalidOperationExceptions
        //　(CardType.Amex == CardType.FromDisplayName<CardType>("amex")).IsFalse();
        (CardType.Amex == CardType.FromDisplayName<CardType>("Visa")).IsFalse();
        return;
    }

    [Fact]
    public void WhenUsedInSwitchStatement()
    {
        var value1 = CardType.FromDisplayName<CardType>("Visa");

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
