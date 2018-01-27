using EbaNews.Core.Entities;
using EbaNews.Core.Filters;
using EbaNews.Core.Interfaces;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Responses;
using System.Data.Entity.Core;
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

        public PagedResponse<News> GetAllNews(GetNewsFilter filter)
        {
            var query = repository
                .GetAll()
                .Where(x => x.Language.Id == filter.LanguageId || filter.LanguageId == null)
                .Where(x => x.Title.Contains(filter.SearchPhrase) || filter.SearchPhrase == null);

            var total = query.Count();

            var news = query
                .OrderByDescending(x => x.Id)
                .Skip((filter.Page - 1) * filter.PageSize)
                .Take(filter.PageSize)
                .ToList();

            return new PagedResponse<News>
            {
                Data = news,
                Total = total
            };
        }

        public PagedResponse<News> GetNewsList(int start, int count, string culture)
        {
            var query = repository
                .GetAll()
                .Where(x => x.Language.Culture == culture)
                .Where(x => x.Online);

            var total = query.Count();

            var news = query
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

        public void IncrementShareCount(int id)
        {
            repository.Get(id).ShareCount++;
            repository.SaveChanges();
        }
    }
}
