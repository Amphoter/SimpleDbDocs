namespace DbDocsGenerator.Models
{
    public class Table
    {
        public string Name { get; set; }
        public Column[] Columns { get; set; } = Array.Empty<Column>();
    }
}
