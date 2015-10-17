namespace Twitter.Data.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;

    using Twitter.Common;
    using Twitter.Models;

    public sealed class Configuration : DbMigrationsConfiguration<TwitterDbContext>
    {
        public Configuration()
        {
            this.AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(TwitterDbContext context)
        {
            this.SeedRoles(context);
            this.SeedUsers(context);
            this.SeedTweets(context);
        }

        private void SeedTweets(TwitterDbContext context)
        {
            if (!context.Tweets.Any())
            {
                for (int i = 0; i < 5; i++)
                {
                    var tweet = new Tweet
                    {
                        Content = "TestTweet10" + i.ToString(),
                        Page = "TweetmeAt@mysite" + i.ToString() + ".com",
                        TweetedAt = DateTime.UtcNow
                    };
                    context.Tweets.Add(tweet);
                }
                context.SaveChanges();
            }
        }

        private void SeedUsers(TwitterDbContext context)
        {
            if (!context.Users.Any())
            {
                var store = new UserStore<ApplicationUser>(context);
                var manager = new UserManager<ApplicationUser>(store);
                var user = new ApplicationUser()
                {
                    UserName = "admin",
                    Email = "admin@mysite.com",
                    Joined = DateTime.Now
                };

                manager.Create(user, "123456");
                manager.AddToRole(user.Id, GlobalConstants.AdminRole);
                context.SaveChanges();
            }
        }

        private void SeedRoles(TwitterDbContext context)
        {
            if (!context.Roles.Any())
            {
                var store = new RoleStore<IdentityRole>(context);
                var manager = new RoleManager<IdentityRole>(store);

                var adminRole = new IdentityRole { Name = GlobalConstants.AdminRole };
                var userRole = new IdentityRole { Name = GlobalConstants.UserRole };

                manager.Create(adminRole);
                manager.Create(userRole);
                context.SaveChanges();
            }
        }
    }
}
