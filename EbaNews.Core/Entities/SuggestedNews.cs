using EbaNews.Core.Enums;
using System;

namespace EbaNews.Core.Entities
{
    public class SuggestedNews : NewsBase
    {
        public SuggestedNews()
        {
            Status = SuggestedNewsStatus.New;
            SuggestionDate = DateTime.Now;
        }

        /// <summary>
        /// Date when news was suggested
        /// </summary>
        public DateTime SuggestionDate { get; set; }

        /// <summary>
        /// Status of suggested news
        /// </summary>
        public SuggestedNewsStatus Status { get; set; }

        /// <summary>
        /// IP address of user who suggests the news 
        /// </summary>
        public string Ip { get; set; }
    }
}
