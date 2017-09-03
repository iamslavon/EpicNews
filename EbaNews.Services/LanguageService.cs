using EbaNews.Core.Entities;
using EbaNews.Core.Interfaces;
using EbaNews.Core.Interfaces.Services;
using System.Collections.Generic;

namespace EbaNews.Services
{
    public class LanguageService : ILanguageService
    {
        private readonly IRepository<Language> languageRepository;

        public LanguageService(IRepository<Language> languageRepository)
        {
            this.languageRepository = languageRepository;
        }

        public IEnumerable<Language> GetLanguages()
        {
            return languageRepository.GetAll();
        }
    }
}
