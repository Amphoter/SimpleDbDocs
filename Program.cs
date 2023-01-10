using DbDocsGenerator.ExcelLogic;
using DbDocsGenerator.Logic;

var savePath = "";
var connectionString = "";

if (string.IsNullOrEmpty(connectionString))
{
    Console.WriteLine("Connection string should not be empty");
    return;
}

var tables = DbDataProvider.GetDbTablesInfo(connectionString);
ExcelGenerator.GenerateExcelFile(tables, savePath);

Console.WriteLine($"Finished generatig db docs file");
Console.ReadLine();
