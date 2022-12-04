using Cloudy.CMS.SingletonSupport;
using Cloudy.CMS.UI.FormSupport.FieldTypes;

namespace cloudyweb.Models
{
    public class SiteSettings : ISingleton
    {
        public Guid Id { get; set; }
        [Select(typeof(Page))]
        public Guid? StartPage { get; set; }
    }
}
