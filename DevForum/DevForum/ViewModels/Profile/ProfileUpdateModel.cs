using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Profile
{
    public class ProfileUpdateModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public DateTime EditedAt { get; set; } = DateTime.Now;
    }
}
