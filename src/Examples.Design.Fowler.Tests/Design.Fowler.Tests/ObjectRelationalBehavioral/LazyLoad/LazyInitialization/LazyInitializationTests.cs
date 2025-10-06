namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.LazyInitialization;

/// <summary>
/// Pattern 1: レイジーイニシャライズ (Lazy Initialization).
/// </summary>
/// <remarks>
/// <para>Generated with Google Gemini Pro 2.5.</para>
/// </remarks>
public class LazyInitializationTests
{
    [Fact]
    public void Should_Load_Orders_Only_On_First_Access()
    {
        var customer = new Customer { Id = 1, Name = "Taro Yamada" };

        // Assert: Customerオブジェクト作成直後はDBアクセスが発生しない
        Assert.Equal(0, customer.GetRepositoryCallCount());

        // Act: 最初にOrdersプロパティにアクセスする
        var orders = customer.Orders;

        // Assert: 最初のアクセスでDBアクセスが1回発生する
        Assert.Equal(1, customer.GetRepositoryCallCount());
        Assert.Equal(2, orders.Count);

        // Act: 2回目にOrdersプロパティにアクセスする
        var ordersAgain = customer.Orders;

        // Assert: 2回目のアクセスではDBアクセスは増えない
        Assert.Equal(1, customer.GetRepositoryCallCount());
        Assert.Equal(2, ordersAgain.Count);
    }
}