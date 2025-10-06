using Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.Ghosts.DataSources;
using Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.Ghosts.Domains;
using Examples.Xunit.Helper;

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

    [Fact]
    public void TestPofEAA_11_3_6_UseGhost()
    {
        var dbMockEmployee = DbMockFactory.CreateDbMocks(new[] {
            new { Id = 100L, Name = "ALICE", DepartmentId = 200L },
        });

        var dbMockDepartment = DbMockFactory.CreateDbMocks(new[] {
            new { Id = 200L, Name = "SALES"},
        });

        var dbMockTimeRecord = DbMockFactory.CreateDbMocks(new[] {
            new { Id = 301L, RecordedAt = DateTime.Parse("2025-10-02")},
            new { Id = 302L, RecordedAt = DateTime.Parse("2025-10-03")},
            new { Id = 303L, RecordedAt = DateTime.Parse("2025-10-06")},
        });

        MapperRegistry.Register<Employee>(new EmployeeMapper(dbMockEmployee.Connection.Object));
        MapperRegistry.Register<Department>(new DepartmentMapper(dbMockDepartment.Connection.Object));
        MapperRegistry.Register<TimeRecord>(new TimeRecordMapper(dbMockTimeRecord.Connection.Object));
        DataSource.Init(MapperRegistry.Instance);

        Employee emp = new Employee(100);
        // 初めはGhost.
        Assert.True(emp.IsGhost);

        // Nameプロパティにアクセスするとデータをロードする.
        var name = emp.Name;
        Assert.False(emp.IsGhost);
        Assert.Equal("ALICE", name);

        // TimeRecordsプロパティのコレクションも最初はGhost.
        var timeRecords = emp.TimeRecords;
        Assert.True(timeRecords.IsGhost);

        // TimeRecord.Countプロパティにアクセスするとデータをロード.
        var timeRecordCount = timeRecords.Count;
        Assert.False(timeRecords.IsGhost);
        Assert.Equal(3, timeRecordCount);

        // 個別のTimeRecordはコレクションをロードした時にロード済.
        var timeRecordRow0 = timeRecords[0];
        Assert.False(timeRecordRow0.IsGhost);

        // Departmentプロパティのオブジェクトも最初はGhost.
        var dept = emp.Department;
        Assert.True(dept is not null);
        Assert.True(dept.IsGhost);

        // Department.Nameプロパティにアクセスするとデータをロードする.
        var deptName = dept.Name;
        Assert.False(dept.IsGhost);
        Assert.Equal("SALES", deptName);

        dbMockEmployee.VerifyAll();
        dbMockDepartment.VerifyAll();
        dbMockTimeRecord.VerifyAll();
    }
}