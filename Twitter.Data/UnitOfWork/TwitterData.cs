namespace Twitter.Data.UnitOfWork
{
    using System;
    using System.Collections.Generic;
    using System.Data.Entity;

    using Twitter.Data.Repositories;
    using Twitter.Models;

    public class TwitterData : ITwitterData
    {
        private readonly DbContext context;
        private readonly IDictionary<Type, object> repositories;

        public TwitterData(DbContext context)
        {
            this.context = context;
            this.repositories = new Dictionary<Type, object>();
        }

        public IRepository<TweetLike> TweetLikes
        {
            get
            {
                return this.GetRepository<TweetLike>();
            }
        }

        public IRepository<Tweet> Tweets
        {
            get
            {
                return this.GetRepository<Tweet>();
            }
        }

        public IRepository<Message> Messages
        {
            get
            {
                return this.GetRepository<Message>();
            }
        }

        public IRepository<Notification> Notifications
        {
            get
            {
                return this.GetRepository<Notification>();
            }
        }

        public IRepository<ApplicationUser> ApplicationUsers
        {
            get
            {
                return this.GetRepository<ApplicationUser>();
            }
        }

        public int SaveChanges()
        {
            return this.context.SaveChanges();
        }

        private IRepository<T> GetRepository<T>() where T : class
        {
            var typeOfRepository = typeof(T);
            if (!this.repositories.ContainsKey(typeOfRepository))
            {
                var newRepository = Activator.CreateInstance(typeof(GenericRepository<T>), this.context);
                this.repositories.Add(typeOfRepository, newRepository);
            }

            return (IRepository<T>)this.repositories[typeOfRepository];
        }
    }
}