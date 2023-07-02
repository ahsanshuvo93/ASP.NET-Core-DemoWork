using Microsoft.AspNetCore.Mvc;

namespace ASP.NET_Core_DemoWork.Areas.WebApplication.Controllers
{
    [Area("WebApplication")]
    public class HomeController : Controller
    {
        [Route("")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
