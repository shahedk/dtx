using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
{
    public interface IScriptGenerator
    {
        List<string> CreateTables(HashSet<TableSchema> tables);
        string CreateTable(TableSchema table);
        List<string> InsertData(string tableName, List<RowData> row);
        //List<RowData> GetData(string tableName, List<IFilter> filters);
    }
}
