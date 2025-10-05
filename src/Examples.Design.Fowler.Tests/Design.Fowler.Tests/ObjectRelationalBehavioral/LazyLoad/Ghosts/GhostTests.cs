namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.Ghosts;

/// <summary>
/// Pattern 4: ゴースト (Ghost).
/// </summary>
/// <remarks>
/// <para>Generated with Google Gemini Pro 2.5.</para>
/// </remarks>
public class GhostTests
{
    [Fact]
    public void Should_Load_Full_State_On_First_Access_To_Any_Property()
    {
        // Arrange: IDのみを持つゴーストオブジェクトを作成
        var customer = new Customer(4);

        // Assert: ゴーストオブジェクト作成直後はDBアクセスが発生しない
        Assert.Equal(0, customer.GetRepositoryCallCount());

        // Act: 最初にNameプロパティにアクセスする
        var name = customer.Name;

        // Assert: 最初のプロパティアクセスで完全なデータがロードされ、DBアクセスが1回発生する
        Assert.Equal(1, customer.GetRepositoryCallCount());
        Assert.Equal("Ghost Customer 4", name);

        // Act: 次にOrdersプロパティにアクセスする
        var orders = customer.Orders;

        // Assert: 既にデータはロード済みなので、DBアクセスは増えない
        Assert.Equal(1, customer.GetRepositoryCallCount());
        Assert.Equal(2, orders.Count);
    }
}