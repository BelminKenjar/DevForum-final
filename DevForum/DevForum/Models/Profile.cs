using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.Models
{
    public class Profile
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }

        public DateTime CreatedAt { get; set; }
        public string ApplicationUserId { get; set; }
        public virtual ApplicationUser ApplicationUser { get; set; }

        public virtual ProfileDetails ProfileDetails { get; set; }

        public virtual ProfileStats ProfileStats { get; set; }

        public virtual IEnumerable<Post> Posts { get; set; }
    }
}
