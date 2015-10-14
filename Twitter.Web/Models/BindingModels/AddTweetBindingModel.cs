namespace Twitter.Web.Models.BindingModels
{
    using System;

    public class AddTweetBindingModel
    {
        public string Content { get; set; }
        
        public string PageUrl { get; set; }

        public DateTime Birth { get; set; }
    }
}