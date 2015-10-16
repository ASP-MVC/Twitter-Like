namespace Twitter.Web.Models.BindingModels
{
    using System.ComponentModel.DataAnnotations;

    public class ReTweetBindingModel
    {
        [Required]
        [StringLength(190, MinimumLength = 2)]
        [UIHint("SingleLineText")]
        public string Content { get; set; }

        public int TweetId { get; set; }
    }
}