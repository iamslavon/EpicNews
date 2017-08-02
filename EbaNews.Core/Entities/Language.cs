namespace EbaNews.Core.Entities
{
    public class Language : BaseEntity
    {
        public Language() { }

        public Language(string name)
        {
            Name = name;
        }

        public string Name { get; set; }
    }
}
