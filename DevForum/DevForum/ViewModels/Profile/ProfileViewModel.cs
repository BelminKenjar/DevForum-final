using DevForum.Models;
using DevForum.ViewModels.ProfileDetails;
using DevForum.ViewModels.ProfileStats;
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
        public ProfileDetailsViewModel ProfileDetails { get; set; }
        public ProfileStatsViewModel ProfileStats { get; set; }
}
}
