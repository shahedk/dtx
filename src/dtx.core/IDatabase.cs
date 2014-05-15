using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
{
    public interface IDatabase
    {
        HashSet<TableSchema> GetTables();
        HashSet<ForeignKey> GetForeignKeys(string tableName);
        HashSet<TableIndex> GetIndexes(string tableName);
        void CreateDatabase(string newDbFilePath);
        int ExecuteNonQuery(string sql);
        object ExecuteScalar(string sql);
    }
}
