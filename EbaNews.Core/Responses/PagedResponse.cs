using System.Collections.Generic;

namespace EbaNews.Core.Responses
{
    public class PagedResponse<T>
    {
        public int Total { get; set; }

        public IEnumerable<T> Data { get; set; }
    }
}
