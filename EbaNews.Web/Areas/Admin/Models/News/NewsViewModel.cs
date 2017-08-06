using EbaNews.Core.Entities;
using System;

namespace EbaNews.Web.Areas.Admin.Models.News
{
    public class NewsViewModel
    {
        public NewsViewModel(Core.Entities.News news)
        {
            Id = news.Id;
            Title = news.Title;
            LinkToArticle = news.LinkToArticle;
            PublicationDate = news.PublicationDate;
            Online = news.Online;
            Language = news.Language;
        }

        public int Id { get; set; }

        public string Title { get; set; }

        public string LinkToArticle { get; set; }

        public DateTime PublicationDate { get; set; }

        public bool Online { get; set; }

        public Language Language { get; set; }

        public Core.Entities.News ToNews()
        {
            return new Core.Entities.News
            {
                Id = Id,
                LinkToArticle = LinkToArticle,
                Online = Online,
                PublicationDate = PublicationDate,
                Title = Title,
                Language = Language
            };
        }
    }
}