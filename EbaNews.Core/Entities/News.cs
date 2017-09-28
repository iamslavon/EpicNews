using System;

namespace EbaNews.Core.Entities
{
    public class News : NewsBase
    {
        public DateTime PublicationDate { get; set; }

        public bool Online { get; set; }
    }
}
