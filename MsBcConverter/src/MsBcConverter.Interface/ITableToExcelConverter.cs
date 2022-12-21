namespace MsBcConverter.Interface
{
    public interface ITableToExcelConverter
    {
        /// <summary>
        /// Gets a table in form of a csv file/string and an excel template. 
        /// Fills this template with data from the table. Returns the generated excel file
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="excelTemplatePath"></param>
        /// <returns></returns>
        string Convert(DataTable dataTable, string excelTemplatePath);
    }
}
