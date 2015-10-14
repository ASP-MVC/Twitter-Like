namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Net;
    using System.Web.Mvc;
    using System.Web.UI.HtmlControls;

    using Microsoft.AspNet.Identity;

    using Twitter.Data.UnitOfWork;
    using Twitter.Models;
    using Twitter.Web.Models.BindingModels;
    using Twitter.Web.Models.ViewModels;

    public class TweetsController : BaseController
    {
        public TweetsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Reply()
        {
            return null;
        }
        
        [HttpPost]
        public ActionResult ReTweet(ReTweetBindingModel model)
        {

            return null;
        }

        [HttpGet]
        public PartialViewResult ReTweet()
        {
            return this.PartialView("_ReTweetPartial");
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
            return null;
        }

        public PartialViewResult CallAddTweetView()
        {
            return this.PartialView("_AddTweetPartial");
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult AddTweet(AddTweetBindingModel model)
        {
            if (!this.ModelState.IsValid)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

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
            return this.RedirectToAction("Home", "Users");
        }
    }
}