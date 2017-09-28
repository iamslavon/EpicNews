namespace EbaNews.Core.Entities
{
    public class NewsBase : BaseEntity
    {
        public string Title { get; set; }

        public string LinkToArticle { get; set; }

        public virtual Language Language { get; set; }

        public int? LanguageId { get; set; }
    }
}
