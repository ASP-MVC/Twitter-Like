namespace Twitter.Data.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class InitialCreate : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Messages",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        SenderId = c.String(maxLength: 128),
                        RecipientId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.RecipientId)
                .ForeignKey("dbo.AspNetUsers", t => t.SenderId)
                .Index(t => t.SenderId)
                .Index(t => t.RecipientId);
            
            CreateTable(
                "dbo.AspNetUsers",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Email = c.String(maxLength: 256),
                        EmailConfirmed = c.Boolean(nullable: false),
                        PasswordHash = c.String(),
                        SecurityStamp = c.String(),
                        PhoneNumber = c.String(),
                        PhoneNumberConfirmed = c.Boolean(nullable: false),
                        TwoFactorEnabled = c.Boolean(nullable: false),
                        LockoutEndDateUtc = c.DateTime(),
                        LockoutEnabled = c.Boolean(nullable: false),
                        AccessFailedCount = c.Int(nullable: false),
                        UserName = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.UserName, unique: true, name: "UserNameIndex");
            
            CreateTable(
                "dbo.AspNetUserClaims",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        UserId = c.String(nullable: false, maxLength: 128),
                        ClaimType = c.String(),
                        ClaimValue = c.String(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.Tweets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        Page = c.String(),
                        TweetedAt = c.DateTime(nullable: false),
                        UserId = c.String(maxLength: 128),
                        Tweet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Tweets", t => t.Tweet_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.UserId)
                .Index(t => t.UserId)
                .Index(t => t.Tweet_Id);
            
            CreateTable(
                "dbo.Reports",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TweetId = c.Int(nullable: false),
                        ReportedById = c.String(maxLength: 128),
                        ReportedAtDate = c.DateTime(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReportedById)
                .ForeignKey("dbo.Tweets", t => t.TweetId, cascadeDelete: true)
                .Index(t => t.TweetId)
                .Index(t => t.ReportedById);
            
            CreateTable(
                "dbo.AspNetUserLogins",
                c => new
                    {
                        LoginProvider = c.String(nullable: false, maxLength: 128),
                        ProviderKey = c.String(nullable: false, maxLength: 128),
                        UserId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.LoginProvider, t.ProviderKey, t.UserId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .Index(t => t.UserId);
            
            CreateTable(
                "dbo.ReTweets",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        TweetId = c.Int(nullable: false),
                        ReTweetedAt = c.DateTime(nullable: false),
                        ReTweetedById = c.String(maxLength: 128),
                        ReTweet_Id = c.Int(),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.ReTweets", t => t.ReTweet_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ReTweetedById)
                .ForeignKey("dbo.Tweets", t => t.TweetId, cascadeDelete: true)
                .Index(t => t.TweetId)
                .Index(t => t.ReTweetedById)
                .Index(t => t.ReTweet_Id);
            
            CreateTable(
                "dbo.AspNetUserRoles",
                c => new
                    {
                        UserId = c.String(nullable: false, maxLength: 128),
                        RoleId = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.UserId, t.RoleId })
                .ForeignKey("dbo.AspNetUsers", t => t.UserId, cascadeDelete: true)
                .ForeignKey("dbo.AspNetRoles", t => t.RoleId, cascadeDelete: true)
                .Index(t => t.UserId)
                .Index(t => t.RoleId);
            
            CreateTable(
                "dbo.Notifications",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Content = c.String(),
                        DateTime = c.DateTime(nullable: false),
                        ApplicationUserId = c.String(maxLength: 128),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.AspNetUsers", t => t.ApplicationUserId)
                .Index(t => t.ApplicationUserId);
            
            CreateTable(
                "dbo.AspNetRoles",
                c => new
                    {
                        Id = c.String(nullable: false, maxLength: 128),
                        Name = c.String(nullable: false, maxLength: 256),
                    })
                .PrimaryKey(t => t.Id)
                .Index(t => t.Name, unique: true, name: "RoleNameIndex");
            
            CreateTable(
                "dbo.FavouriteTweets",
                c => new
                    {
                        Favourite_Id = c.String(nullable: false, maxLength: 128),
                        FavouritedBy_Id = c.Int(nullable: false),
                    })
                .PrimaryKey(t => new { t.Favourite_Id, t.FavouritedBy_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.Favourite_Id, cascadeDelete: true)
                .ForeignKey("dbo.Tweets", t => t.FavouritedBy_Id, cascadeDelete: true)
                .Index(t => t.Favourite_Id)
                .Index(t => t.FavouritedBy_Id);
            
            CreateTable(
                "dbo.UsersFollowers",
                c => new
                    {
                        Follower_Id = c.String(nullable: false, maxLength: 128),
                        FollowedBy_Id = c.String(nullable: false, maxLength: 128),
                    })
                .PrimaryKey(t => new { t.Follower_Id, t.FollowedBy_Id })
                .ForeignKey("dbo.AspNetUsers", t => t.Follower_Id)
                .ForeignKey("dbo.AspNetUsers", t => t.FollowedBy_Id)
                .Index(t => t.Follower_Id)
                .Index(t => t.FollowedBy_Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.AspNetUserRoles", "RoleId", "dbo.AspNetRoles");
            DropForeignKey("dbo.Notifications", "ApplicationUserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "SenderId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Messages", "RecipientId", "dbo.AspNetUsers");
            DropForeignKey("dbo.AspNetUserRoles", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReTweets", "TweetId", "dbo.Tweets");
            DropForeignKey("dbo.ReTweets", "ReTweetedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.ReTweets", "ReTweet_Id", "dbo.ReTweets");
            DropForeignKey("dbo.AspNetUserLogins", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersFollowers", "FollowedBy_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.UsersFollowers", "Follower_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.FavouriteTweets", "FavouritedBy_Id", "dbo.Tweets");
            DropForeignKey("dbo.FavouriteTweets", "Favourite_Id", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tweets", "UserId", "dbo.AspNetUsers");
            DropForeignKey("dbo.Reports", "TweetId", "dbo.Tweets");
            DropForeignKey("dbo.Reports", "ReportedById", "dbo.AspNetUsers");
            DropForeignKey("dbo.Tweets", "Tweet_Id", "dbo.Tweets");
            DropForeignKey("dbo.AspNetUserClaims", "UserId", "dbo.AspNetUsers");
            DropIndex("dbo.UsersFollowers", new[] { "FollowedBy_Id" });
            DropIndex("dbo.UsersFollowers", new[] { "Follower_Id" });
            DropIndex("dbo.FavouriteTweets", new[] { "FavouritedBy_Id" });
            DropIndex("dbo.FavouriteTweets", new[] { "Favourite_Id" });
            DropIndex("dbo.AspNetRoles", "RoleNameIndex");
            DropIndex("dbo.Notifications", new[] { "ApplicationUserId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "RoleId" });
            DropIndex("dbo.AspNetUserRoles", new[] { "UserId" });
            DropIndex("dbo.ReTweets", new[] { "ReTweet_Id" });
            DropIndex("dbo.ReTweets", new[] { "ReTweetedById" });
            DropIndex("dbo.ReTweets", new[] { "TweetId" });
            DropIndex("dbo.AspNetUserLogins", new[] { "UserId" });
            DropIndex("dbo.Reports", new[] { "ReportedById" });
            DropIndex("dbo.Reports", new[] { "TweetId" });
            DropIndex("dbo.Tweets", new[] { "Tweet_Id" });
            DropIndex("dbo.Tweets", new[] { "UserId" });
            DropIndex("dbo.AspNetUserClaims", new[] { "UserId" });
            DropIndex("dbo.AspNetUsers", "UserNameIndex");
            DropIndex("dbo.Messages", new[] { "RecipientId" });
            DropIndex("dbo.Messages", new[] { "SenderId" });
            DropTable("dbo.UsersFollowers");
            DropTable("dbo.FavouriteTweets");
            DropTable("dbo.AspNetRoles");
            DropTable("dbo.Notifications");
            DropTable("dbo.AspNetUserRoles");
            DropTable("dbo.ReTweets");
            DropTable("dbo.AspNetUserLogins");
            DropTable("dbo.Reports");
            DropTable("dbo.Tweets");
            DropTable("dbo.AspNetUserClaims");
            DropTable("dbo.AspNetUsers");
            DropTable("dbo.Messages");
        }
    }
}
