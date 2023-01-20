using DevForum.ViewModels.Reply;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface IPostReplyService
    {
        IEnumerable<PostReplyViewModel> Get(int PostId, PostReplySearchObject model = null);
        Task<PostReplyViewModel> GetById(int id);
        Task<PostReplyViewModel> Insert(PostReplyInsertModel model);
        Task<PostReplyViewModel> Update(int id, PostReplyUpdateModel model);
        Task Delete(int id);
    }
}
