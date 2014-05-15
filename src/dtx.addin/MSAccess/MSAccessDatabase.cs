using System;
using System.Collections.Generic;
using System.Data.OleDb;
using System.IO;
using dtx.core;

namespace dtx.addin.MSAccess
{
    public class MSAccessDatabase : IDatabase
    {
        private string _path;

        public MSAccessDatabase(string path)
        {
            _path = path;
        }

        public HashSet<TableSchema> GetTables()
        {
            throw new NotImplementedException();
        }

        public HashSet<ForeignKey> GetForeignKeys(string tableName)
        {
            throw new NotImplementedException();
        }

        public void CreateDatabase(string newDbFilePath)
        {
            File.Copy(_path, newDbFilePath);

            _path = newDbFilePath;
        }

        public void ExecuteNonQuery(List<string> sqls)
        {
            var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + _path);
            con.Open();
            var cmd = new OleDbCommand { Connection = con};

            foreach (var sql in sqls)
            {
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
            }

            cmd.Connection.Close();
        }

        public int ExecuteNonQuery(string sql)
        {
            var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + _path);
            con.Open();
            var cmd = new OleDbCommand { Connection = con, CommandText = sql };
            int res = cmd.ExecuteNonQuery();
            cmd.Connection.Close();

            return res;
        }

        public object ExecuteScalar(string sql)
        {
            var con = new OleDbConnection("Provider=Microsoft.ACE.OLEDB.12.0; Data Source=" + _path);
            con.Open();
            var cmd = new OleDbCommand { Connection = con, CommandText = sql };
            var res = cmd.ExecuteScalar();
            cmd.Connection.Close();

            return res;
        }



        public HashSet<TableIndex> GetIndexes(string tableName)
        {
            throw new NotImplementedException();
        }
    }
}
