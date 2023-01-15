namespace DbDocsGenerator.Models
{
    public class Column
    {
        public string Name { get; set; }
        public string IsNullable { get; set; }
        public string DataType { get; set; }
        public string FullDataType { get; set; }
        public int? CharacterMaxLength { get; set; }
        public int? NumericPrecision { get; set; }
        public int? NumericScale { get; set; }
    }
}
