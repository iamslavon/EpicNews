using EbaNews.Core.Entities;
using System;

namespace EbaNews.Web.Areas.Api.Models
{
    public class ExtendedNewsModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }

        public string LinkToArticle { get; set; }

        public DateTime PublicationDate { get; set; }

        public long ShareCount { get; set; }

        public Language Language { get; set; }
    }
}