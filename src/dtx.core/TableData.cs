using System.Collections.Generic;

namespace Dtx
{
    public class TableData
    {
        public TableSchema Schema { get; set; }
        public List<RowData> Rows { get; set; }

        public TableData()
        {
            Rows = new List<RowData>();
        }

    }
}
