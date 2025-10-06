using System.Data;
using Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.Ghosts.DataSources;
using Examples.Design.Fowler.Tests.ObjectRelationalBehavioral.LazyLoad.Ghosts.Domains;

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
        var mockConnection = new Mock<IDbConnection>();
        var mockCommand = new Mock<IDbCommand>();
        var mockParameter = new Mock<IDbDataParameter>();
        var mockParameters = new Mock<IDataParameterCollection>();
        var mockReader1 = new Mock<IDataReader>();
        var mockReader2 = new Mock<IDataReader>();
        var mockReader3 = new Mock<IDataReader>();

        mockConnection.Setup(x => x.CreateCommand()).Returns(mockCommand.Object);

        mockCommand.SetupProperty(x => x.CommandText, It.IsAny<string>());
        mockCommand.Setup(x => x.CreateParameter()).Returns(mockParameter.Object);
        mockParameter.SetupProperty(x => x.ParameterName);
        mockParameter.SetupProperty(x => x.Value);
        mockCommand.SetupGet(x => x.Parameters).Returns(mockParameters.Object);
        mockParameters.Setup(x => x.Add(It.IsAny<IDbDataParameter>()));

        mockCommand.SetupSequence(x => x.ExecuteReader())
            .Returns(mockReader1.Object)
            .Returns(mockReader2.Object)
            .Returns(mockReader3.Object);

        mockReader1.Setup(x => x.Read()).Returns(true);
        mockReader1.Setup(x => x["name"]).Returns("ALICE");
        mockReader1.Setup(x => x["department_id"]).Returns(200L);
        mockReader1.Setup(x => x.Close());

        mockReader2.SetupSequence(x => x.Read())
            .Returns(true).Returns(true).Returns(true).Returns(false);
        mockReader2.SetupSequence(x => x["id"])
            .Returns(301L).Returns(302L).Returns(303L);
        mockReader2.Setup(x => x.Close());

        mockReader3.Setup(x => x.Read()).Returns(true);
        mockReader3.Setup(x => x["name"]).Returns("SALES");
        mockReader3.Setup(x => x.Close());

        MapperRegistry.Register<Employee>(new EmployeeMapper(mockConnection.Object));
        MapperRegistry.Register<Department>(new DepartmentMapper(mockConnection.Object));
        MapperRegistry.Register<TimeRecord>(new TimeRecordMapper(mockConnection.Object));
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

        mockConnection.VerifyAll();
        mockCommand.VerifyAll();
        mockParameter.VerifyAll();
        mockParameters.VerifyAll();
        mockReader1.VerifyAll();
        mockReader2.VerifyAll();
        mockReader3.VerifyAll();
    }

}