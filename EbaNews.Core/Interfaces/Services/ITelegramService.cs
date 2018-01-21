using System.Threading.Tasks;

namespace EbaNews.Core.Interfaces.Services
{
    public interface ITelegramService
    {
        Task SendAsync(string channelId, string message);
    }
}
