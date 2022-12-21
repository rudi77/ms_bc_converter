using FastExcel;
using MsBcConverter.Interface;
using System.Collections;

namespace MsBcConverter.Business
{
    public class TableToExcelConverter : ITableToExcelConverter
    {
        public string Convert(DataTable dataTable, string excelTemplatePath)
        {
            using (FastExcel.FastExcel fastExcel = new FastExcel.FastExcel(new FileInfo(excelTemplatePath), false))
            {
                var worksheet = fastExcel.Worksheets.SingleOrDefault(w => w.Name == "Artikel");

                if (worksheet == null)
                {
                    throw new ArgumentNullException(nameof(worksheet));
                }

                worksheet.Read();

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
                fastExcel.Write(worksheet);
            }

            return excelTemplatePath;
        }
    }
}
