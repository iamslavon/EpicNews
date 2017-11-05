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
        /// Number of views
        /// </summary>
        public long Views { get; set; }
    }
}
