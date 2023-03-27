using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.PostReplyLike
{
    public class PostReplyLikeInsertModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PostReplyId { get; set; }
        public int ProfileId { get; set; }
    }
}
