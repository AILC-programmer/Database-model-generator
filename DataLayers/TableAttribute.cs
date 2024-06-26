using System;

namespace CafeParty.WindowsApp.DataLayers
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
    public class TableAttribute : Attribute
    {
        public string TableName;
        public string Schema;

        public TableAttribute(string Schema, string TableName)
        {
            this.TableName = TableName;
            this.Schema = Schema;
        }
    }
}
