namespace EbaNews.Core.Entities
{
    public class NewsBase : BaseEntity
    {
        /// <summary>
        /// News title
        /// </summary>
        public string Title { get; set; }

        /// <summary>
        /// Link to news source 
        /// </summary>
        public string LinkToArticle { get; set; }

        /// <summary>
        /// News language
        /// </summary>
        public virtual Language Language { get; set; }

        public int? LanguageId { get; set; }
    }
}
