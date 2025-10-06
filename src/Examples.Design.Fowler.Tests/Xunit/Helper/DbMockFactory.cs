using System.Data;
using System.Text.RegularExpressions;

namespace Examples.Xunit.Helper;

public static partial class DbMockFactory
{
    /// <summary>
    /// Generates a set of database-related mocks based on the specified data list.
    /// </summary>
    /// <typeparam name="T">Data type</typeparam>
    /// <param name="data">List of data to read into IDataReader.</param>
    /// <returns>Container for the generated set of mocks</returns>
    public static DbMocks CreateDbMocks<T>(IEnumerable<T> data)
        where T : class
    {
        var dataList = data.ToList();
        var mockReader = new Mock<IDataReader>();

        // A counter indicating the current row.
        var currentRow = -1;

        // Set up the behavior of IDataReader.Read()
        mockReader.Setup(r => r.Read())
            .Callback(() => currentRow++)
            .Returns(() => currentRow < dataList.Count);

        // IDataReader[string]
        mockReader.Setup(r => r[It.IsAny<string>()])
            .Returns<string>(colName => GetValue(dataList, currentRow, colName)!);
        mockReader.Setup(r => r.Close());
        mockReader.Setup(r => r.Dispose());

        var mockCommand = new Mock<IDbCommand>();
        mockCommand.Setup(c => c.ExecuteReader()).Returns(mockReader.Object);
        mockCommand.SetupProperty(x => x.CommandText);

        var mockParameter = new Mock<IDbDataParameter>();
        mockCommand.Setup(x => x.CreateParameter()).Returns(mockParameter.Object);
        mockParameter.SetupProperty(x => x.ParameterName);
        mockParameter.SetupProperty(x => x.Value);

        var mockParameters = new Mock<IDataParameterCollection>();
        mockCommand.Setup(x => x.Parameters).Returns(mockParameters.Object);
        mockParameters.Setup(x => x.Add(It.IsAny<IDbDataParameter>()));

        mockCommand.Setup(r => r.Dispose());

        var mockConnection = new Mock<IDbConnection>();
        mockConnection.Setup(c => c.CreateCommand()).Returns(mockCommand.Object);

        return new DbMocks
        {
            Connection = mockConnection,
            Command = mockCommand,
            DataReader = mockReader
        };
    }

    private static object? GetValue<T>(List<T> dataList, int rowIndex, string colName)
    {
        if (rowIndex < 0 || rowIndex >= dataList.Count)
        {
            return default;
        }

        var row = dataList[rowIndex]!;

        var properties = row.GetType().GetProperties();
        var property = properties.FirstOrDefault(x => ToSnakeCase(x.Name) == colName);
        if (property is null)
        {
            return default;
        }

        var value = property.GetValue(row);
        return value;
    }

    [GeneratedRegex("[a-z][A-Z]")]
    private static partial Regex CamelCaseRegex();
    private static string ToSnakeCase(string name)
        => CamelCaseRegex()
            .Replace(name, s => $"{s.Groups[0].Value[0]}_{s.Groups[0].Value[1]}")
            .ToLower();

}