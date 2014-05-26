using System.Collections.Generic;

namespace Dtx
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
