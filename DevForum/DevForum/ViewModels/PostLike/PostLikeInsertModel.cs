using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.PostLike
{
    public class PostLikeInsertModel
    {
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int PostId { get; set; }
        public int ProfileId { get; set; }
    }
}
