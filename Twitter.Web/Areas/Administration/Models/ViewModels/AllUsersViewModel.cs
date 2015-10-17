namespace Twitter.Web.Areas.Administration.Models.ViewModels
{
    using System.Collections.Generic;

    using AutoMapper;

    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class AllUsersViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public byte[] ProfilePictureUrl { get; set; }

        public string Email { get; set; }

        public int UserTweetsCount { get; set; }

        public int UserReportsCount { get; set; }

        public bool IsActive { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, AllUsersViewModel>()
                .ForMember(u => u.UserTweetsCount, opt => opt.MapFrom(u => u.Tweets.Count))
                .ForMember(u => u.UserReportsCount, opt => opt.MapFrom(u => u.MyReports.Count))
                .ReverseMap();
        }
    }
}