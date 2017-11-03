namespace EbaNews.Core.Entities
{
    public class Language : BaseEntity
    {
        public Language() { }

        public Language(string name, string culture)
        {
            Name = name;
            Culture = culture;
        }

        public string Name { get; set; }

        public string Culture { get; set; }
    }
}
