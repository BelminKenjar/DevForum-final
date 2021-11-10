using System;

namespace DevForum.Models
{
    public class ProfileStats
    {
        public int Id { get; set; }
        public int Rating { get; set; }
        public int PostsCreated { get; set; }
        public int PostsCommented { get; set; }
        
        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}