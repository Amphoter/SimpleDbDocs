using Newtonsoft.Json;

namespace DbDocsGenerator.Models.SqlServer
{
    public class InformationSchema
    {
        [JsonProperty("TABLE_NAME")]
        public string TableName { get; set; }
        [JsonProperty("COLUMN_NAME")]
        public string ColumnName { get; set; }
        [JsonProperty("IS_NULLABLE")]
        public string IsNullable { get; set; }
        [JsonProperty("DATA_TYPE")]
        public string DataType { get; set; }

        [JsonProperty("CHARACTER_MAXIMUM_LENGTH")]
        public int? CharacterMaxLength { get; set; }

        [JsonProperty("NUMERIC_PRECISION")]
        public int? NumericPrecision { get; set; }

        [JsonProperty("NUMERIC_SCALE")]
        public int? NumericScale { get; set; }
    }
}
