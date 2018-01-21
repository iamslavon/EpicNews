using EbaNews.Core.Entities;
using System.Threading.Tasks;

namespace EbaNews.Core.Interfaces.Services
{
    public interface ITelegramService
    {
        Task PublishAsync(News news);
    }
}
