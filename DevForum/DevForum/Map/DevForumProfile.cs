using DevForum.Models;
using DevForum.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Map
{
    public class DevForumProfile : AutoMapper.Profile
    {
        public DevForumProfile()
        {
            //news
            CreateMap<News, NewsViewModel>();
            CreateMap<NewsInsertModel, News>();
            CreateMap<NewsUpdateModel, News>();
        }
    }
}
