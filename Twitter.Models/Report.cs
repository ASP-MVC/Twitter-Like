namespace Twitter.Models
{
    using System;
    using System.Collections.Generic;

    public class Report
    {
        public int Id { get; set; }
        
        public int TweetId { get; set; }

        public virtual Tweet Tweet { get; set; }

        public string ReportedById { get; set; }

        public virtual ApplicationUser ReportedBy { get; set; }

        public DateTime ReportedAtDate { get; set; }
    }
}