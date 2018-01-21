using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces.Services;
using System;
using System.Configuration;
using System.Threading.Tasks;
using Telegram.Bot;

namespace EbaNews.Services
{
    public class TelegramService : ITelegramService
    {
        private readonly string apiToken;
        private readonly string channelId;
        private readonly string applicationUrl;

        public TelegramService()
        {
            apiToken = ConfigurationManager.AppSettings["TelegramApiToken"];
            channelId = ConfigurationManager.AppSettings["TelegramChannelId"];
            applicationUrl = ConfigurationManager.AppSettings["ApplicationUrl"];
        }

        public async Task PublishAsync(News news)
        {
            var client = new TelegramBotClient(apiToken);
            var message = ComposeMessage(news);
            await client.SendTextMessageAsync(channelId, message);
        }

        private string ComposeMessage(News news)
        {
            return $"{news.Title}{Environment.NewLine}{applicationUrl}/news/{news.Id}";
        }
    }
}
