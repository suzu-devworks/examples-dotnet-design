namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.LazyInitialization;

public class Customer
{
    private readonly FakeOrderRepository _repository = new FakeOrderRepository();

    // Ordersリストを保持するプライベートフィールド。初期値はnull。
    private List<Order>? _orders;

    public required int Id { get; init; }
    public required string Name { get; init; }

    public List<Order> Orders
    {
        get
        {
            // フィールドがnullの場合のみ、データをロードする
            if (_orders == null)
            {
                _orders = _repository.GetOrdersForCustomer(Id);
            }
            return _orders;
        }
    }

    // テスト用にリポジトリの状態を確認するためのメソッド
    public int GetRepositoryCallCount() => _repository.CallCount;
}