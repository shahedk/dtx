namespace Dtx.Test.BasicOperations
{
    public interface IDatabaseTest
    {
        void GetTables();
        void GetForeignKeys();
        void GetIndexes();
        void CreateDatabase();
        void ExecuteNonQuery();
        void ExecuteScalar();
    }
}
