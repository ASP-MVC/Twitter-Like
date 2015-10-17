namespace Twitter.Web.Models.ViewModels.User
{
    using System.Collections.Generic;

    using AutoMapper;

    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;
    using Twitter.Web.Models.ViewModels.Report;

    public class UserViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public byte[] ProfilePictureUrl { get; set; }

        public string Email { get; set; }

        public IEnumerable<TweetViewModel> UserTweets { get; set; }

        public IEnumerable<ReportViewModel> UserReports { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserViewModel>()
                .ForMember(u => u.UserTweets, opt => opt.MapFrom(u => u.Tweets))
                .ForMember(u => u.UserReports, opt => opt.MapFrom(u => u.MyReports))
                .ReverseMap();
        }
    }
}