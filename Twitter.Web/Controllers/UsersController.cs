namespace Twitter.Web.Controllers
{
    using System;
    using System.IO;
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using PagedList;

    using Twitter.Data.UnitOfWork;
    using Twitter.Web.Models.ViewModels.User;

    [RoutePrefix("users")]
    public class UsersController : BaseController
    {
        public UsersController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult Home()
        {
            return this.View();
        }

        [HttpGet]
        [Authorize]
        public ActionResult FollowedUsersTweets(int? page)
        {
            var currentUserId = this.User.Identity.GetUserId();
            var user = this.TwitterData.ApplicationUsers.Find(currentUserId);
            if (user == null)
            {
                throw new ArgumentNullException();
            }

            var followeedUsers = 
                user.FollowedUsers
                .AsQueryable().Project().To<UserViewModel>();

            var pageNumber = (page ?? 1);
            return this.View(followeedUsers.ToPagedList(pageNumber, PageSize));
        }

        [Authorize]
        [HttpGet]
        public ActionResult MyProfile()
        {
            var user = this.UserProfile;
            var userProfile = Mapper.Map<UserProfileViewModel>(user);
            return this.View(userProfile);
        }

        [Authorize]
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult ChangePicture(HttpPostedFileBase file)
        {
            var currentUser = this.UserProfile;
            using (var memory = new MemoryStream())
            {
                file.InputStream.CopyTo(memory);
                var array = memory.GetBuffer();
                currentUser.ProfilePictureUrl = array;
                this.TwitterData.SaveChanges();
            }
            return null;
        }
    }
}