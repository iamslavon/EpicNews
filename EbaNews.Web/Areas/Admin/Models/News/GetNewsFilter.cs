namespace EbaNews.Web.Areas.Admin.Models.News
{
    public class GetNewsFilter
    {
        public int Page { get; set; }

        public int PageSize { get; set; }

        public int? LanguageId { get; set; }
    }
}