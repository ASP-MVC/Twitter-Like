namespace Twitter.Data.UnitOfWork
{
    using Twitter.Data.Repositories;
    using Twitter.Models;

    public interface ITwitterData
    {
        IRepository<Tweet> Tweets { get; }

        IRepository<TweetLike> TweetLikes { get; }

        IRepository<Notification> Notifications { get; }

        IRepository<Message> Messages { get; }

        IRepository<ApplicationUser> ApplicationUsers { get; }

        int SaveChanges();
    }
}