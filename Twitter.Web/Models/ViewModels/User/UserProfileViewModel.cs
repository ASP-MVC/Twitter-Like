namespace Twitter.Web.Models.ViewModels.User
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;

    using AutoMapper;

    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;
    using Twitter.Web.Models.ViewModels.Report;

    public class UserProfileViewModel : IMapFrom<ApplicationUser>, IHaveCustomMappings
    {
        public string Id { get; set; }

        public string UserName { get; set; }

        public byte[] ProfilePictureUrl { get; set; }

        public string Email { get; set; }

        [StringLength(100)]
        public string JobTitle { get; set; }

        public string WebPage { get; set; }

        public DateTime Joined { get; set; }

        public int TweetsCount { get; set; }

        public int FollowingCount { get; set; }

        public int FollowersCount { get; set; }

        public int FavouritesCount { get; set; }

        public IEnumerable<TweetViewModel> UserTweets { get; set; }

        public IEnumerable<ReportViewModel> UserReports { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<ApplicationUser, UserProfileViewModel>()
                .ForMember(u => u.TweetsCount, opt => opt.MapFrom(u => u.Tweets.Count))
                .ForMember(u => u.FollowingCount, opt => opt.MapFrom(u => u.FollowedUsers.Count))
                .ForMember(u => u.FollowersCount, opt => opt.MapFrom(u => u.FollowedBy.Count))
                .ForMember(u => u.FavouritesCount, opt => opt.MapFrom(u => u.UserFavouriteTweets.Count))
                .ForMember(u => u.UserTweets, opt => opt.MapFrom(u => u.Tweets))
                .ForMember(u => u.UserReports, opt => opt.MapFrom(u => u.MyReports))
                .ReverseMap();
        }
    }
}