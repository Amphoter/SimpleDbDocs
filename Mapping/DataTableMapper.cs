using Newtonsoft.Json;
using System.Data;

namespace DbDocsGenerator.Mapping
{
    public static class DataTableMapper
    {
        public static T MapDataTable<T>(DataTable dataTable)
        {
            var resultRows = new List<Dictionary<string, object>>();

            foreach (DataRow dr in dataTable.Rows)
            {
                var row = new Dictionary<string, object>();
                foreach (DataColumn col in dataTable.Columns)
                {
                    row.Add(col.ColumnName, dr[col]);
                }

                resultRows.Add(row);
            }

            var jsonResult = JsonConvert.SerializeObject(resultRows);

            var dbObjects = JsonConvert.DeserializeObject<T>(jsonResult);

            return dbObjects;
        }
    }
}
