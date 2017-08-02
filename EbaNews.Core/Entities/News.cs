using System;

namespace EbaNews.Core.Entities
{
    public class News : BaseEntity
    {
        public string Title { get; set; }

        public string LinkToArticle { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool Online { get; set; }

        public virtual Language Language { get; set; }
    }
}
