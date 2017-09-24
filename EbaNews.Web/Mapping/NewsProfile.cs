using AutoMapper;
using EbaNews.Core.Entities;
using EbaNews.Web.Areas.Admin.Models.News;

namespace EbaNews.Web.Mapping
{
    public class NewsProfile : Profile
    {
        public NewsProfile()
        {
            CreateMap<News, NewsViewModel>();

            CreateMap<NewsViewModel, News>()
                .ForMember(dest => dest.LanguageId, opt => opt.MapFrom(src => src.Language.Id))
                .ForMember(dest => dest.Language, opt => opt.Ignore());
        }
    }
}