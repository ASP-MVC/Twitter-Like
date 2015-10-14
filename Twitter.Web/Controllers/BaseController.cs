namespace Twitter.Web.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Twitter.Data;
    using Twitter.Data.UnitOfWork;
    using Twitter.Models;

    public abstract class BaseController : Controller
    {
        protected const int PageSize = 10;
        
        protected BaseController(ITwitterData data)
        {
            this.TwitterData = data;
        }

        protected ApplicationUser UserProfile { get; private set; }

        protected ITwitterData TwitterData { get; private set; }

        protected override IAsyncResult BeginExecute(RequestContext requestContext, AsyncCallback callback, object state)
        {
            this.UserProfile = this.TwitterData.ApplicationUsers.All().FirstOrDefault(u => u.UserName == requestContext.HttpContext.User.Identity.Name);

            return base.BeginExecute(requestContext, callback, state);
        }
    }
}