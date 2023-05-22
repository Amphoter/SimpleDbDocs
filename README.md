# SimpleDbDocs
Console application to generate db docs

Currently app can generate excel file for MS SQL Server. 

Steps to generate:
1. In Program.cs assign connection string value to connectionString variable
2. Optional: specify path to save file by assigning value to savePath variable
3. Run App

Generated file description:
File will containt worksheets with all tables that currently in db and one general sheet with all tables. On General sheet each table name will have link to specific sheet with table info content. Current table info content : ColumnName, DataType, IsNullable. But you can add any needed column by editing ExcelGeneratorExtensions.cs and Column.cs class to extend generated info. 

This app uses data from INFORMATION_SCHEMA.COLUMNS table to generate docs so generated file can be easily extended. Data that available from INFORMATION_SCHEMA.COLUMNS table can be found here https://learn.microsoft.com/en-us/sql/relational-databases/system-information-schema-views/columns-transact-sql?view=sql-server-ver16
