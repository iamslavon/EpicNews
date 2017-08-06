using System.Collections.Generic;

namespace EbaNews.Core
{
    public class PagedResponse<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
