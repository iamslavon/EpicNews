using AutoMapper;

namespace EbaNews.Web.Mapping
{
    public static class AutoMapperConfig
    {
        public static void Register()
        {
            Mapper.Initialize(cfg => cfg.AddProfile<NewsProfile>());
        }
    }
}