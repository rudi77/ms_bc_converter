using FastExcel;
using MsBcConverter.Interface;

namespace MsBcConverter.Business
{
    public class TableToExcelConverter : ITableToExcelConverter
    {
        public string Convert(DataTable dataTable, string excelTemplatePath)
        {
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(excelTemplatePath), false))
            {
                var worksheet = GetWorksheet(fastExcel, "Artikel");

                InserRows(dataTable, worksheet);

                fastExcel.Write(worksheet);
            }

            return excelTemplatePath;
        }

        private static Worksheet GetWorksheet(FastExcel.FastExcel fastExcel, string worksheetName)
        {
            var worksheet = fastExcel.Worksheets.SingleOrDefault(w => w.Name == worksheetName);

            if (worksheet == null)
            {
                throw new ArgumentNullException(nameof(worksheet));
            }

            worksheet.Read();

            return worksheet;
        }

        private static void InserRows(DataTable dataTable, Worksheet worksheet)
        {
            var rows = new List<Row>();
            rows.AddRange(worksheet.Rows);

            var rowNumber = rows.Count + 1;

            foreach (var row in dataTable.Rows)
            {
                if (row.Count == 0) continue;

                var cells = new List<Cell>();
                for (int columnNumber = 1; columnNumber <= dataTable.Header.Count; columnNumber++)
                {
                    cells.Add(new Cell(columnNumber, row[columnNumber - 1]));
                }

                rows.Add(new Row(rowNumber, cells));
                ++rowNumber;
            }

            worksheet.Rows = rows;
        }
    }
}
