using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Posts
{
    public class PostInsertModel
    {
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime EditedAt { get; set; } 
        public int LikeCount { get; set; } = 0;
        public int ReplyCount { get; set; } = 0;
        public int SubTopicId { get; set; }
        public int ProfileId { get; set; }
    }
}
