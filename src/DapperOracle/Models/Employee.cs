using System.ComponentModel.DataAnnotations.Schema;

namespace DapperOracle.Models;

public class Employee
{
    [Column("FIRST_NAME")]
    public string FirstName { get; set; }
}
