namespace Twitter.Web.Models.ViewModels.Notification
{
    using System;

    using AutoMapper;

    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class NotificationViewModel : IMapFrom<Notification>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public DateTime DateTime { get; set; }

        public NotificationType NotificationType { get; set; }

        public string NotifierUsername { get; set; }

        public string NotifierEmail { get; set; }

        public byte[] NotifierProfileImage { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Notification, NotificationViewModel>()
                .ForMember(n => n.NotifierUsername, opt => opt.MapFrom(n => n.ApplicationUser.UserName))
                .ForMember(n => n.NotifierEmail, opt => opt.MapFrom(n => n.ApplicationUser.Email))
                .ForMember(n => n.NotifierProfileImage, opt => opt.MapFrom(n => n.ApplicationUser.ProfilePictureUrl))
                .ReverseMap();
        }
    }
}