namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;

    public class Tweet
    {
        private ICollection<TweetLike> tweetLikes;

        private ICollection<Report> reports;

        private ICollection<Tweet> replyTweets;

        private ICollection<Tweet> retweets;

        public Tweet()
        {
            this.replyTweets = new HashSet<Tweet>();
            this.retweets = new HashSet<Tweet>();
            this.tweetLikes = new HashSet<TweetLike>();
            this.reports= new HashSet<Report>();
        }

        public int Id { get; set; }

        public string Content { get; set; }

        public string Page { get; set; }
        
        public DateTime TweetedAt { get; set; }

        public string UserId { get; set; }

        public virtual ApplicationUser User { get; set; }

        public int? RetweetedTweetId { get; set; }

        public virtual Tweet RetweetedTweet { get; set; }

        public int? ReplyToId { get; set; }

        public virtual Tweet ReplyTo { get; set; }

        public virtual ICollection<Report> Reports
        {
            get
            {
                return this.reports;
            }

            set
            {
                this.reports = value;
            }
        }

        public virtual ICollection<TweetLike> TweetLikes
        {
            get
            {
                return this.tweetLikes;
            }
            set
            {
                this.tweetLikes = value;
            }
        }

        public virtual ICollection<Tweet> ReplyTweets
        {
            get { return this.replyTweets; }
            set { this.replyTweets = value; }
        }

        public virtual ICollection<Tweet> Retweets
        {
            get { return this.retweets; }
            set { this.retweets = value; }
        }
    }
}