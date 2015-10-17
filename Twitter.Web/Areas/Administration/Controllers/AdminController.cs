namespace Twitter.Web.Areas.Administration.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Twitter.Data.UnitOfWork;
    using Twitter.Web.Areas.Administration.Models.ViewModels;
    using Twitter.Web.Models.ViewModels.User;

    public class AdminController : BaseAdminsController
    {
        public AdminController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Home()
        {
            return this.View();
        }

        public ActionResult GetAllUsers()
        {
            var allUsers =
                this.TwitterData.ApplicationUsers.All()
                    .OrderByDescending(u => u.Joined)
                    .ThenBy(u => u.Id)
                    .Project()
                    .To<AllUsersViewModel>()
                    .ToList();

            return this.PartialView(allUsers);
        }
    }
}