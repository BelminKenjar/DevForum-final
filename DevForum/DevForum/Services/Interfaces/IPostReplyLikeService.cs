using DevForum.ViewModels.PostReplyLike;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Services.Interfaces
{
    public interface IPostReplyLikeService
    {
        Task<PostReplyLikeViewModel> Insert(PostReplyLikeInsertModel model);
    }
}
