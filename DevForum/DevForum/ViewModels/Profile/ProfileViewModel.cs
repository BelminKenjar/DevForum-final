using DevForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.Profile
{
    public class ProfileViewModel
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public byte[] Image { get; set; }
        public DateTime CreatedAt { get; set; }
        public string ApplicationUserId { get; set; }
        //public int? ProfileDetailsViewModel ProfileDetails { get; set; }
        //public int? ProfileDetailsViewModel ProfileDetails { get; set; }
        //public int? ProfileDetailsViewModel ProfileDetails { get; set; }
    }
}
