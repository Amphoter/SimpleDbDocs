using ClosedXML.Excel;
using DbDocsGenerator.Models;

namespace DbDocsGenerator.ExcelLogic
{
    public static class ExcelGenerator
    {
        private const string defaultFileName = "DbDocs.xlsx";
        public static void GenerateExcelFile(Table[] tables, string filePath)
        {
            using var workBook = new XLWorkbook();
            var style = workBook.Style;

            workBook.AddGeneralWorkSheet(tables);
            workBook.AddTablesWorksheets(tables);
            workBook.AddLinks();
            workBook.AdjustColumnWidthToContent();

            if (!string.IsNullOrEmpty(filePath))
            {
                workBook.SaveAs($"{filePath}\\{defaultFileName}");
            }
            else
            {
                workBook.SaveAs($"{defaultFileName}");
            }           
        }
    }
}
