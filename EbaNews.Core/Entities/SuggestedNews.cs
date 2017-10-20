using EbaNews.Core.Enums;
using System;

namespace EbaNews.Core.Entities
{
    public class SuggestedNews : NewsBase
    {
        /// <summary>
        /// Date when news was suggested
        /// </summary>
        public DateTime SuggestionDate { get; set; }

        /// <summary>
        /// Status of suggested news
        /// </summary>
        public SuggestedNewsStatus Status { get; set; }
    }
}
