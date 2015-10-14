namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.Security.Claims;
    using System.Threading.Tasks;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    public class ApplicationUser : IdentityUser
    {
        private ICollection<ApplicationUser> followedBy;

        private ICollection<Tweet> tweets;

        private ICollection<Message> sendMessages;

        private ICollection<Message> recievedMessages;

        private ICollection<ApplicationUser> followedUsers;

        private ICollection<Report> myReports;

        private ICollection<TweetLike> userFavouriteTweets;

        private ICollection<Notification> notifications;

        public ApplicationUser()
        {
            this.followedBy = new HashSet<ApplicationUser>();
            this.followedUsers = new HashSet<ApplicationUser>();
            this.tweets = new HashSet<Tweet>();
            this.sendMessages = new HashSet<Message>();
            this.recievedMessages = new HashSet<Message>();
            this.myReports = new HashSet<Report>();
            this.userFavouriteTweets = new HashSet<TweetLike>();
            this.notifications = new HashSet<Notification>();
        }

        public virtual ICollection<Notification> Notifications
        {
            get
            {
                return this.notifications;
            }
            set
            {
                this.notifications = value;
            }
        }

        [StringLength(100)]
        public string JobTitle { get; set; }

        public string WebPage { get; set; }

        public DateTime Joined { get; set; }

        public byte[] ProfilePictureUrl { get; set; }

        public virtual ICollection<TweetLike> UserFavouriteTweets
        {
            get
            {
                return this.userFavouriteTweets;
            }
            set
            {
                this.userFavouriteTweets = value;
            }
        }

        public virtual ICollection<Message> RecievedMessages
        {
            get
            {
                return this.recievedMessages;
            }
            set
            {
                this.recievedMessages = value;
            }
        }

        public virtual ICollection<Message> SendMessages
        {
            get
            {
                return this.sendMessages;
            }
            set
            {
                this.sendMessages = value;
            }
        }

        public virtual ICollection<Tweet> Tweets
        {
            get
            {
                return this.tweets;
            }
            set
            {
                this.tweets = value;
            }
        }

        public virtual ICollection<ApplicationUser> FollowedBy
        {
            get
            {
                return this.followedBy;
            }
            set
            {
                this.followedBy = value;
            }
        }

        public virtual ICollection<ApplicationUser> FollowedUsers
        {
            get
            {
                return this.followedUsers;
            }
            set
            {
                this.followedUsers = value;
            }
        }

        public virtual ICollection<Report> MyReports
        {
            get
            {
                return this.myReports;
            }
            set
            {
                this.myReports = value;
            }
        }

        public async Task<ClaimsIdentity> GenerateUserIdentityAsync(UserManager<ApplicationUser> manager)
        {
            // Note the authenticationType must match the one defined in CookieAuthenticationOptions.AuthenticationType
            var userIdentity = await manager.CreateIdentityAsync(this, DefaultAuthenticationTypes.ApplicationCookie);
            // Add custom user claims here
            return userIdentity;
        }
    }
}