namespace Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad;

/// <summary>
/// 注文を表すシンプルなドメインオブジェクト
/// </summary>
public class Order
{
    public required int OrderId { get; init; }
    public required string ProductName { get; init; }
}