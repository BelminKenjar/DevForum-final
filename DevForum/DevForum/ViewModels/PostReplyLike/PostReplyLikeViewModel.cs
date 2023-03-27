using DevForum.Models;
using DevForum.ViewModels.Reply;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.PostReplyLike
{
    public class PostReplyLikeViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? PostReplyId { get; set; }
        public virtual PostReplyViewModel PostReply { get; set; }
        public int? ProfileId { get; set; }
        public virtual Profile.ProfileViewModel Profile { get; set; }
    }
}
