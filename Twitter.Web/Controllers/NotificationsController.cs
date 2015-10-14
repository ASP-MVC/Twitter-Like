namespace Twitter.Web.Controllers
{
    using System.Linq;
    using System.Web.Mvc;

    using AutoMapper.QueryableExtensions;

    using Twitter.Data.UnitOfWork;
    using Twitter.Web.Models.ViewModels.Notification;

    public class NotificationsController : BaseController
    {
        public NotificationsController(ITwitterData data)
            : base(data)
        {
        }

        public ActionResult GetAllNotifications()
        {
            var currentUserId = this.UserProfile.Id;
            var allNotifications = 
                this.TwitterData.Notifications.All()
                .Where(n => n.ApplicationUserId == currentUserId || n.ApplicationUser.FollowedBy.Any(u => u.Id == currentUserId))
                .Project()
                .To<NotificationViewModel>();

            return this.View(allNotifications);
        }

        public ActionResult GeFollowingUsersNotifications()
        {
            var currentUserId = this.UserProfile.Id;
            var user = this.TwitterData.ApplicationUsers.Find(currentUserId);
            var followedUsersNotifications = 
                this.TwitterData.Notifications.All()
                 .Where(n => n.ApplicationUser.FollowedBy.Any(u => u.Id == currentUserId))
                 .Project()
                 .To<NotificationViewModel>();

            return this.View(followedUsersNotifications);
        }
    }
}