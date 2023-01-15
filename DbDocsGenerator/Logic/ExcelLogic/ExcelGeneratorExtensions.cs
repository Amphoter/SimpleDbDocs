using ClosedXML.Excel;
using DbDocsGenerator.Models;
using System.Data;

namespace DbDocsGenerator.ExcelLogic
{
    public static class ExcelGeneratorExtensions
    {
        private const string GeneralSheetName = "All tables";

        public static void AddTablesWorksheets(this XLWorkbook workbook , Table[] tables)
        {
            foreach (var table in tables)
            {
                var workSheet = new DataTable(ExcelHelper.GenerateLinesheetName(table.Name));

                workSheet.Columns.AddRange(
                    new DataColumn[3] {
                        new DataColumn("ColumnName"),
                        new DataColumn("DataType"),
                        new DataColumn("IsNullable"),
                    });

                foreach (var column in table.Columns)
                {
                    workSheet.Rows.Add(column.Name, column.FullDataType, column.IsNullable);
                }

                workbook.Worksheets.Add(workSheet);
            }
        }

        public static void AddGeneralWorkSheet(this XLWorkbook workbook, Table[] tables)
        {
            var workSheet = new DataTable(GeneralSheetName);

            workSheet.Columns.AddRange(
                new DataColumn[1] {
                    new DataColumn("TableName")
                });

            foreach (var table in tables)
            {
                workSheet.Rows.Add(table.Name);
            }

            workbook.Worksheets.Add(workSheet);
        }

        public static void AddLinks(this XLWorkbook workbook)
        {
            var generalSheet = workbook.Worksheet(GeneralSheetName);
            var rows = generalSheet.Rows();

            foreach(var row in rows)
            {
                var firstCell = row.FirstCell();                

                var linesheetToLink = workbook.Worksheets.FirstOrDefault(x => string.Equals(x.Name, ExcelHelper.GenerateLinesheetName(firstCell.Value.ToString())));

                if (linesheetToLink != null)
                {
                    firstCell.SetHyperlink(new XLHyperlink(linesheetToLink.FirstCell()));
                }                
            }
        }

        public static void AdjustColumnWidthToContent(this XLWorkbook workbook)
        {
            foreach (var workSheet in workbook.Worksheets)
            {
                workSheet.Columns().AdjustToContents();
            }
        }
    }
}
