using DevForum.ViewModels.News;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface INewsService
    {
        IEnumerable<NewsViewModel> Get();
        NewsViewModel GetById(int id);
        Task<NewsViewModel> Insert(NewsInsertModel model);
        Task Delete(int id);
        Task<NewsViewModel> Update(int id, NewsUpdateModel model);
    }
}
