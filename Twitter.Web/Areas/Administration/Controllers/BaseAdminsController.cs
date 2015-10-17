namespace Twitter.Web.Areas.Administration.Controllers
{
    using System;
    using System.Linq;
    using System.Web.Mvc;
    using System.Web.Routing;

    using Twitter.Common;
    using Twitter.Data.UnitOfWork;
    using Twitter.Models;
    using Twitter.Web.Controllers;

    [Authorize(Roles = GlobalConstants.AdminRole)]
    public class BaseAdminsController : BaseController
    {
        public BaseAdminsController(ITwitterData data)
            : base(data)
        {
        }
    }
}