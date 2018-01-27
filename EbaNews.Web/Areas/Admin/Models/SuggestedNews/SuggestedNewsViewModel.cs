using EbaNews.Core.Entities;
using System;

namespace EbaNews.Web.Areas.Admin.Models.SuggestedNews
{
    public class SuggestedNewsViewModel
    {
        public int Id { get; set; }

        public string Title { get; set; }

        public string LinkToArticle { get; set; }

        public string Ip { get; set; }

        public Language Language { get; set; }

        public DateTime SuggestionDate { get; set; }
    }
}