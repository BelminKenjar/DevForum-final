using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Reply
{
    public class PostReplyInsertModel
    {
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public DateTime EditedAt { get; set; }
        public int PostId { get; set; }
        public int ProfileId { get; set; }
    }
}
