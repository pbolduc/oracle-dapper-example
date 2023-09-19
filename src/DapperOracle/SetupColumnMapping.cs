using Dapper;
using DapperOracle.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace DapperOracle;

public static class ColumnMapping
{

    public static void Setup()
    {
        // TODO: do this with either a source generator or reflection over all of the models

        Dapper.SqlMapper.SetTypeMap(
        typeof(Employee),
        new CustomPropertyTypeMap(
            typeof(Employee),
            (type, columnName) =>
                type.GetProperties().FirstOrDefault(prop =>
                    prop.GetCustomAttributes(false)
                        .OfType<ColumnAttribute>()
                        .Any(attr => attr.Name == columnName))));
    }
}
