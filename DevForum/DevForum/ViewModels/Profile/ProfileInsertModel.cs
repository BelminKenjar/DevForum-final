using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Profile
{
    public class ProfileInsertModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; } = DateTime.Now;
        public string ApplicationUserId { get; set; }
    }
}
