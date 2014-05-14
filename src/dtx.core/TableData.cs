using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
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
