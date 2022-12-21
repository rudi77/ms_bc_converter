namespace MsBcConverter.Interface
{
    public interface ITableToExcelConverter
    {
        /// <summary>
        /// Gets a DataTable which represents data from a database. 
        /// Fills this template with data from the table. Returns the generated excel file
        /// </summary>
        /// <param name="dataTable"></param>
        /// <param name="excelTemplatePath"></param>
        /// <returns></returns>
        string Convert(DataTable dataTable, string excelTemplatePath);
    }
}
