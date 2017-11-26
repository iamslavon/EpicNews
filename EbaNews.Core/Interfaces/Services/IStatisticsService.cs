using EbaNews.Core.Statistics;
using System.Collections.Generic;

namespace EbaNews.Core.Interfaces.Services
{
    public interface IStatisticsService
    {
        IEnumerable<NewsByLanguageModel> GetNewsCountByLanguages();
    }
}
