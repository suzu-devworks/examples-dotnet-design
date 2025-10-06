
namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad;

/// <summary>
/// データベースへのアクセスをシミュレートするリポジトリ
/// </summary>
public class FakeOrderRepository
{
    public int CallCount { get; private set; }

    // 特定の顧客IDに対する注文リストを取得する（DBアクセスの代わり）
    public List<Order> GetOrdersForCustomer(int customerId)
    {
        // このメソッドが呼ばれたことを記録
        CallCount++;
        Console.WriteLine($"---> DATABASE HIT: Loading orders for customer {customerId}...");

        // サンプルデータを返す
        return new List<Order>
        {
            new Order { OrderId = 101, ProductName = "Book" },
            new Order { OrderId = 102, ProductName = "Laptop" }
        };
    }
}