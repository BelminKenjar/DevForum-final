using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Models
{
    public class News
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Content { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? ProfileId { get; set; }
        public virtual Profile Profile { get; set; }
    }
}
