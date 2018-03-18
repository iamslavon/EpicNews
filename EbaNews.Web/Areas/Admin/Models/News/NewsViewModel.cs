using EbaNews.Core.Entities;
using System;

namespace EbaNews.Web.Areas.Admin.Models.News
{
    public class NewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string LinkToArticle { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool Online { get; set; }

        public Language Language { get; set; }

        public long ShareCount { get; set; }
    }
}