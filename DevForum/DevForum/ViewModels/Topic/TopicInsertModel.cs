using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Topic
{
    public class TopicInsertModel
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int SubTopicCount { get; set; } = 0;
        public byte[] Logo { get; set; }
        public int? ProfileId { get; set; }
    }
}
