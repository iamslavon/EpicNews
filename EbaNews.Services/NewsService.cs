using EbaNews.Core;
using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces;
using EbaNews.Core.Interfaces.Services;
using System.Linq;

namespace EbaNews.Services
{
    public class NewsService : INewsService
    {
        private readonly IRepository<News> repository;

        public NewsService(IRepository<News> repository)
        {
            this.repository = repository;
        }

        public int AddNews(News news)
        {
            repository.Add(news);
            repository.SaveChanges();

            return news.Id;
        }

        public void EditNews(News news)
        {
            repository.Update(news);
            repository.SaveChanges();
        }

        public PagedResponse<News> GetNews(int page, int pageSize)
        {
            var total = repository.GetAll().Count();

            return new PagedResponse<News>
            {
                Data = repository.GetAll().Skip((page - 1) * pageSize).Take(pageSize).ToList(),
                Total = total
            };
        }

        public void RemoveNews(int newsId)
        {
            repository.Remove(newsId);
            repository.SaveChanges();
        }

        public void SwitchOnlineStatus(int newsId, bool online)
        {
            repository.Get(newsId).Online = online;
            repository.SaveChanges();
        }
    }
}
