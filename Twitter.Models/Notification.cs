namespace Twitter.Models
{
    using System;

    public class Notification
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType NotificationType { get; set; }
        
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}