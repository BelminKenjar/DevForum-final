using DevForum.ViewModels.Posts;
using DevForum.ViewModels.Profile;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Reply
{
    public class PostReplyViewModel
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }

        public int? PostId { get; set; }
        public virtual PostViewModel Post { get; set; }

        public int? ProfileId { get; set; }
        public virtual ProfileViewModel Profile { get; set; }

        //public virtual IEnumerable<PostReplyLike> PostReplyLikes { get; set; }
    }
}
