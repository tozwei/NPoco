using System;

namespace NPoco
{
    [AttributeUsage(AttributeTargets.Class)]
    public class TableNameAttribute : Attribute
    {
        public TableNameAttribute(string tableName)
        {
            Value = tableName;
        }
        public string Value { get; private set; }


        public TableNameAttribute(string tableName, string tableDescription)
        {
            Value = tableName;
            TableDescription = tableDescription;
        }

        public string TableDescription { get; private set; }
    }
}