using AutoMapper;
using EbaNews.Core.Entities;
using EbaNews.Web.Areas.Admin.Models.News;
using EbaNews.Web.Areas.Admin.Models.SuggestedNews;

namespace EbaNews.Web.Mapping
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsViewModel>();
            CreateMap<NewsViewModel, News>()
                .ForMember(dest => dest.Language, opt => opt.Ignore());
            CreateMap<News, SuggestedNews>();
            CreateMap<SuggestedNews, News>()
                .ForMember(dest => dest.Language, opt => opt.Ignore());
            CreateMap<SuggestedNews, SuggestedNewsViewModel>().ReverseMap();
        }
    }
}