namespace Twitter.Web.Models.ViewModels
{
    using System;
    using System.Collections.Generic;
    using System.Linq;

    using AutoMapper;

    using Twitter.Web.Infrastructure.Mapping;
    using Twitter.Web.Models.ViewModels.Report;

    public class TweetViewModel : IMapFrom<Twitter.Models.Tweet>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Page { get; set; }

        public DateTime TweetedAt { get; set; }

        public IEnumerable<ReportViewModel> Reports { get; set; }

        public int FavouritesCount { get; set; }

        public string UserName { get; set; }

        public string UserEmail { get; set; }

        public byte[] UserProfilePicture { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Twitter.Models.Tweet, TweetViewModel>()
                .ForMember(t => t.UserName, opt => opt.MapFrom(t => t.User.UserName))
                .ForMember(t => t.UserEmail, opt => opt.MapFrom(t => t.User.Email))
                .ForMember(t => t.UserProfilePicture, opt => opt.MapFrom(t => t.User.ProfilePictureUrl))
                .ForMember(t => t.FavouritesCount, opt => opt.MapFrom(t => t.TweetLikes.Select(l => l.Id).Count()))
                .ForMember(t => t.Reports, opt => opt.MapFrom(t => t.Reports))
                .ReverseMap();
        }
    }
}