using System.Collections.Generic;
using System.Linq;

namespace dtx.core
{
    /// <summary>
    /// An extended schema object from the TableSchema to contain additional properties.
    /// </summary>
    public class ExtendedTableSchema
    {
        /// <summary>
        /// Contains basic schema information of the table
        /// </summary>
        public TableSchema Schema { get; set; }

        /// <summary>
        /// Contains the immidiate parent tables
        /// </summary>
        public HashSet<ExtendedTableSchema> ImmidiateParentTables { get; set; }

        /// <summary>
        /// Contains all parent tables 
        /// </summary>
        public HashSet<ExtendedTableSchema> AllParentTables { get; set; }

        /// <summary>
        /// Contains the actual name specified in the schema
        /// </summary>
        public string TableName
        {
            get { return Schema.TableName; }
        }

        /// <summary>
        /// Contains all fields/columns in the table
        /// </summary>
        public HashSet<FieldSchema> Fields
        {
            get { return Schema.Fields; }
        }

        /// <summary>
        /// Contains all foreign keys associated with this table
        /// </summary>
        public HashSet<ForeignKey> ForeignKeys
        {
            get { return Schema.ForeignKeys; }
        }

        /// <summary>
        /// Creates an extended schema object from the TableSchema to contain additional properties.
        /// </summary>
        /// <param name="table"></param>
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

            return string.Format("{0}, Immidiate Parent Tables: {1}, All Parent Tables:{2}", TableName, parentTables, allParentTables);
        }
    }
}
