using DevForum.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevForum.ViewModels.PostLike
{
    public class PostLikeViewModel
    {
        public int Id { get; set; }
        public DateTime CreatedAt { get; set; }

        public int? PostId { get; set; }
        public virtual Post Post { get; set; }

        public int? ProfileId { get; set; }
        public virtual Models.Profile Profile{ get; set; }
    }
}
