using EbaNews.Core.Enums;
using System;

namespace EbaNews.Core.Entities
{
    public class SuggestedNews : NewsBase
    {
        public DateTime SuggestionDate { get; set; }

        public SuggestedNewsStatus Status { get; set; }
    }
}
