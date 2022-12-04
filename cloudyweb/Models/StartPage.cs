using Cloudy.CMS.SingletonSupport;
using System.ComponentModel.DataAnnotations;

namespace cloudyweb.Models
{
    public class StartPage : ISingleton
    {
        public Guid? Id { get; set; }

        public string? Headline { get; set; }
        public string? YoutubeVideo { get; set; }
        public string? MainIntro { get; set; }
        [UIHint("html")]
        public string? MainBody { get; set; }
    }
}
