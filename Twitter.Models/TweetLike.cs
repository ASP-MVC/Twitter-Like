namespace Twitter.Models
{
    public class TweetLike
    {
        public int Id { get; set; }

        public int TweetId { get; set; }
        
        public virtual Tweet Tweet { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }
    }
}