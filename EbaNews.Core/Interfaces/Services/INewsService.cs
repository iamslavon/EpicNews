using EbaNews.Core.Entities;
using EbaNews.Core.Responses;

namespace EbaNews.Core.Interfaces.Services
{
    public interface INewsService
    {
        PagedResponse<News> GetAllNews(int page, int pageSize);

        PagedResponse<News> GetNewsList(int start, int count, string culture);

        News GetNews(int id);

        int AddNews(News news);

        void EditNews(News news);

        void RemoveNews(int newsId);

        void SwitchOnlineStatus(int newsId, bool online);

        void IncrementViewsCount(int id);
    }
}
