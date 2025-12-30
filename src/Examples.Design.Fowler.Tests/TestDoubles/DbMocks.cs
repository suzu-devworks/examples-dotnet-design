using System.Data;

namespace Examples.TestDoubles;

public class DbMocks
{
    public required Mock<IDbConnection> Connection { get; init; }
    public required Mock<IDbCommand> Command { get; init; }
    public Mock<IDataReader>? DataReader { get; init; }

    public void VerifyAll()
    {
        DataReader?.VerifyAll();
        DataReader?.VerifyNoOtherCalls();

        Command.VerifyAll();
        Command.VerifyNoOtherCalls();

        Connection.VerifyAll();
        Connection.VerifyNoOtherCalls();
    }
}