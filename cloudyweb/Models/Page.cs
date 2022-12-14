using Cloudy.CMS.ContentSupport;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace cloudyweb.Models
{
    public class Page : INameable, IRoutable
    {
        public Guid? Id { get; set; }

        public string? Name { get; set; }

        public string? UrlSegment { get; set; }

        [UIHint("html")]
        public string? MainBody { get; set; }
    }
}
