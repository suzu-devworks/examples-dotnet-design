namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.ValueHolders;

public class Customer
{
    public int Id { get; }
    public string? Name { get; set; }

    // OrdersプロパティはValueHolderとして持つ
    public ValueHolder<List<Order>> Orders { get; private set; }

    private readonly FakeOrderRepository _repository;

    public Customer(int id)
    {
        Id = id;
        _repository = new FakeOrderRepository();

        // ValueHolderにデータ読み込みのロジックを渡して初期化
        Orders = new ValueHolder<List<Order>>(() => _repository.GetOrdersForCustomer(Id));
    }

    public int GetRepositoryCallCount() => _repository.CallCount;
}