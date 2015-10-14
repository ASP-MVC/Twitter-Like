namespace Twitter.Web.Models.ViewModels.Tweet
{
    using System;
    using System.Collections.Generic;

    using Twitter.Web.Models.ViewModels.Report;

    public class MinifiedTweetViewModel
    {
        public int Id { get; set; }

        public string Content { get; set; }

        public string Page { get; set; }

        public DateTime TweetedAt { get; set; }

        public IEnumerable<ReportViewModel> Reports { get; set; }

        public int FavouritesCount { get; set; }
    }
}