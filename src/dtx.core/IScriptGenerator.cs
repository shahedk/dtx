using System.Collections.Generic;

namespace Dtx
{
    public interface IScriptGenerator
    {
        List<string> CreateTables(HashSet<TableSchema> tables);
        string CreateTable(TableSchema table);
        List<string> InsertData(string tableName, List<RowData> row);
        //List<RowData> GetData(string tableName, List<IFilter> filters);
    }
}
