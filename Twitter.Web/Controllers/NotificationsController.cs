namespace Twitter.Web.Controllers
{
    using System.Linq;
    using System.Web;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Microsoft.AspNet.Identity;

    using Twitter.Data.UnitOfWork;
    using Twitter.Web.Models.ViewModels.Notification;

    [Authorize]
    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        [HttpGet]
        public ActionResult GetAllNotifications()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var allNotifications =
                this.TwitterData.Notifications.All()
                    .Where(n => n.ApplicationUserId == currentUserId ||
                           n.ApplicationUser.FollowedBy.Any(u => u.Id == currentUserId))
                    .Project()
                    .To<NotificationViewModel>();

            return this.View(allNotifications);
        }

        [HttpGet]
        public ActionResult GeFollowingUsersNotifications()
        {
            var currentUserId = this.User.Identity.GetUserId();
            var user = this.TwitterData.ApplicationUsers.Find(currentUserId);
            if (user == null)
            {
                throw new HttpException(400, "User with such id does not exists");
            }

            var followedUsersNotifications =
                this.TwitterData.Notifications.All()
                    .Where(n => n.ApplicationUser.FollowedBy.Any(u => u.Id == currentUserId))
                    .Project()
                    .To<NotificationViewModel>();

            return this.View(followedUsersNotifications);
        }
    }
}