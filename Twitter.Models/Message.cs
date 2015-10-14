namespace Twitter.Models
{
    using System.ComponentModel.DataAnnotations;

    public class Message
    {
        public int Id { get; set; }

        [Required]
        [StringLength(300, MinimumLength = 2)]
        public string Content { get; set; }
        
        public string SenderId { get; set; }

        public virtual ApplicationUser Sender { get; set; }

        public string RecipientId { get; set; }

        public virtual ApplicationUser Recipient { get; set; }
    }
}