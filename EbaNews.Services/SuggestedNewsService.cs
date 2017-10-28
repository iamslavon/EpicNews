using AutoMapper;
using EbaNews.Core.Entities;
using EbaNews.Core.Enums;
using EbaNews.Core.Interfaces;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
using System;
using System.Linq;

namespace EbaNews.Services
{
    public class SuggestedNewsService : ISuggestedNewsService
    {
        private readonly IRepository<SuggestedNews> suggestedNewsRepository;
        private readonly IRepository<News> newsRepository;

        public SuggestedNewsService(IRepository<SuggestedNews> suggestedNewsRepository, IRepository<News> newsRepository)
        {
            this.suggestedNewsRepository = suggestedNewsRepository;
            this.newsRepository = newsRepository;
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

        public void ApproveSuggestedNews(int newsId, int languageId)
        {
            var suggestedNews = suggestedNewsRepository.Get(newsId);
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
    }
}
