using Dapper;
using Dapper.Oracle;
using Oracle.ManagedDataAccess.Client;
using System.Data;
using DapperOracle.Models;
using DapperOracle;

ColumnMapping.Setup();

IEnumerable<Employee> UsingSql(OracleConnection connection) => connection.Query<Employee>("SELECT * FROM EMPLOYEES ORDER BY EMPLOYEE_ID");

IEnumerable<Employee> UsingProc(OracleConnection connection)
{
    var parameters = new OracleDynamicParameters();
    parameters.Add(":p_rc", dbType: OracleMappingType.RefCursor, direction: ParameterDirection.Output);
    return connection.Query<Employee>("HR_PACKAGE.prGetEmployees", param: parameters, commandType: CommandType.StoredProcedure);
}

void PrintEmployees(string title, IEnumerable<Employee> employees)
{
    Console.WriteLine("----------------");
    Console.WriteLine(title);
    Console.WriteLine("----------------");

    foreach (var employee in employees)
    {
        Console.WriteLine(employee.FirstName);
    }
}

using OracleConnection connection = new("Data Source=localhost:1521;User Id=HR;Password=HR;");

PrintEmployees("Using SQL", UsingSql(connection));
PrintEmployees("Using Proc", UsingProc(connection));
