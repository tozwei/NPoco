using System;

namespace NPoco
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field)]
    public class ColumnAttribute : Attribute
    {
        public ColumnAttribute() { }
        public ColumnAttribute(string name) { Name = name; }

        public ColumnAttribute(string name, string columnDescription)
        {
            Name = name;
            ColumnDescription = columnDescription;
        }

        public string Name { get; set; }
        public string ColumnDescription { get; set; }
        public bool ForceToUtc { get; set; } = true;
        public bool ExactNameMatch { get; set; }
    }
}