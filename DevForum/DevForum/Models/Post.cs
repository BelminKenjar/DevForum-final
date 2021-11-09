using System;
using System.Collections.Generic;

namespace DevForum.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public int LikeCount { get; set; }
        public int ReplyCount { get; set; }

        public int SubTopicId { get; set; }
        public virtual SubTopic SubTopic { get; set; }
        
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public virtual IEnumerable<PostReply> PostReplies { get; set; }
        public virtual IEnumerable<PostLike> PostLikes { get; set; }
    }
}