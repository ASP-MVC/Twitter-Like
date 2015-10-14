namespace Twitter.Models
{
    using System;
    using System.ComponentModel.DataAnnotations;

    public class Notification
    {
        public int Id { get; set; }
        [Required]
        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType NotificationType { get; set; }
        
        public string ApplicationUserId { get; set; }

        public virtual ApplicationUser ApplicationUser { get; set; }
    }
}