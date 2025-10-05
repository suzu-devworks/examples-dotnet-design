namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.ValueHolders;

/// <summary>
/// Pattern 3: バリューホルダー (Value Holder).
/// </summary>
/// <remarks>
/// <para>Generated with Google Gemini Pro 2.5.</para>
/// </remarks>
public class ValueHolderTests
{
    [Fact]
    public void Should_Load_Value_Only_When_Accessed_Via_ValueHolder()
    {
        // Arrange
        var customer = new Customer(3);

        // Assert: Customerオブジェクト作成直後はDBアクセスが発生しない
        Assert.Equal(0, customer.GetRepositoryCallCount());

        // Act: ValueHolderのValueプロパティに初めてアクセスする
        var orders = customer.Orders.Value;

        // Assert: 最初のアクセスでDBアクセスが1回発生する
        Assert.Equal(1, customer.GetRepositoryCallCount());
        Assert.Equal(2, orders.Count);

        // Act: 2回目にアクセスする
        var ordersAgain = customer.Orders.Value;

        // Assert: 2回目のアクセスではDBアクセスは増えない
        Assert.Equal(1, customer.GetRepositoryCallCount());
        Assert.Equal(2, ordersAgain.Count);
    }
}