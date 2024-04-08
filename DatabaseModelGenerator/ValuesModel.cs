using System;

namespace DatabaseModelGenerator
{
    [Serializable]
    public class ValuesModel
    {
        public string RootNamespace { get; set; }
        public string SecondryNamespace { get; set; }
        public string Table { get; set; }
        public string Computed { get; set; }
        public string PrimaryKey { get; set; }
        public string Identity { get; set; }
        public string AllowNull { get; set; }
        public string MaxLength { get; set; }
        public string RepositoryInterface { get; set; }
        public string Unique { get; set; }
    }
}
