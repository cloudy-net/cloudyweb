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
            return View(page);
        }

        public async Task<IActionResult> StartPage([FromServices] ISingletonGetter singletonGetter, [FromServices] Context context)
        {
            var startPage = await singletonGetter.Get<StartPage>();

            if(startPage == null)
            {
                return NotFound();
            }

            return View("Start", startPage);
        }
    }
}
