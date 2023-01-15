using DbDocsGenerator.Mapping;
using DbDocsGenerator.Models.SqlServer;
using System.Data;
using System.Data.SqlClient;

namespace DbDocsGenerator.Logic.SqlServer
{
    public static class SqlServerDataProvider
    {
        public static IEnumerable<InformationSchema> GetTablesInfoByDataBaseName(string connectionString)
        {
            using var connection = new SqlConnection(connectionString);
            connection.Open();

            var command = new SqlCommand(GetRawQuery(connection.Database), connection);
            using var dataAdapter = new SqlDataAdapter(command);

            var dataTable = new DataTable();

            dataAdapter.Fill(dataTable);
            connection.Close();

            return DataTableMapper.MapDataTable<List<InformationSchema>>(dataTable);
        }

        private static string GetRawQuery(string dbName)
        {
            return $"select * from INFORMATION_SCHEMA.COLUMNS WHERE TABLE_CATALOG = '{dbName}'";
        }
    }
}
