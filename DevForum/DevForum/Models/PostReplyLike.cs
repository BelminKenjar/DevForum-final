using System;

namespace DevForum.Models
{
    public class PostReplyLike
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostReplyId { get; set; }
        public virtual PostReply PostReply { get; set; }
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}