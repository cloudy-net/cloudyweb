using Cloudy.CMS.ModelBinding;
using Cloudy.CMS.SingletonSupport;
using cloudyweb.Models;
using Microsoft.AspNetCore.Mvc;

namespace cloudyweb.Controllers
{
    public class PageController : Controller
    {
        [Route("/{page:contentroute}")]
        public IActionResult Index([FromContentRoute] Page page)
        {
            return Content($"Page controller {page?.Name}");
        }
        public async Task<IActionResult> StartPage([FromServices] ISingletonGetter singletonGetter, [FromServices] Context context)
        {
            var siteSettings = await singletonGetter.Get<SiteSettings>();

            if(siteSettings == null)
            {
                return NotFound();
            }

            if(siteSettings.StartPage == null)
            {
                return NotFound();
            }

            var page = await context.FindAsync<Page>(siteSettings.StartPage);

            return Content($"Page controller {page?.Name}");
        }
    }
}
