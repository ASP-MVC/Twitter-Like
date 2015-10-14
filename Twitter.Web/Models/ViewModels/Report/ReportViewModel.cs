namespace Twitter.Web.Models.ViewModels.Report
{
    using System;

    using AutoMapper;

    using Twitter.Models;
    using Twitter.Web.Infrastructure.Mapping;

    public class ReportViewModel : IMapFrom<Report>, IHaveCustomMappings
    {
        public int Id { get; set; }

        public int TweetId { get; set; }
        
        public string ReportedById { get; set; }

        public string ReportedByUsername { get; set; }

        public DateTime ReportedAtDate { get; set; }

        public void CreateMappings(IConfiguration configuration)
        {
            configuration.CreateMap<Report, ReportViewModel>()
                .ForMember(r => r.TweetId, opt => opt.MapFrom(r => r.TweetId))
                .ForMember(r => r.ReportedById, opt => opt.MapFrom(r => r.ReportedById))
                .ForMember(r => r.ReportedByUsername, opt => opt.MapFrom(r => r.ReportedBy.UserName))
                .ReverseMap();
        }
    }
}