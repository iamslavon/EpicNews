using System;
using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces;
using EbaNews.Core.Interfaces.Services;
using EbaNews.Core.Statistics;
using System.Collections.Generic;
using System.Linq;

namespace EbaNews.Services
{
    public class StatisticsService : IStatisticsService
    {
        private readonly IRepository<News> newsRepository;
        private readonly ILanguageService languageService;

        public StatisticsService(IRepository<News> newsRepository, ILanguageService languageService)
        {
            this.newsRepository = newsRepository;
            this.languageService = languageService;
        }

        public IEnumerable<NewsByLanguageModel> GetNewsCountByLanguages()
        {
            var response = new List<NewsByLanguageModel>();
            var totalCount = newsRepository.GetAll().Count();
            var languages = languageService.GetLanguages();

            foreach (var language in languages)
            {
                var count = newsRepository.GetAllBy(news => news.LanguageId == language.Id).Count();

                response.Add(new NewsByLanguageModel
                {
                    Language = language.Name,
                    Count = count,
                    Percentage = Math.Round((double) count / totalCount * 100, 1)
                });

            }

            return response;
        }
    }
}
