namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.Ghosts;

public class Customer
{
    public int Id { get; }
    private bool _isGhost = true;
    private readonly FakeOrderRepository _repository = new FakeOrderRepository();

    private string? _name;
    public string Name
    {
        get
        {
            Load(); // アクセス時にロードを試みる
            return _name!;
        }
    }

    private List<Order>? _orders;
    public List<Order> Orders
    {
        get
        {
            Load(); // アクセス時にロードを試みる
            return _orders!;
        }
    }

    // ゴーストとしてIDのみで初期化する
    public Customer(int id)
    {
        Id = id;
    }

    // 全データをロードするメソッド
    private void Load()
    {
        if (_isGhost)
        {
            // ここでDBからNameやOrdersなど全データを取得する
            // 本来は1回のDBアクセスで全データを取得するが、ここではOrdersの取得で代用
            _orders = _repository.GetOrdersForCustomer(Id);
            _name = $"Ghost Customer {Id}";

            _isGhost = false;
        }
    }

    public int GetRepositoryCallCount() => _repository.CallCount;
}