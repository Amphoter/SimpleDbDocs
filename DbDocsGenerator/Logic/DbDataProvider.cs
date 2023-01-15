using DbDocsGenerator.Constants;
using DbDocsGenerator.Logic.SqlServer;
using DbDocsGenerator.Mapping;
using DbDocsGenerator.Models;
using System.Data;

namespace DbDocsGenerator.Logic
{
    public static class DbDataProvider
    {
        public static Table[] GetDbTablesInfo(string connectionString)
        {
            var dbObjects = SqlServerDataProvider.GetTablesInfoByDataBaseName(connectionString);

            var tableNames = dbObjects.Select(x => x.TableName).Distinct().ToArray();

            var mapper = MapperInitializer.CreateMapper();
            var tablesList = new List<Table>();

            foreach (var tableName in tableNames)
            {
                var tableObject = dbObjects.Where(x => x.TableName == tableName).ToArray();
                var table = new Table
                {
                    Name = tableName,
                    Columns = mapper.Map<Column[]>(tableObject)
                };

                PopulateFullDataTypeForColumns(table.Columns);


                tablesList.Add(table);
            }

            return tablesList.ToArray();
        }

        private static void PopulateFullDataTypeForColumns(Column[] columns)
        {
            foreach (var column in columns)
            {
                switch (column.DataType)
                {
                    case DbTypes.Nvarchar:
                        column.FullDataType = $"{column.DataType}" + ConvertTextType(column);
                        break;
                    case DbTypes.Varchar:
                        column.FullDataType = $"{column.DataType}" + ConvertTextType(column);
                        break;
                    case DbTypes.Decimal:
                        column.FullDataType = $"{column.DataType}({column.NumericPrecision},{column.NumericScale})";
                        break;
                    default:
                        column.FullDataType = column.DataType;
                        break;
                }
            }
        }

        private static string ConvertTextType(Column column)
        {
            return column.CharacterMaxLength.Value == -1 ? "(MAX)" : $"({column.CharacterMaxLength})";
        }
    }
}
