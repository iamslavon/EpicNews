namespace EbaNews.Core.Dto
{
    public class ApproveSuggestedNewsDto
    {
        public int Id { get; set; }

        public int LanguageId { get; set; }

        public string Title { get; set; }

        public string Text { get; set; }
    }
}
