using System.Collections.Generic;

namespace Dtx
{
    public class TableSchema
    {
        public string TableName { get; set; }
        public HashSet<FieldSchema> Fields { get; set; }
        public HashSet<ForeignKey> ForeignKeys { get; set; }

        public TableSchema()
        {
            ForeignKeys = new HashSet<ForeignKey>();
            Fields = new HashSet<FieldSchema>();

        }


    }
}
