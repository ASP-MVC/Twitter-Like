namespace Twitter.Data.Interfaces
{
    using System.Data.Entity;

    using Twitter.Models;

    public interface ITwitterDbContext
    {
        IDbSet<Tweet> Tweets { get; set; }  

        IDbSet<TweetLike> TweetLikes { get; set; }  

        IDbSet<Message> Messages { get; set; }  

        IDbSet<Notification> Notifications { get; set; }  
    }
}