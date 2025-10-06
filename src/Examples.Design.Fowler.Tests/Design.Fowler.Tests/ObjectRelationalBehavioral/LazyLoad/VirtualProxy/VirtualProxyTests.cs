namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.VirtualProxy;

/// <summary>
/// Pattern 2: 仮想プロキシー (Virtual Proxy).
/// </summary>
/// <remarks>
/// <para>Generated with Google Gemini Pro 2.5.</para>
/// </remarks>
public class VirtualProxyTests
{
    [Fact]
    public void Should_Load_Real_Object_Only_On_First_Method_Call()
    {
        // Arrange
        ICustomer customerProxy = new CustomerProxy(2);

        // Assert: Proxyオブジェクト作成直後はDBアクセスが発生しない
        Assert.Equal(0, customerProxy.GetRepositoryCallCount());

        // Act: 最初にOrdersプロパティにアクセスする
        var orders = customerProxy.Orders;

        // Assert: 最初のアクセスで本物のオブジェクトが生成され、DBアクセスが1回発生する
        Assert.Equal(1, customerProxy.GetRepositoryCallCount());
        Assert.Equal(2, orders.Count);

        // Act: 2回目にNameプロパティにアクセスする
        var name = customerProxy.Name;

        // Assert: 2回目のアクセスではDBアクセスは増えない
        Assert.Equal(1, customerProxy.GetRepositoryCallCount());
        Assert.Equal("Real Customer 2", name);
    }
}