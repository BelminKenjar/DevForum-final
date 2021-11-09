using System;

namespace DevForum.Models
{
    public class PostLike
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int PostId { get; set; }
        public virtual Post Post { get; set; }

        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}