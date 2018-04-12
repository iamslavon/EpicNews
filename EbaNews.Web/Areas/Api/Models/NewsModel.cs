using System;
using EbaNews.Core.Entities;

namespace EbaNews.Web.Areas.Api.Models
{
    public class NewsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string LinkToArticle { get; set; }

        public DateTime PublicationDate { get; set; }

        public long ShareCount { get; set; }

        public Language Language { get; set; }
    }
}