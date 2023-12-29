namespace Examples.DDD.Anderson.ValueObjects.Tests;

public class MeasureDateTests
{
    [Theory]
    [MemberData(nameof(DataOfDisplayValue))]
    public void GetsDisplayValue_ReturnsExpectFormatString(DateTime value, string expected)
    {
        // Add units by rounding up to three decimal places.
        var measure = new MeasureDate(value);
        measure.DisplayValue.Is(expected);

        return;
    }

    public static readonly TheoryData<DateTime, string> DataOfDisplayValue = new()
    {
        { DateTime.MinValue, "0001/01/01 00:00:00"},
        { DateTime.MaxValue, "9999/12/31 23:59:59"},
        { DateTime.Parse("2000-02-29T12:34:56.789"), "2000/02/29 12:34:56"},
    };


    [Theory]
    [MemberData(nameof(DataOfEquals))]
    public void WhenCallingEquals_WorkAsExpected(DateTime value1, DateTime value2, bool expected)
    {
        var measure1 = new MeasureDate(value1);
        var measure2 = new MeasureDate(value2);

        measure1.Equals(measure2).Is(expected);
        (measure1 == measure2).Is(expected);
        (measure1 != measure2).Is(!expected);
    }

    public static readonly TheoryData<DateTime, DateTime, bool> DataOfEquals = new()
    {
        { DateTime.MinValue, DateTime.MinValue, true},
        { DateTime.MaxValue, DateTime.MaxValue, true},
        { DateTime.Parse("2000-02-29T12:34:56.789"), DateTime.Parse("2000-02-29T12:34:56.789"), true},
        { DateTime.Parse("2000-02-29T12:34:56.789"), DateTime.Parse("2000-02-29T12:34:56.790"), false}
    };

}

