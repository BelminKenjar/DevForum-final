using System;
using System.Collections.Generic;

namespace DevForum.Models
{
    public class SubTopic
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? TopicId { get; set; }
        public virtual Topic Topic { get; set; }
        public int ProfileId { get; set; }
        public virtual Profile Profile { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}