namespace Twitter.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using PagedList;

    using Twitter.Data.UnitOfWork;
    using Twitter.Web.Models.ViewModels;

    public class HomeController : BaseController
    {
        public HomeController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Index(int? page)
        {
            //if (Request.IsAuthenticated)
            //{
            //    return RedirectToAction("Index", "Home");
            //}
            var allTweets =
                this.TwitterData.Tweets.All()
                    .OrderByDescending(t => t.TweetedAt)
                    .ThenBy(t => t.Id)
                    .Project()
                    .To<TweetViewModel>()
                    .ToList();
            int pageNumber = (page ?? 1);

            return this.View(allTweets.ToPagedList(pageNumber, PageSize));
        }
    }
}