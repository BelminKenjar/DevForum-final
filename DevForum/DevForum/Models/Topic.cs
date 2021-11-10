using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Models
{
    public class Topic
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int SubTopicCount { get; set; }
        public byte[] Logo { get; set; }

        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
        public virtual IEnumerable<SubTopic> SubTopics { get; set; }
    }
}

