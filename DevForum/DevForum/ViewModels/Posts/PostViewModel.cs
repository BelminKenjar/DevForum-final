using DevForum.Models;
using DevForum.ViewModels.Profile;
using DevForum.ViewModels.Subtopic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Posts
{
    public class PostViewModel
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime EditedAt { get; set; }
        public int LikeCount { get; set; }
        public int ReplyCount { get; set; }
        public int? ProfileId { get; set; }
        public virtual ProfileViewModel Profile { get; set; }
        public int? SubtopicId { get; set; }
        public virtual SubtopicViewModel Subtopic { get; set; }

        //public virtual IEnumerable<PostReply> PostReplies { get; set; }
        //public virtual IEnumerable<Models.PostLike> PostLikes { get; set; }
    }
}
