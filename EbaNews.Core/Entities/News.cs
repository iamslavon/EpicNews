using System;

namespace EbaNews.Core.Entities
{
    public class News : NewsBase
    {
        /// <summary>
        /// Date when news was published
        /// </summary>
        public DateTime PublicationDate { get; set; }

        /// <summary>
        /// News online status
        /// </summary>
        public bool Online { get; set; }

        /// <summary>
        /// Number of shares
        /// </summary>
        public long ShareCount { get; set; }

        /// <summary>
        /// If news has already published to social networks
        /// </summary>
        public bool SocialNetworksPublished { get; set; }
    }
}
