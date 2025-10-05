namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.VirtualProxy;

// Customerが実装する共通インターフェース
public interface ICustomer
{
    int Id { get; }
    string Name { get; }
    List<Order> Orders { get; }
    int GetRepositoryCallCount();
}

// 本物のCustomerオブジェクト（データロードはコンストラクタで行う）
public class RealCustomer : ICustomer
{
    private readonly FakeOrderRepository _repository = new FakeOrderRepository();
    public int Id { get; }
    public string Name { get; }
    public List<Order> Orders { get; }

    public RealCustomer(int id)
    {
        Id = id;
        Name = $"Real Customer {id}"; // 本来はこれもDBから取得
        Orders = _repository.GetOrdersForCustomer(Id);
    }

    public int GetRepositoryCallCount() => _repository.CallCount;
}

// Customerの代理オブジェクト
public class CustomerProxy : ICustomer
{
    private readonly int _id;
    private RealCustomer? _realCustomer; // 本物のオブジェクトを保持するフィールド

    public CustomerProxy(int id)
    {
        _id = id;
    }

    public int Id => _id;
    public string Name => GetRealCustomer().Name;
    public List<Order> Orders => GetRealCustomer().Orders;
    public int GetRepositoryCallCount() => _realCustomer?.GetRepositoryCallCount() ?? 0;

    // 本物のオブジェクトが必要になったときに初めて生成する
    private RealCustomer GetRealCustomer()
    {
        if (_realCustomer == null)
        {
            _realCustomer = new RealCustomer(_id);
        }
        return _realCustomer;
    }
}