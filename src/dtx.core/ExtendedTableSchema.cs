using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dtx.core
{
    public class ExtendedTableSchema
    {
        public TableSchema Schema { get; set; }
        public HashSet<ExtendedTableSchema> ImmidiateParentTables { get; set; }
        public HashSet<ExtendedTableSchema> AllParentTables { get; set; }

        public string TableName
        {
            get { return Schema.TableName; }
        }

        public HashSet<FieldSchema> Fields
        {
            get { return Schema.Fields; }
        }

        public HashSet<ForeignKey> ForeignKeys
        {
            get { return Schema.ForeignKeys; }
        }

        public ExtendedTableSchema(TableSchema table)
        {
            Schema = table;

            AllParentTables = new HashSet<ExtendedTableSchema>();
            ImmidiateParentTables = new HashSet<ExtendedTableSchema>();
        }

        public override string ToString()
        {
            var parentTables = string.Join(", ", ImmidiateParentTables.Select(x => x.TableName).ToList());

            var allParentTables = string.Join(", ", AllParentTables.Select(x => x.TableName).ToList());

            return string.Format("{0}, ImP: {1}, AP:{2}", TableName, parentTables, allParentTables);
        }
    }
}
