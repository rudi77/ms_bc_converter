using System.Collections.Generic;

namespace MsBcConverter.Interface
{
    public class DataTable
    {
        public List<string> Header { get; set; }

        public List<List<string>> Rows { get; set; }
    }
}
