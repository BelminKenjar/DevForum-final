using DevForum.Models;
using DevForum.ViewModels.Topic;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Subtopic
{
    public class SubtopicViewModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public DateTime CreatedAt { get; set; }
        public int? TopicId { get; set; }
        public virtual TopicViewModel Topic { get; set; }
        public string TopicName => Topic?.Title;

        //public virtual IEnumerable<Post> Posts { get; set; }
    }
}
