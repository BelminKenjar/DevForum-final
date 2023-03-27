using System;
using System.Collections.Generic;

namespace DevForum.Models
{
    public class PostReply
    {
        public int Id { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }
        public int LikeCount { get; set; }

        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public virtual IEnumerable<PostReplyLike> PostReplyLikes { get; set; }
    }
}