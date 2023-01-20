using DevForum.ViewModels.Posts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface IPostService
    {
        IEnumerable<PostViewModel> Get(int SubTopicId, PostSearchObject model = null);
        Task<PostViewModel> GetById(int id);
        Task<PostViewModel> Insert(PostInsertModel model);
        Task<PostViewModel> Update(int id, PostUpdateModel model);
        Task Delete(int id);
    }
}
