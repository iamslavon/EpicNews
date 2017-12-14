using AutoMapper;
using EbaNews.Core.Entities;
using EbaNews.Core.Enums;
using EbaNews.Core.Interfaces;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
using HtmlAgilityPack;
using System;
using System.Linq;
using System.Net;
using System.Text;
using NLog;

namespace EbaNews.Services
{
    public class SuggestedNewsService : ISuggestedNewsService
    {
        private readonly IRepository<SuggestedNews> suggestedNewsRepository;
        private readonly IRepository<News> newsRepository;
        private readonly Logger logger;

        public SuggestedNewsService(IRepository<SuggestedNews> suggestedNewsRepository, IRepository<News> newsRepository)
        {
            this.suggestedNewsRepository = suggestedNewsRepository;
            this.newsRepository = newsRepository;
            logger = LogManager.GetCurrentClassLogger();
        }

        public PagedResponse<SuggestedNews> GetSuggestedNews(int page, int pageSize)
        {
            var total = suggestedNewsRepository
                .GetAll()
                .Count(n => n.Status == SuggestedNewsStatus.New);

            var news = suggestedNewsRepository
                .GetAll()
                .Where(n => n.Status == SuggestedNewsStatus.New)
                .OrderByDescending(n => n.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResponse<SuggestedNews>
            {
                Data = news,
                Total = total
            };
        }

        public int AddSuggestedNews(SuggestedNews news)
        {
            suggestedNewsRepository.Add(news);
            suggestedNewsRepository.SaveChanges();

            return news.Id;
        }

        public void ApproveSuggestedNews(int newsId, int languageId, string title)
        {
            var suggestedNews = suggestedNewsRepository.Get(newsId);
            suggestedNews.Title = title;
            suggestedNews.LanguageId = languageId;
            suggestedNews.Status = SuggestedNewsStatus.Approved;
            suggestedNewsRepository.SaveChanges();

            var news = Mapper.Map<News>(suggestedNews);
            news.PublicationDate = DateTime.Now;
            newsRepository.Add(news);
            newsRepository.SaveChanges();
        }

        public void DeclineSuggestedNews(int id)
        {
            suggestedNewsRepository
                .Get(id)
                .Status = SuggestedNewsStatus.Declined;

            suggestedNewsRepository.SaveChanges();
        }

        public string TryGetTitleFromUrl(string url)
        {
            logger.Info($"Trying to get news title from url: {url}");

            try
            {
                using (var client = new WebClient())
                {
                    client.Encoding = Encoding.UTF8;
                    var htmlString = client.DownloadString(url);
                    var document = new HtmlDocument();
                    document.LoadHtml(htmlString);
                    var node = document.DocumentNode.SelectSingleNode("//h1");

                    if (node != null)
                    {
                        logger.Info("Successfully got title from tag <h1>");
                        return node.InnerText;
                    }

                    logger.Info("Can not find tag <h1>");

                    node = document.DocumentNode
                        .Descendants("div")
                        .Single(n => n.HasClass("eTitle"));

                    if (node != null)
                    {
                        logger.Info("Successfully got title from tag <div class='eTitle'>");
                        return node.InnerText;
                    }

                    logger.Info("Can not find tag <div class='eTitle'>");

                    return string.Empty;
                }
            }
            catch
            {
                logger.Error("Error occurred while accessing url");
                return string.Empty;
            }
        }
    }
}
