using FastExcel;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using MsBcConverter.Business;
using MsBcConverter.Interface;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace MsBcConverter.Tests
{
    [TestClass]
    public class MsBcConverterTests
    {
        [TestMethod]
        public void Method_A_Should_With_Argument_BlaBlaBla_Should_Not_Fail()
        {
            DataTable dataTable = ReadData();

            var tableConverter = new TableToExcelConverter();
            var result = tableConverter.Convert(dataTable, "Templates/import-artikel.xlsx");

            Assert.IsTrue(true);
        }

        // Playground
        //[TestMethod]
        //public void Read_Excel_File()
        //{
        //    var excelFile = "Templates/import-artikel.xlsx";
        //    var excelFile3 = "Templates/import-artikel-3.xlsx";
        //    DataTable dataTable = ReadData();

        //    using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(excelFile), new FileInfo(excelFile3)))
        //    {
        //        var worksheet = fastExcel.Worksheets.SingleOrDefault(w => w.Name == "Artikel");
        //        worksheet.Read();


        //        var rows = new List<Row>();
        //        rows.AddRange(worksheet.Rows);

        //        var rowNumber = rows.Count + 1;

        //        foreach (var row in dataTable.Rows)
        //        {
        //            if (row.Count == 0) continue;

        //            var cells = new List<Cell>();
        //            for (int columnNumber = 1; columnNumber <= dataTable.Header.Count; columnNumber++)
        //            {
        //                cells.Add(new Cell(columnNumber, row[columnNumber - 1]));
        //            }

        //            rows.Add(new Row(rowNumber, cells));
        //            ++rowNumber;

        //        }

        //        worksheet.Rows = rows;
        //        fastExcel.Write(worksheet, "Artikel");

        //        Debug.WriteLine(string.Format("Worksheet Name:{0}, Index:{1}", worksheet.Name, worksheet.Index));

        //        //To read the rows call read
        //        worksheet.Read();
        //        //Do something with rows
        //        Debug.WriteLine(string.Format("Worksheet Rows:{0}", rows.Count()));
        //    }
        //}

        private static DataTable ReadData()
        {
            var articles = File.ReadAllText("Resources/gemappte_artikel.txt");
            var articlesRows = articles.Split('\n');
            var header = articlesRows[0].Split('\t').ToList();
            var rows = articlesRows.Skip(1).Select(row => row.Split('\t').ToList()).ToList();

            var dataTable = new DataTable
            {
                Header = header,
                Rows = rows
            };
            return dataTable;
        }
    }
}
