using EbaNews.Core.Entities;

namespace EbaNews.Core.Interfaces.Services
{
    public interface INewsService
    {
        PagedResponse<News> GetNews(int page, int pageSize);

        int AddNews(News news);

        void EditNews(News news);

        void RemoveNews(int newsId);

        void SwitchOnlineStatus(int newsId, bool online);
    }
}
