using EbaNews.Core.Entities;
using EbaNews.Core.Responses;

namespace EbaNews.Core.Interfaces.Services
{
    public interface ISuggestedNewsService
    {
        PagedResponse<SuggestedNews> GetSuggestedNews(int page, int pageSize);

        int AddSuggestedNews(SuggestedNews news);

        void ApproveSuggestedNews(int newsId, int languageId);

        void DeclineSuggestedNews(int id);
    }
}
