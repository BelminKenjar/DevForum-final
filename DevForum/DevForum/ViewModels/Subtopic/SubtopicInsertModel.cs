using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Subtopic
{
    public class SubtopicInsertModel
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int PostCount { get; set; }

        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public int TopicId { get; set; }
        public int ProfileId { get; set; }
    }
}
