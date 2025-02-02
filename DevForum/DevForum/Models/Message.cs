using System;

namespace DevForum.Models
{
    public class Message
    {
        public string ClientUniqueId { get; set; }
        public string Type { get; set; }
        public string Content { get; set; }
        public DateTime Date { get; set; }
        public string GuestName { get; set; }
    }
}
