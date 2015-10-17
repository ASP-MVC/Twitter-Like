namespace Twitter.Web.Controllers
{
    using System;
    using System.Web.Mvc;

    using Microsoft.AspNet.Identity;

    using Twitter.Common;
    using Twitter.Data.UnitOfWork;
    using Twitter.Models;
    using Twitter.Web.Models.BindingModels;

    [Authorize]
    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Reply()
        {
            throw new NotImplementedException();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ReTweet(ReTweetBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var tweet = this.TwitterData.Tweets.Find(model.TweetId);
                tweet.Retweets.Add(new Tweet { Content = model.Content, TweetedAt = DateTime.Now });
                this.TwitterData.SaveChanges();
                this.TempData[GlobalConstants.TempMessageKey] = "You have successfully retweeted!";
                return this.RedirectToAction("Home", "Users");
            }
            this.TempData[GlobalConstants.TempMessageKey] = "Error during retweet";
            return this.View("_ReTweetPartial", model);
        }

        [HttpGet]
        public ActionResult ReTweet(int id)
        {
            var bindingModel = new ReTweetBindingModel { TweetId = id };
            return this.View("_ReTweetPartial", bindingModel);
        }

        public ActionResult Favourite(int id)
        {
            var tweet = this.TwitterData.Tweets.Find(id);
            var currentUserId = this.User.Identity.GetUserId();
            var tweetLike = new TweetLike { TweetId = tweet.Id, UserId = currentUserId };
            this.TwitterData.TweetLikes.Add(tweetLike);
            this.TwitterData.SaveChanges();
            return this.RedirectToAction("Index", "Home");
        }

        public ActionResult Share()
        {
            throw new NotImplementedException();
        }

        [HttpGet]
        public ActionResult Add()
        {
            return this.View("_AddTweetPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Add(AddTweetBindingModel model)
        {
            if (model != null && this.ModelState.IsValid)
            {
                var currentUserId = this.User.Identity.GetUserId();
                var tweet = new Tweet
                            {
                                Content = model.Content,
                                Page = model.PageUrl,
                                TweetedAt = DateTime.Now,
                                UserId = currentUserId
                            };
                this.TwitterData.Tweets.Add(tweet);
                this.TwitterData.SaveChanges();
                this.TempData[GlobalConstants.TempMessageKey] = "You have successfully added your tweet!";
                return this.RedirectToAction("Home", "Users");
            }
            this.TempData[GlobalConstants.TempMessageKey] = "Error during add tweet";
            return this.View("_AddTweetPartial", model);
        }
    }
}