using Microsoft.AspNetCore.Mvc;

namespace BMSHMedia.Controllers
{
    public class PortalController : Controller
    {
        public IActionResult Index()
        {
            return RedirectToAction("Index", "Media", new {Area="Portal"});
        }
    }
}
