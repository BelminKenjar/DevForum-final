using DevForum.ViewModels.PostLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface IPostLikeService
    {
        //IEnumerable<PostLikeViewModel> Get(int PostId);
        //Task<PostLikeViewModel> GetById(int id);
        Task<PostLikeViewModel> Insert(PostLikeInsertModel model);
        Task Delete(int id);
    }
}
