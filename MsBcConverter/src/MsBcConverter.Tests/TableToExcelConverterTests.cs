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
