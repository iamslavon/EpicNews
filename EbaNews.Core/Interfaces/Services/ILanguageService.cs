using EbaNews.Core.Entities;
using System.Collections.Generic;

namespace EbaNews.Core.Interfaces.Services
{
    public interface ILanguageService
    {
        IEnumerable<Language> GetLanguages();
    }
}
