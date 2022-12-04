using Cloudy.CMS.SingletonSupport;
using Cloudy.CMS.UI.FormSupport.FieldTypes;
using System.ComponentModel.DataAnnotations;

namespace cloudyweb.Models
{
    public class SiteSettings : ISingleton
    {
        public Guid? Id { get; set; }

        public string? SiteName { get; set; }

        [UIHint("textarea")]
        public string? FooterText { get; set; }
    }
}
