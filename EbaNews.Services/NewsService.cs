using System.Data.Entity.Core;
using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
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

        public PagedResponse<News> GetAllNews(int page, int pageSize, int? languageId)
        {
            var query = repository
                .GetAll()
                .Where(x => x.Language.Id == languageId || languageId == null);

            var total = query.Count();

            var news = query
                .OrderByDescending(x => x.Id)
                .Skip((page - 1) * pageSize)
                .Take(pageSize)
                .ToList();

            return new PagedResponse<News>
            {
                Data = news,
                Total = total
            };
        }

        public PagedResponse<News> GetNewsList(int start, int count, string culture)
        {
            var total = repository
                .GetAll()
                .Where(x => x.Language.Culture == culture)
                .Count(x => x.Online);

            var news = repository
                .GetAll()
                .Where(x => x.Language.Culture == culture)
                .Where(x => x.Online)
                .OrderByDescending(x => x.PublicationDate)
                .Skip(start)
                .Take(count)
                .ToList();

            return new PagedResponse<News>
            {
                Total = total,
                Data = news
            };
        }

        public News GetNews(int id)
        {
            var news = repository.Get(id);

            if (news == null)
                throw new ObjectNotFoundException();

            IncrementViewsCount(id);

            return news;
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

        public void IncrementViewsCount(int id)
        {
            repository.Get(id).Views++;
            repository.SaveChanges();
        }
    }
}
