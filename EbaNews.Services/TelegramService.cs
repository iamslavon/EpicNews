using EbaNews.Core.Interfaces.Services;
using System.Configuration;
using System.Threading.Tasks;
using Telegram.Bot;

namespace EbaNews.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly string apiToken;

        public TelegramService()
        {
            apiToken = ConfigurationManager.AppSettings["TelegramApiToken"];
        }

        public async Task SendAsync(string channelId, string message)
        {
            var client = new TelegramBotClient(apiToken);
            await client.SendTextMessageAsync(channelId, message);
        }
    }
}
