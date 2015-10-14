namespace Twitter.Data
{
    using System;
    using System.Data.Entity;
    using System.Linq;

    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Data.Interfaces;
    using Twitter.Data.Migrations;
    using Twitter.Models;

    public class TwitterDbContext : IdentityDbContext<ApplicationUser>, ITwitterDbContext
    {
        public TwitterDbContext()
            : base("TwitterDbContext", throwIfV1Schema: false)
        {
        }

        public virtual IDbSet<Tweet> Tweets { get; set; }

        public virtual IDbSet<TweetLike> TweetLikes { get; set; }

        public virtual IDbSet<Message> Messages { get; set; }

        public virtual IDbSet<Notification> Notifications { get; set; }

        public static TwitterDbContext Create()
        {
            return new TwitterDbContext();
        }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Message>().HasOptional(m => m.Sender).WithMany(m => m.SendMessages).WillCascadeOnDelete(false);
            modelBuilder.Entity<Message>().HasOptional(x => x.Recipient).WithMany(x => x.RecievedMessages).WillCascadeOnDelete(false);

            modelBuilder.Entity<ApplicationUser>()
                .HasMany(u => u.FollowedBy)
                .WithMany(u => u.FollowedUsers)
                .Map(m =>
                {
                    m.MapLeftKey("Follower_Id");
                    m.MapRightKey("FollowedBy_Id");
                    m.ToTable("UsersFollowers");
                });


            // Retweets
            modelBuilder.Entity<Tweet>()
                .HasOptional(t => t.RetweetedTweet)
                .WithMany(t => t.Retweets);

            // Replies
            modelBuilder.Entity<Tweet>()
                .HasOptional(t => t.ReplyTo)
                .WithMany(t => t.ReplyTweets);

            base.OnModelCreating(modelBuilder);
        }
    }
}